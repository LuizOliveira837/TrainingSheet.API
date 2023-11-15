using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingSheet.Application.ViewModels.ExerciseView;
using TrainingSheet.Core.Repositories;
using TrainingSheet.Infraestructure.Persistence;

namespace TrainingSheet.Application.Querys.ExerciseGetAll
{
    public class ExerciseGetAllQueryHandler : IRequestHandler<ExerciseGetAllQuery, IList<ExerciseViewModel>>
    {
        public readonly IExerciseRepository _repository;
        public ExerciseGetAllQueryHandler(IExerciseRepository repository)
        {
            _repository = repository;
        }
        public async Task<IList<ExerciseViewModel>> Handle(ExerciseGetAllQuery request, CancellationToken cancellationToken)
        {
            var exercises = await _repository.GetAllAsync();

            return exercises
                .Select(e => new ExerciseViewModel(e.Id, e.ExerciseName))
                .ToList();
        }
    }
}
