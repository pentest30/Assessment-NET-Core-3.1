using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Api.Filters;
using StudentManagement.Api.Models.Students;
using StudentManagement.Application.Students.Commands;
using StudentManagement.Application.Students.DTOs;
using StudentManagement.Application.Students.Queries;

namespace StudentManagement.Api.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController :ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public StudentsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
      
        [Consumes("application/json")]
        [HttpGet]
        [Authorize]
        public Task<IEnumerable<StudentDto>> GetAll()
        {
            return _mediator.Send(new GetAllStudentsQuery());
        }
        [HttpPost]
        [Consumes("application/json")]
        public async Task<ActionResult> Create(StudentModel model)
        {
            
            var specialityCommand = _mapper.Map<CreateStudentCommand>(model);
            var result = await _mediator.Send(specialityCommand);
            return  !result.IsValid? (ActionResult) BadRequest(result): Ok(result);
        }

        [HttpPut("{id:Guid}/activate")]
        [Consumes("application/json")]
        public async Task<ActionResult> Activate([FromRoute] Guid id)
        {
            await _mediator.Send(new UpdateStudentStatusToActiveCommand {Id = id});
            return Ok(id);
        }
        [HttpPut("{id:Guid}/reject")]
        [Consumes("application/json")]

        public async Task<ActionResult> Reject([FromRoute] Guid id)
        {
            await _mediator.Send(new RejectStudentRegistrationCommand {Id = id});
            return Ok(id);
        }
    }
}