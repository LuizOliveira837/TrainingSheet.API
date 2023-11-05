using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingSheet.Application.InputModels.InputExercise
{
    public class ExerciseInputCreateModel
    {
        public ExerciseInputCreateModel(string exerciseName)
        {
            ExerciseName = exerciseName;
        }

        public string ExerciseName { get; set; }
    }
}
