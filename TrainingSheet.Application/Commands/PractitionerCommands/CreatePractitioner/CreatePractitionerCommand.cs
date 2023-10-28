using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingSheet.Application.Commands.PractitionerCommands.CreatePractitioner
{
    public class CreatePractitionerCommand : IRequest<int>
    {
        public CreatePractitionerCommand(string fullName, DateTime birthDate, string email, string password)
        {
            FullName = fullName;
            BirthDate = birthDate;
            Email = email;
            Password = password;
        }

        public string FullName { get; private set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }


}
