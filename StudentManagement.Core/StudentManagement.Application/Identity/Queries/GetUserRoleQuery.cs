using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Domaine.Entities;
using StudentManagement.Domaine.Repositories;

namespace StudentManagement.Application.Identity.Queries
{
    public class GetUserRoleQuery : IRequest<string>
    {
        public Guid UserId { get; set; }
    }

    public class GetUserRoleQueryHandler : IRequestHandler<GetUserRoleQuery, string>
    {
        private readonly IRepository<IdentityUserRole<Guid>> _repository;
        private readonly IRepository<Role> _roleRepository;

        public GetUserRoleQueryHandler(IRepository<IdentityUserRole<Guid>> repository,IRepository<Role> roleRepository)
        {
            _repository = repository;
            _roleRepository = roleRepository;
        }

        public async Task<string> Handle(GetUserRoleQuery request, CancellationToken cancellationToken)
        {
            var userRole = await _repository.Table.FirstOrDefaultAsync(x => x.UserId == request.UserId,
                cancellationToken: cancellationToken);
            if (userRole == null) return String.Empty;
            
            var role = await _roleRepository.Table.FirstOrDefaultAsync(x => x.Id == userRole.RoleId,
                cancellationToken: cancellationToken);
            return role.Name;
        }
    }
}