using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingSheet.Core.Models;
using TrainingSheet.Infraestructure.Persistence;

namespace TrainingSheet.Application.Commands.SheetCommands.AddExerciseSheet
{
    public class AddExerciseSheetCommandHandler : IRequestHandler<AddExerciseSheetCommand, Unit>
    {
        private TrainingSheetDbContext _dbContext;

        public AddExerciseSheetCommandHandler(TrainingSheetDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(AddExerciseSheetCommand request, CancellationToken cancellationToken)
        {
            var sheetExercise = new SheetExercise(request.SheetId, request.ExerciseId, request.Series, request.Repetitons);

            await _dbContext
                .SheetExercises.AddAsync(sheetExercise);

            await _dbContext.SaveChangesAsync();

            return Unit.Value;

        }
    }
}
