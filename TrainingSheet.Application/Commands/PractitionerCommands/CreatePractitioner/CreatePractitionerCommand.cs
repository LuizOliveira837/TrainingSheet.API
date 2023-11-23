using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSheet.Core.Models;

namespace TrainingSheet.Application.Commands.PractitionerCommands.CreatePractitioner
{
    public class CreatePractitionerCommand : IRequest<int>
    {
        public CreatePractitionerCommand(Name name, DateTime birthDate, string email, string password)
        {
            Name = name;
            BirthDate = birthDate;
            Email = email;
            Password = password;
        }

        public Name Name { get; private set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }


}
