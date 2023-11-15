using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSheet.Core.Models;

namespace TrainingSheet.Core.Repositories
{
    public interface IExerciseRepository
    {
        public Task<int> CreateAsync(string exerciseName);
        public void DisableAsync(int id);
        public Task<IList<Exercise>> GetAllAsync();
        public Task<Exercise> GetById(int id);
        public void UpdateAsync(Exercise exercise);
    }
}
