using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSheet.Application.InputModels.InputSheet;

namespace TrainingSheet.Application.Validators
{
    public class SheetAddExerciseInputModelValidator : AbstractValidator<SheetAddExerciseInputModel>
    {
        public SheetAddExerciseInputModelValidator()
        {
            RuleFor(s => s.ExerciseId)
                .NotEmpty()
                .WithMessage("O Exercicio deve ser informado.")
                .NotNull()
                .WithMessage("O Exercicio deve ser informado.");

            RuleFor(s => s.Repetitons)
                .NotEmpty()
                .WithMessage("O numero de Repetições deve ser infromado.")
                .NotNull()
                .WithMessage("O numero de Repetições deve ser infromado.");

            RuleFor(s => s.Series)
                 .NotEmpty()
                 .WithMessage("O numero de Series deve ser infromado")
                 .NotNull()
                 .WithMessage("O numero de Series deve ser infromado");
        }
    }
}
