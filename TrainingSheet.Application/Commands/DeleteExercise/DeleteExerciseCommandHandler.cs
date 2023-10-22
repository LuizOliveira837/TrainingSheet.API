using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingSheet.Infraestructure.Persistence;

namespace TrainingSheet.Application.Commands.DeleteExercise
{
    public class DeleteExerciseCommandHandler : IRequestHandler<DeleteExerciseCommand, Unit>
    {
        public readonly TrainingSheetDbContext _dbContext;
        public DeleteExerciseCommandHandler(TrainingSheetDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeleteExerciseCommand request, CancellationToken cancellationToken)
        {
            var exercise = await _dbContext.Exercises
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (exercise == null) throw new NullReferenceException();

            _dbContext.Exercises.Remove(exercise);

            return Unit.Value;
        }
    }
}
