using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSheet.Application.ViewModels.ExerciseView;
using TrainingSheet.Core.Models;

namespace TrainingSheet.Application.ViewModels.SheetView
{
    public class SheetExerciseViewModel
    {
        public SheetExerciseViewModel(String exerciseName, int series, int repetitons)
        {
            ExerciseName = exerciseName;
            Series = series;
            Repetitons = repetitons;
        }

        public String ExerciseName { get; set; }
        public int Series { get; set; }
        public int Repetitons { get; set; }
    }
}
