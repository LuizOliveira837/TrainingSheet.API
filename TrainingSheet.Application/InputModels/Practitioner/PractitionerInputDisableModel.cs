using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingSheet.Application.InputModels.Practitioner
{
    public class PractitionerInputDisableModel
    {
        public PractitionerInputDisableModel(int id)
        {
            Id = id;
        }

        public int Id { get; set; }


    }
}
