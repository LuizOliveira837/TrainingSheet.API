using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingSheet.Application.Commands.PractitionerCommands.DisablePractitioner
{
    public class DisablePractitionerCommand : IRequest<Unit>
    {
        public DisablePractitionerCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
