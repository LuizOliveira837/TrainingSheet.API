using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingSheet.Application.InputModels.Practitioner
{
    public class PractitionerInputModel
    {
        public PractitionerInputModel(string fullName, string birthDate, string email, string password)
        {
            FullName = fullName;
            BirthDate = birthDate;
            Email = email;
            Password = password;
        }

        public string FullName { get; private set; }
        public string BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
