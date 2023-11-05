using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingSheet.Application.ViewModels.ExerciseView;
using TrainingSheet.Infraestructure.Persistence;

namespace TrainingSheet.Application.Querys.ExerciseGetById
{
    public class ExerciseGetByIdQueryHandler : IRequestHandler<ExerciseGetByIdQuery, ExerciseViewModel>
    {
        public readonly TrainingSheetDbContext _dbContext;

        public ExerciseGetByIdQueryHandler(TrainingSheetDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ExerciseViewModel> Handle(ExerciseGetByIdQuery request, CancellationToken cancellationToken)
        {
            var exercise = await _dbContext.Exercises
              .SingleOrDefaultAsync(x => x.Id == request.Id);

            if (exercise == null) throw new NullReferenceException();

            var exerciseViewModel = new ExerciseViewModel(exercise.Id, exercise.ExerciseName);

            return exerciseViewModel;
        }
    }
}
