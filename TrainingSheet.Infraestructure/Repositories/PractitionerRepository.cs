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
    public class PractitionerRepository : IPractitionerRepository
    {

        public readonly TrainingSheetDbContext _dbContext;

        public PractitionerRepository(TrainingSheetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateAsync(Practitioner practitioner)
        {
            await _dbContext.Practitioners.AddAsync(practitioner);

            await _dbContext.SaveChangesAsync();

            return practitioner.Id;
        }

        public async void DisableAsync(int id)
        {
            var practitioner = await GetByIdAsync(id);

            practitioner.Disable();

            await _dbContext.SaveChangesAsync();
        }

        public IList<Practitioner> GetAllAsync()
        {
            var practitioners = _dbContext
                .Practitioners
                .Where(p => p.Status == Core.Enums.StatusEntity.Active)
                .ToList();

            return practitioners;
        }

        public async Task<Practitioner> GetByIdAsync(int id)
        {
            var practitioner = await _dbContext
                .Practitioners
                .SingleAsync(p => p.Id == id);

            return practitioner;
        }

        public void UpdateAsync()
        {
            _dbContext.SaveChanges();
        }
    }
}
