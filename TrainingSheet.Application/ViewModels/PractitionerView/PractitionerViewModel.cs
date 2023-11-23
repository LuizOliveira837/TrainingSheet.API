using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSheet.Core.Models;

namespace TrainingSheet.Application.ViewModels.PractitionerView
{
    public class PractitionerViewModel
    {
        public PractitionerViewModel(Name name, DateTime birthDate, string email)
        {
            Name = name;
            BirthDate = birthDate;
            Email = email;
        }

        public Name Name { get; private set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
    }
}
