using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.SalaryApi.Commands
{
    public class GetPdfFileCommandValidator : AbstractValidator<GetPdfFileCommand>
    {
        public GetPdfFileCommandValidator()
        {
            RuleFor(x => x.backendMaxSalary)
                .NotEmpty();
            RuleFor(x => x.backendMinSalary)
                .NotEmpty();
            RuleFor(x => x.experience)
                .NotEmpty();
            RuleFor(x => x.frontendMaxSalary)
                .NotEmpty();
            RuleFor(x => x.frontendMinSalary)
                .NotEmpty();
            RuleFor(x => x.function)
                .NotEmpty();
            RuleFor(x => x.region)
                .NotEmpty();
        }
    }
}
