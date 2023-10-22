using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingSheet.Core.Models
{
    public class Exercise : BaseEntity
    {
        public Exercise(string exerciseName) 
            :base()
        {
            ExerciseName = exerciseName;
        }

        public string ExerciseName { get; set; }




    }
}
