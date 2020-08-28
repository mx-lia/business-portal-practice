using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.SalaryApi.Commands
{
    class CalculateSalaryCommandValidator : AbstractValidator<CalculateSalaryCommand>
    {
        public CalculateSalaryCommandValidator()
        {
            RuleFor(x => x.Experience)
                .InclusiveBetween(1, 20);
        }
    }
}
