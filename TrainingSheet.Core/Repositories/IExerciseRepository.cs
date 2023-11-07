using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSheet.Core.Models;

namespace TrainingSheet.Core.Repositories
{
    interface  IExerciseRepository
    {
        public  void CreateAsync();
        public  void UpdateAsync();
        public  void DisableAsync();
        public Task<IList<Exercise>> GetAllAsync();
        public Task<Exercise> GetById();
    }
}
