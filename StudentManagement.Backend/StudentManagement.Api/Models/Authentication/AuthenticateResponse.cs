using System;
using StudentManagement.Domaine.Entities;

namespace StudentManagement.Api.Models.Authentication
{
    public class AuthenticateResponse
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
        public DateTime Expiration { get; set; }


        public AuthenticateResponse(User user,string role, string token)
        {
            Id = user.Id;
            Username = user.UserName;
            Token = token;
            Expiration = DateTime.Now.AddDays(1);
            Role = role;
        }
    }
}