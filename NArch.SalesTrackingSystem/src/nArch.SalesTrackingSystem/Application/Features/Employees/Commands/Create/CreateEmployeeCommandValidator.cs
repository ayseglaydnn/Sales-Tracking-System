using FluentValidation;

namespace Application.Features.Employees.Commands.Create;

public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
        RuleFor(c => c.FirstName).NotEmpty();
        RuleFor(c => c.LastName).NotEmpty();
        RuleFor(c => c.DateOfBirth).NotEmpty();
        RuleFor(c => c.Email).NotEmpty();
        RuleFor(c => c.Phone).NotEmpty();
        RuleFor(c => c.Position).NotEmpty();
    }
}