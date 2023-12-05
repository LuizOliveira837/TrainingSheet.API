using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TrainingSheet.Application.Commands.PractitionerCommands.CreatePractitioner;
using TrainingSheet.Application.InputModels.InputPractitioner;

namespace TrainingSheet.Application.Validators
{
    public class PractitionerInputModelValidator : AbstractValidator<CreatePractitionerCommand>
    {
        public PractitionerInputModelValidator()
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

            RuleFor(p => p.Password)
                .NotNull()
                .WithMessage("A Senha não pode ser nula")
                .NotEmpty()
                .WithMessage("A Senha deve ser preenchida")
                .Matches("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\W).{10}$")
                .WithMessage($"A senha deve conter pelo menos " +
                "1 letra maiscula | " +
                "1 letra minuscula| " +
                "1 Caracter especial");

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
