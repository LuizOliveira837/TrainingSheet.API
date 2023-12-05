using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSheet.Core.Models;

namespace TrainingSheet.Core.Repositories
{
    public interface IPractitionerRepository
    {
        public Task<int> CreateAsync(Practitioner practitioner);
        public void DisableAsync(int id);
        public void UpdateAsync();
        public IList<Practitioner> GetAllAsync();
        public Task<Practitioner> GetByIdAsync(int id);
        public Task<Practitioner> GetByEmailAndPassword(string email, string password);

    }
}
