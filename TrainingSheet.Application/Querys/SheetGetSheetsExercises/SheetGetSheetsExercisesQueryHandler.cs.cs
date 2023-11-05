using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingSheet.Application.ViewModels.ExerciseView;
using TrainingSheet.Application.ViewModels.SheetView;
using TrainingSheet.Infraestructure.Persistence;

namespace TrainingSheet.Application.Querys.SheetGetSheetsExercises
{
    public class SheetGetSheetsExercisesQueryHandler : IRequestHandler<SheetGetSheetsExercisesQuery, IList<SheetExerciseViewModel>>
    {
        private readonly TrainingSheetDbContext _dbContext;

        public SheetGetSheetsExercisesQueryHandler(TrainingSheetDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IList<SheetExerciseViewModel>> Handle(SheetGetSheetsExercisesQuery request, CancellationToken cancellationToken)
        {
 
            var sheet =  _dbContext
                .SheetExercises
                .Include(e=> e.Exercise)
                .Where(s => s.SheetId == request.SheetId)
                .Select(se=> new SheetExerciseViewModel(se.Exercise.ExerciseName, se.Series, se.Repetitons))
                .ToList();

            return sheet;

        }
    }
}
