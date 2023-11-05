using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TrainingSheet.Core.Models;
using TrainingSheet.Infraestructure.Persistence;

namespace TrainingSheet.Application.Commands.ExerciseCommands.CreateExercise
{
    public class CreateExerciseCommandHandler : IRequestHandler<CreateExerciseCommand, int>
    {
        public readonly TrainingSheetDbContext _dbContext;
        public CreateExerciseCommandHandler(TrainingSheetDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Handle(CreateExerciseCommand request, CancellationToken cancellationToken)
        {
            var exerise = new Exercise(request.ExerciseName);
            await _dbContext.Exercises.AddAsync(exerise);
            await _dbContext.SaveChangesAsync();

            return exerise.Id;
        }
    }
}
