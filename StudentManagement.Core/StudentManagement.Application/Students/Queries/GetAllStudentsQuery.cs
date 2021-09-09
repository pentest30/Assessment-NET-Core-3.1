using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Application.Students.DTOs;
using StudentManagement.Domaine.Entities;
using StudentManagement.Domaine.Repositories;

namespace StudentManagement.Application.Students.Queries
{
    public class GetAllStudentsQuery :IRequest<IEnumerable<StudentDto>>
    {
    }

    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, IEnumerable<StudentDto>>
    {
        private readonly IRepository<Student> _repository;

        public GetAllStudentsQueryHandler(IRepository<Student> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<StudentDto>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var query = await _repository.Table
                .Include(x => x.Speciality)
                .Include(x => x.SchoolYear)
                .Select(x => new StudentDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Status = x.Status,
                    Speciality = x.Speciality.Name,
                    SchoolYear = x.SchoolYear.Name,
                    BirthDate = x.BirthDate
                }).ToListAsync(cancellationToken);
            return query;
        }
    }
}