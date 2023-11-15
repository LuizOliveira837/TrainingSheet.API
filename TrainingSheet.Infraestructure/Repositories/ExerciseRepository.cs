using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSheet.Core.Models;
using TrainingSheet.Core.Repositories;
using TrainingSheet.Infraestructure.Persistence;

namespace TrainingSheet.Infraestructure.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        public readonly TrainingSheetDbContext _dbContext;

        public ExerciseRepository(TrainingSheetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateAsync(string exerciseName)
        {
            var exerise = new Exercise(exerciseName);
            await _dbContext.Exercises.AddAsync(exerise);
            await _dbContext.SaveChangesAsync();

            return exerise.Id;
        }

        public async void DisableAsync(int id)
        {
            var exercise = await _dbContext
                .Exercises
                .SingleAsync(e => e.Id == id);

            exercise.Disable();

            await _dbContext.SaveChangesAsync();

        }

        public async Task<IList<Exercise>> GetAllAsync()
        {
            var exercises = await _dbContext 
                .Exercises
                .Where(e => e.Status == Core.Enums.StatusEntity.Active)
                .ToListAsync();

            return exercises;
        }

        public async Task<Exercise> GetById(int id)
        {
            var exercise = await _dbContext
                .Exercises
                .SingleAsync (e => e.Id == id);

            return exercise;
        }

        public async void UpdateAsync(Exercise exercise)
        {
            await _dbContext.SaveChangesAsync();

        }
    }
}
