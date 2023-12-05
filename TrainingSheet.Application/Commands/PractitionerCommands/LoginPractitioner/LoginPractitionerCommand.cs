using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingSheet.Application.Commands.PractitionerCommands.LoginPractitioner
{
    public class LoginPractitionerCommand : IRequest<string>
    {
        public LoginPractitionerCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
