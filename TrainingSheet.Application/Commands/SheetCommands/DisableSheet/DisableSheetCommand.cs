using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingSheet.Application.Commands.SheetCommands.DisableSheet
{
    public class DisableSheetCommand : IRequest<Unit>
    {
        public DisableSheetCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }


    }
}
