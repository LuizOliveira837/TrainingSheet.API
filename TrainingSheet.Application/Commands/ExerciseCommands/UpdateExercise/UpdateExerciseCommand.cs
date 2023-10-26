using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingSheet.Application.Commands.ExerciseCommands.UpdateExercise
{
    public class UpdateExerciseCommand : IRequest<Unit>
    {
        public UpdateExerciseCommand(int id, string exerciseName)
        {
            Id = id;
            ExerciseName = exerciseName;
        }

        public int Id { get; private set; }
        public string ExerciseName { get; private set; }


    }
}
