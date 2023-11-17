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
using TrainingSheet.Core.Repositories;
using TrainingSheet.Infraestructure.Persistence;

namespace TrainingSheet.Application.Querys.SheetGetSheetsExercises
{
    public class SheetGetSheetsExercisesQueryHandler : IRequestHandler<SheetGetSheetsExercisesQuery, IList<SheetExerciseViewModel>>
    {
        private readonly ISheetRepository _repository;

        public SheetGetSheetsExercisesQueryHandler(ISheetRepository repository)
        {
            _repository = repository;
        }
        public async Task<IList<SheetExerciseViewModel>> Handle(SheetGetSheetsExercisesQuery request, CancellationToken cancellationToken)
        {

            var sheet = await _repository
                .GetAllAsync(request.SheetId);



            return sheet
                .Select(s => new SheetExerciseViewModel(s.Exercise.ExerciseName, s.Series, s.Repetitons))
                .ToList();

        }
    }
}
