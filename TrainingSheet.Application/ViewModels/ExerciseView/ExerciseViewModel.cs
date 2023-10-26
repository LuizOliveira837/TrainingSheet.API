using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSheet.Core.Enums;

namespace TrainingSheet.Application.ViewModels.Exercise
{
    public class ExerciseViewModel
    {
        public ExerciseViewModel(int id, string exerciseName)
        {
            Id = id;
            ExerciseName = exerciseName;
        }

        public int Id { get; set; }
        public string ExerciseName { get; set; }
    }
}
