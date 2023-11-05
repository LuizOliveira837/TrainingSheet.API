using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSheet.Application.InputModels.InputPractitioner;

namespace TrainingSheet.Application.Validators
{
    public class PractitionerInputUpdateModelValidate : AbstractValidator<PractitionerInputUpdateModel>
    {

        public PractitionerInputUpdateModelValidate()
        {
            RuleFor(p => p.FullName)
              .NotNull()
              .WithMessage("O Nome não pode ser nula.")
              .NotEmpty()
              .WithMessage("O Nome deve ser preenchido.")
              .MaximumLength(50)
              .MinimumLength(10)
              .WithMessage("O Nome deve conter no minimo 10 caracteres e no maximo 50 caracteres");

            RuleFor(p => p.BirthDate)
                .NotNull()
                .NotEmpty()
                .WithMessage("A Data de Nascimento não pode ser nulo ou vazio.");

            RuleFor(p => p.Email)
              .NotNull()
              .WithMessage("A Senha não pode ser nula")
              .NotEmpty()
              .WithMessage("A Senha deve ser preenchida")
              .Matches("^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}$")
              .WithMessage($"Por favor, informe um Email valido.");

        }
    }
}
