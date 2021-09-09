using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Domaine.Entities;
using StudentManagement.Domaine.Repositories;

namespace StudentManagement.Application.Identity.Queries
{
    public class GetAllRolesQuery:IRequest<IEnumerable<Role>>
    {

    }

    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, IEnumerable<Role>>
    {
        private readonly IRepository<Role> _repository;

        public GetAllRolesQueryHandler(IRepository<Role> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Role>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.Table.ToListAsync(cancellationToken: cancellationToken);
        }
    }
}