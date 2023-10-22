using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingSheet.Infraestructure.Persistence;

namespace TrainingSheet.Application.Commands.UpdateExercise
{
    public class UpdateExerciseCommandHandler : IRequestHandler<UpdateExerciseCommand, Unit>
    {
        public readonly TrainingSheetDbContext _dbContext;
        public UpdateExerciseCommandHandler(TrainingSheetDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdateExerciseCommand request, CancellationToken cancellationToken)
        {
            var exercise = await _dbContext.Exercises.FirstOrDefaultAsync(e => e.Id == request.Id);

            if (exercise == null) throw new NullReferenceException();

            exercise.ExerciseName = request.ExerciseName;

            await _dbContext.SaveChangesAsync();

            return Unit.Value;

        }
    }
}
