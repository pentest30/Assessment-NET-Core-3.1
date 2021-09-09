using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Application.Settings.DTOs;
using StudentManagement.Domaine.Entities;
using StudentManagement.Domaine.Repositories;

namespace StudentManagement.Application.Settings.Queries.Specialities
{
    public class GetAllSpecialitiesQuery : IRequest<IEnumerable<SpecialityDto>>
    {
        
    }

    public class GetAllSpecialitiesQueryHandler :IRequestHandler<GetAllSpecialitiesQuery, IEnumerable<SpecialityDto>>
    {
        private readonly IRepository<Speciality> _repository;

        public GetAllSpecialitiesQueryHandler(IRepository<Speciality> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<SpecialityDto>> Handle(GetAllSpecialitiesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.Table.Select(x => new SpecialityDto {Name = x.Name, Id = x.Id}).ToListAsync(cancellationToken: cancellationToken);
        }
    }
}