using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Application.Settings.DTOs;
using StudentManagement.Application.Settings.Queries.SchoolYears;

namespace StudentManagement.Api.Controllers
{
    [Route("api/school-years")]
    [ApiController]
    public class SchoolYearsController
    {
        private readonly IMediator _mediator;

        public SchoolYearsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Consumes("application/json")]

        public Task<IEnumerable<SchoolYearDto>> Get()
        {
            return _mediator.Send(new GetAllSchoolYears());
        }
    }
}