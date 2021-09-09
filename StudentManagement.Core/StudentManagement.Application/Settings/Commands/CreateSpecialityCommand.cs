using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using StudentManagement.Domaine.Entities;
using StudentManagement.Domaine.Repositories;

namespace StudentManagement.Application.Settings.Commands
{
    public class CreateSpecialityCommand :IRequest<ValidationResult>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CreateSpecialityCommandValidator : AbstractValidator<CreateSpecialityCommand>
    {
        public CreateSpecialityCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty();
        }
    }
    public class CreateSpecialityCommandHandler : IRequestHandler<CreateSpecialityCommand, ValidationResult>
    {
        private readonly IRepository<Speciality> _repository;

        public CreateSpecialityCommandHandler(IRepository<Speciality> repository)
        {
            _repository = repository;
        }
        public async Task<ValidationResult?> Handle(CreateSpecialityCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateSpecialityCommandValidator();
            var validationErrors = await validator.ValidateAsync(request, cancellationToken);
            if (!validationErrors.IsValid) return validationErrors;
            var speciality = new Speciality();
            speciality.Name = request.Name;
            speciality.Description = request.Description;
            _repository.Add(speciality);
            await _repository.UnitOfWork.SaveChangesAsync();
            return default;
        }
    }
}