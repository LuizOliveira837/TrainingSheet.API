using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingSheet.Application.ViewModels.ExerciseView;
using TrainingSheet.Infraestructure.Persistence;

namespace TrainingSheet.Application.Querys.ExerciseGetAll
{
    public class ExerciseGetAllQueryHandler : IRequestHandler<ExerciseGetAllQuery, IList<ExerciseViewModel>>
    {
        public readonly TrainingSheetDbContext _dbContext;
        public ExerciseGetAllQueryHandler(TrainingSheetDbContext dbContext)
        {
            _dbContext= dbContext;
        }
        public async Task<IList<ExerciseViewModel>> Handle(ExerciseGetAllQuery request, CancellationToken cancellationToken)
        {

            return  _dbContext.Exercises
                .Where(e => e.Status == Core.Enums.StatusEntity.Active)
                .Select(e => new ExerciseViewModel(e.Id, e.ExerciseName))
                .ToList();
        }
    }
}
