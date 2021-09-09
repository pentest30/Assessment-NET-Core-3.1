using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Application.Settings.DTOs;
using StudentManagement.Domaine.Entities;
using StudentManagement.Domaine.Repositories;

namespace StudentManagement.Application.Settings.Queries.SchoolYears
{
    public class GetAllSchoolYears :IRequest<IEnumerable<SchoolYearDto>>
    {
        
    }

    public class GetAllSchoolYearsHandler : IRequestHandler<GetAllSchoolYears, IEnumerable<SchoolYearDto>>
    {
        private readonly IRepository<SchoolYear> _repository;

        public GetAllSchoolYearsHandler(IRepository<SchoolYear> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<SchoolYearDto>> Handle(GetAllSchoolYears request, CancellationToken cancellationToken)
        {
            var query = _repository.Table.Select(x => new SchoolYearDto() {Name = x.Name, Id = x.Id})
                .ToListAsync(cancellationToken: cancellationToken);
            return await query;
        }
    }
}