using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StudentManagement.Api.Filters;
using StudentManagement.Api.Models.Authentication;
using StudentManagement.Application.Identity.DTOs;
using StudentManagement.Application.Identity.Queries;
using StudentManagement.Domaine.Entities;

namespace StudentManagement.Api.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthController:ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;
        private SemaphoreSlim _slim = new SemaphoreSlim(1, 1);

        public AuthController(UserManager<User> userManager, 
            SignInManager<User> signInManager, 
            IConfiguration configuration,
            IMediator mediator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _mediator = mediator;
        }
        [Consumes("application/json")]
        [HttpGet("roles")]
        [Authorize]
        public Task<IEnumerable<Role>> GetAllRoles()
        {
            return _mediator.Send(new GetAllRolesQuery());
        }
        [Consumes("application/json")]
        [HttpGet("users")]
        [Authorize]
        public Task<IEnumerable<UserDto>> GetAllUser()
        {
            return _mediator.Send(new GetAllUsersQuery());
        }

        [HttpPost("authenticate")]
       // [AllowAnonymous]
        public async Task<IActionResult> Authenticate(UserModel model)
        {

            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, true, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(model.Username); 
                var response = GenerateJwtToken(user);
                var role = await _mediator.Send(new GetUserRoleQuery {UserId = user.Id});
                return Ok( new AuthenticateResponse(user,role, response));
            }

            return BadRequest("Username or password is incorrect");
        }
        [HttpPost("register")]
        [Consumes("application/json")]
        
        public async Task<ActionResult<User>> Post([FromBody] UserRegistrationModel model)
        {
            User user = new User
            {
                UserName = model.UserName,
                NormalizedUserName = model.UserName.ToUpper(),
                Email = model.Email,
                NormalizedEmail = model.Email?.ToUpper(),
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                PhoneNumber = model.PhoneNumber,
                
            };
            await _slim.WaitAsync();
            // saves the user
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);
            _slim.Release();
            if (!string.IsNullOrEmpty(model.Role)) await _userManager.AddToRoleAsync(user, model.Role);
            // var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            // await _userManager.ResetPasswordAsync(user, token, model.Password);
            return Created($"api/authentication/register/{user.Id}", new {userName = model.UserName});

        }
        private string GenerateJwtToken(User user)
        {
            // generates token 
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("Secret").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
       
    }
}