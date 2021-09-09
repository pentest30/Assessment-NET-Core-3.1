using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Api.Models.Settings;
using StudentManagement.Application.Settings.Commands;
using StudentManagement.Application.Settings.DTOs;
using StudentManagement.Application.Settings.Queries.Specialities;

namespace StudentManagement.Api.Controllers
{
    [Route("api/specialities")]
    [ApiController]
    public class SpecialitiesController :ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SpecialitiesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        //[Route("/api/specialities/getAll")]
        [HttpGet("getAll")]
        [Consumes("application/json")]

        public Task<IEnumerable<SpecialityDto>> GetAll()
        {
            return _mediator.Send(new GetAllSpecialitiesQuery());
        }

        [HttpPost]
        [Consumes("application/json")]
      
        public async Task<ActionResult> Create(SpecialityModel model)
        {
            var specialityCommand = _mapper.Map<CreateSpecialityCommand>(model);
            var result = await _mediator.Send(specialityCommand);
            return  !result.IsValid? (ActionResult) BadRequest(result): Ok(result);
        }
        [HttpPut("{id:Guid}")]
        [Consumes("application/json")]
      
        public async Task<ActionResult> Put([FromRoute] Guid id, SpecialityModel model)
        {
            if (id == Guid.Empty)
                return BadRequest();
            var specialityCommand = _mapper.Map<UpdateSpecialityCommand>(model);
            specialityCommand.Id = id;
            var result = await _mediator.Send(specialityCommand);
            return  !result.IsValid? (ActionResult) BadRequest(result): Ok(result);
        }
    }
}