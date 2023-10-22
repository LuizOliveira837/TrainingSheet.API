using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingSheet.Application.Commands.DeleteExercise
{
    public class DisableExerciseCommand : IRequest<Unit>
    {
        public int Id { get; private set; }
        public DisableExerciseCommand(int id)
        {
            Id = id;
        }
    }
}
