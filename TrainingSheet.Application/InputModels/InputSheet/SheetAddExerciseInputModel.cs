using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingSheet.Application.InputModels.InputSheet
{
    public class SheetAddExerciseInputModel
    {
        public SheetAddExerciseInputModel(int exerciseId, int series, int repetitons)
        {
            ExerciseId = exerciseId;
            Series = series;
            Repetitons = repetitons;
        }

        public int ExerciseId { get; set; }
        public int Series { get; set; }
        public int Repetitons { get; set; }
    }
}
