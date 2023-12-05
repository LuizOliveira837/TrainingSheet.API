using FluentValidation;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSheet.Application.Commands.ExerciseCommands.CreateExercise;
using TrainingSheet.Application.InputModels.InputExercise;

namespace TrainingSheet.Application.Validators
{
    public class ExerciseInputModelValidator : AbstractValidator<CreateExerciseCommand>
    {

        public ExerciseInputModelValidator()
        {
            RuleFor(e => e.ExerciseName)
                .NotEmpty()
                .WithMessage("O nome do exercicio não pode ser nulo ou vazio.");
        }
    }
}
