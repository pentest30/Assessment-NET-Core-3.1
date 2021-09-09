using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Domaine.Entities;
using StudentManagement.Domaine.Repositories;

namespace StudentManagement.Application.Students.Commands
{
    public class RejectStudentRegistrationCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }

    public class RejectStudentRegistrationCommandHandler : IRequestHandler<RejectStudentRegistrationCommand>
    {
        private readonly IRepository<Student> _repository;

        public RejectStudentRegistrationCommandHandler( IRepository<Student> repository)
        {
            _repository = repository;
        }
       
        public async Task<Unit> Handle(RejectStudentRegistrationCommand request, CancellationToken cancellationToken)
        {
            var existingStudent =await _repository.Table.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
            if (existingStudent == null) throw new InvalidOperationException($"Student with {request.Id} was not found");
            existingStudent.Status = StudentRegistrationStatus.Rejected;
            _repository.Update(existingStudent);
            await _repository.UnitOfWork.SaveChangesAsync();

            return default;
        }
    }
}