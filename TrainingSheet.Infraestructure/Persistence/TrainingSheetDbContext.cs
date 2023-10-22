using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSheet.Core.Models;

namespace TrainingSheet.Infraestructure.Persistence
{
    public class TrainingSheetDbContext : DbContext
    {
        public DbSet<Exercise> Exercises { get; set; }

        public TrainingSheetDbContext(DbContextOptions<TrainingSheetDbContext> options)
            : base(options)
        {

        }
    }
}
