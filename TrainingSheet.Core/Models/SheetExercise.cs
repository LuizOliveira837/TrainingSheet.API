using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingSheet.Core.Models
{
    public class SheetExercise : BaseEntity
    {
        public SheetExercise(int sheetId,int exerciseId, int series, int repetitons)
        {
            SheetId = sheetId;
            ExerciseId = exerciseId;
            Series = series;
            Repetitons = repetitons;
        }

        public virtual Sheet Sheet { get; set; }
        public int SheetId { get; set; }
        public virtual Exercise Exercise { get; set; }
        public int ExerciseId { get; set; }
        public int Series { get; set; }
        public int Repetitons { get; set; }
    }
}
