using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TrainingSheet.Core.Models;
using TrainingSheet.Core.Repositories;
using TrainingSheet.Infraestructure.Persistence;

namespace TrainingSheet.Application.Commands.ExerciseCommands.CreateExercise
{
    public class CreateExerciseCommandHandler : IRequestHandler<CreateExerciseCommand, int>
    {
        public readonly IExerciseRepository _exerciseRepository;
        public CreateExerciseCommandHandler(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }
        public async Task<int> Handle(CreateExerciseCommand request, CancellationToken cancellationToken)
        {
            var id = await _exerciseRepository.CreateAsync(request.ExerciseName);

            return id;
        }
    }
}
