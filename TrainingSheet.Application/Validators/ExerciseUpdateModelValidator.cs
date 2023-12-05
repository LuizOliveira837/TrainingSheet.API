using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSheet.Application.Commands.ExerciseCommands.UpdateExercise;

namespace TrainingSheet.Application.Validators
{
    public class ExerciseUpdateModelValidator : AbstractValidator<UpdateExerciseCommand>
    {
        public ExerciseUpdateModelValidator()
        {
            RuleFor(e => e.ExerciseName)
                .NotEmpty()
                .WithMessage("O nome do exercicio não pode ser nulo ou vazio.");
        }
    }
}
