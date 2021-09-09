using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using StudentManagement.Domaine.Entities;
using StudentManagement.Domaine.Repositories;

namespace StudentManagement.Application.Students.Commands
{
    public class CreateStudentCommand  : IRequest<ValidationResult>
    {
        public CreateStudentCommand()
        {
            Status = StudentRegistrationStatus.Waiting;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Guid SpecialityId { get; set; }
        public Guid SchoolYearId { get; set; }
        public StudentRegistrationStatus Status { get; set; }
    }

    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, ValidationResult>
    {
        private readonly IRepository<Student> _repository;

        public CreateStudentCommandHandler(IRepository<Student> repository)
        {
            _repository = repository;
        }
        public async Task<ValidationResult> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateStudentCommandValidator();
            var validationErrors = await validator.ValidateAsync(request, cancellationToken);
            if (!validationErrors.IsValid) return validationErrors;
            var student = new Student(request.FirstName, request.LastName, request.BirthDate.Date, request.SpecialityId,
                request.SchoolYearId, request.Status);
            try
            {
                _repository.Add(student);
                await _repository.UnitOfWork.SaveChangesAsync();
                
            }
            catch( Exception ex)
            {
                validationErrors.Errors.Add( new ValidationFailure("Exception", ex.Message));
            }

            return validationErrors;
        }
    }  

    public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentCommandValidator()
        {
            RuleFor(v => v.FirstName)
                .NotEmpty();
            RuleFor(v => v.LastName)
                .NotEmpty();
            RuleFor(v => v.BirthDate)
                .Must(x=>x!= default);
            RuleFor(v => v.SpecialityId)
                .Must(x=>x!= Guid.Empty);
            RuleFor(v => v.SchoolYearId)
                .Must(x=>x!= Guid.Empty);
        }
    }
}