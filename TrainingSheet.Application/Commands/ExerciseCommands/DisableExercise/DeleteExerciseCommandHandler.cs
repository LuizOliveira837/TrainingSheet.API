using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingSheet.Core.Repositories;
using TrainingSheet.Infraestructure.Persistence;

namespace TrainingSheet.Application.Commands.ExerciseCommands.DisableExercise
{
    public class DeleteExerciseCommandHandler : IRequestHandler<DisableExerciseCommand, Unit>
    {
        public readonly IExerciseRepository _exerciseRepository;
        public DeleteExerciseCommandHandler(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }
        public async Task<Unit> Handle(DisableExerciseCommand request, CancellationToken cancellationToken)
        {
            _exerciseRepository.DisableAsync(request.Id);

            return Unit.Value;
        }
    }
}
