using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSheet.Application.Commands.SheetCommands.CreateSheet;
using TrainingSheet.Application.InputModels.InputSheet;

namespace TrainingSheet.Application.Validators
{
    public class SheetInputModelValidate : AbstractValidator<CreateSheetCommand>
    {
        public SheetInputModelValidate()
        {
            RuleFor(s => s.SheetName)
                .NotEmpty()
                .WithMessage("O nome da Ficha não pode ser vazio.")
                .NotNull()
                .WithMessage("O nome da Ficha não pode nulo.")
                .MinimumLength(4)
                .MaximumLength(20)
                .WithMessage("O nome da Ficha deve ter no minimo 4 caracteres e no maximo 20 caracteres");

            RuleFor(s => s.PractitionerId)
                .NotEmpty()
                .WithMessage("O dono da ficha deve ser informado.")
                .NotNull()
                .WithMessage("O dono da ficha deve ser informado.");

            RuleFor(s => s.FinishIn)
                .NotEmpty()
                .WithMessage("Deve ser informado a data fim da Ficha.")
                .NotNull()
                .WithMessage("Deve ser informado a data fim da Ficha.");

            RuleFor(s => s.StartedIn)
               .NotEmpty()
               .WithMessage("Deve ser informado a data de inicio da Ficha.")
               .NotNull()
               .WithMessage("Deve ser informado a data de inicio da Ficha.");

        }
    }
}
