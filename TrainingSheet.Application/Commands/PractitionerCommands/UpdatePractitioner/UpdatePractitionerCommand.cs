using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingSheet.Application.Commands.PractitionerCommands.UpdatePractitioner
{
    public class UpdatePractitionerCommand : IRequest<Unit>
    {
        public UpdatePractitionerCommand(int id, string fullName, DateTime birthDate, string email)
        {
            Id = id;
            FullName = fullName;
            BirthDate = birthDate;
            Email = email;
        }

        public int Id { get; private set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
    }
}
