using System;
using FluentValidation.Results;
using MediatR;

namespace StudentManagement.Application.Settings.Commands
{
    public class UpdateSpecialityCommand : IRequest<ValidationResult>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}