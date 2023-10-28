using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingSheet.Application.ViewModels.Practitioner
{
    public class PractitionerViewModel
    {
        public PractitionerViewModel(string fullName, DateTime birthDate, string email)
        {
            FullName = fullName;
            BirthDate = birthDate;
            Email = email;
        }

        public string FullName { get; private set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
    }
}
