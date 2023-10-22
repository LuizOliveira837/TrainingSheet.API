using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingSheet.Application.InputModels.Exercise
{
    public class InputDeleteModel
    {
        public InputDeleteModel(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }

        
    }
}
