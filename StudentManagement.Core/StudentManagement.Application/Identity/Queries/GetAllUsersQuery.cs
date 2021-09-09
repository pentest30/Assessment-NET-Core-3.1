using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Application.Identity.DTOs;
using StudentManagement.Domaine.Entities;
using StudentManagement.Domaine.Repositories;

namespace StudentManagement.Application.Identity.Queries
{
    public class GetAllUsersQuery: IRequest<IEnumerable<UserDto>>
    {
        
    }

    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMediator _mediator;

        public GetAllUsersQueryHandler(IRepository<User> userRepository, IMediator mediator)
        {
            _userRepository = userRepository;
            _mediator = mediator;
        }
        public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var query =await _userRepository.Table.Select(x => new UserDto {UserName = x.UserName, Id = x.Id})
                .ToListAsync(cancellationToken: cancellationToken);
            foreach (var userDto in query)
                userDto.Role = await _mediator.Send(new GetUserRoleQuery {UserId = userDto.Id}, cancellationToken);

            return query;
        }
    }
}