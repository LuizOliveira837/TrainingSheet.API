using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSheet.Application.InputModels.Exercise;
using TrainingSheet.Application.Services.Interface;
using TrainingSheet.Application.ViewModels.Exercise;
using TrainingSheet.Core.Models;
using TrainingSheet.Infraestructure.Persistence;

namespace TrainingSheet.Application.Services.Implementations
{
    public class ExerciseService : IExerciseService
    {
        public TrainingSheetDbContext _dbContext;
        public ExerciseService(TrainingSheetDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Delete(int id)
        {
            var exercise = _dbContext.Exercises
                .FirstOrDefault(x => x.Id == id);

            if (exercise == null) throw new NullReferenceException();

            _dbContext.Exercises.Remove(exercise);

        }

        public IList<ExerciseViewModel> GetAll()
        {
            var exercices =  _dbContext.Exercises
                .Where(e=> e.Status == Core.Enums.StatusEntity.Active)
                .Select(e => new ExerciseViewModel(e.Id, e.ExerciseName))
                .ToList();


            return exercices;

        }

        public ExerciseViewModel GetById(int id)
        {
            var exercise = _dbContext.Exercises
                .FirstOrDefault(x => x.Id == id);

            if (exercise == null) throw new NullReferenceException();

            var exerciseViewModel = new ExerciseViewModel(exercise.Id, exercise.ExerciseName);

            return exerciseViewModel;
        }

        public int Create(InputCreateModel input)
        {
            
            var exercise = new Exercise(input.ExerciseName);

            _dbContext.Exercises.Add(exercise);

            _dbContext.SaveChanges();

            return exercise.Id;

        }

        public void Update(int id, InputUpdateModel input)
        {
            var exercise = _dbContext.Exercises.FirstOrDefault(e =>  e.Id == id);

            if (exercise == null) throw new NullReferenceException();

            exercise.ExerciseName = input.ExerciseName;


        }
    }
}
