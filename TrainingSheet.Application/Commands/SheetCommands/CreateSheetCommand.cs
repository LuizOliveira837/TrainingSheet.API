﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingSheet.Application.Commands.TrainingSheetCommands
{
    public class CreateSheetCommand : IRequest<int>
    {
        public CreateSheetCommand(string sheetName, int practitionerId, DateTime startedIn, DateTime finishIn)
        {
            SheetName = sheetName;
            PractitionerId = practitionerId;
            StartedIn = startedIn;
            FinishIn = finishIn;
        }

        public string SheetName { get; set; }
        public int PractitionerId { get; set; }
        public DateTime StartedIn { get; set; }
        public DateTime FinishIn { get; set; }
    }
}
