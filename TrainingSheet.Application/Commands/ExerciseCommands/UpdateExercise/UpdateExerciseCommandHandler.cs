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

namespace TrainingSheet.Application.Commands.ExerciseCommands.UpdateExercise
{
    public class UpdateExerciseCommandHandler : IRequestHandler<UpdateExerciseCommand, Unit>
    {
        public readonly IExerciseRepository _repository;
        public UpdateExerciseCommandHandler(IExerciseRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(UpdateExerciseCommand request, CancellationToken cancellationToken)
        {
            var exercise = await _repository.GetById(request.Id);

            if (exercise == null) throw new NullReferenceException();

            exercise.ExerciseName = request.ExerciseName;

            _repository.UpdateAsync(exercise);

            return Unit.Value;

        }
    }
}
