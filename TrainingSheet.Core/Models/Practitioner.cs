using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSheet.Core.Enums;

namespace TrainingSheet.Core.Models
{
    public class Practitioner: BaseEntity
    {
        public Practitioner(string fullName, DateTime birthDate, string email, string password) 
            :base()
        {
            FullName = fullName;
            BirthDate = birthDate;
            Email = email;
            Password = password;
        }

        public string FullName { get; private set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public void Update(string fullName, DateTime birthdate, string email)
        {
            if (this.Status == StatusEntity.inactive) return;

            FullName = fullName;
            BirthDate = birthdate;
            Email = email;
        }


    }
}
