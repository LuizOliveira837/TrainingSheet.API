using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingSheet.Application.InputModels.InputPractitioner
{
    public class PractitionerInputUpdateModel
    {
        public PractitionerInputUpdateModel(string fullName, DateTime birthDate, string email)
        {
            FullName = fullName;
            BirthDate = birthDate;
            Email = email;
        }

        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
    }
}
