using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TrainingSheet.Application.Commands.ExerciseCommands.CreateExercise
{
    public class CreateExerciseCommand : IRequest<int>
    {
        public string ExerciseName { get; set; }

        public CreateExerciseCommand(string exerciseName)
        {
            ExerciseName = exerciseName;
        }
    }
}
