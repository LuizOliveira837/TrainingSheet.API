using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSheet.Core.Models;

namespace TrainingSheet.Core.Repositories
{
    public interface ISheetRepository
    {
        public Task<int> CreateAsync(Sheet sheet);
        public void AddExerciseAsync(SheetExercise sheetExercise);
        public void DisableAsync(int id);
        public void UpdateAsync();
        public Task<Sheet> GetByIdAsync(int id);
        public Task<IList<SheetExercise>> GetAllAsync(int id);
    }
}
