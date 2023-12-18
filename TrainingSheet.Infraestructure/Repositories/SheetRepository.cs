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
    public class SheetRepository : ISheetRepository
    {
        public readonly TrainingSheetDbContext _dbContext;

        public SheetRepository(TrainingSheetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async void AddExerciseAsync(SheetExercise sheetExercise)
        {
            
            await _dbContext.SheetExercises.AddAsync(sheetExercise);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> CreateAsync(Sheet sheet)
        {
            await _dbContext.Sheets.AddAsync(sheet);

            await _dbContext.SaveChangesAsync();

            return sheet.Id;
        }

        public async void DisableAsync(int id)
        {
            var sheet = await GetByIdAsync(id);

            sheet.Disable();

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IList<SheetExercise>> GetAllAsync(int id)
        {
            var sheets = await _dbContext
                .SheetExercises
                .Include(se=> se.Exercise)
                .Include(se=> se.Sheet)
                .Where(se=> se.Status == Core.Enums.StatusEntity.Active && se.Sheet.Id == id)
                .ToListAsync();


            return sheets;
        }

        public async Task<Sheet> GetByIdAsync(int id)
        {
            var sheet = await _dbContext
                .Sheets
                .Where(s => s.Id == id && s.Status == Core.Enums.StatusEntity.Active)
                .Include(s => s.Practitioner)
                .SingleAsync(s => s.Id == id);

            return sheet;

        }

        public async void UpdateAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
