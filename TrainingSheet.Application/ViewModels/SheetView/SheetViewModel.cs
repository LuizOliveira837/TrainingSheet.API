using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSheet.Core.Models;

namespace TrainingSheet.Application.ViewModels.SheetView
{
    public class SheetViewModel
    {
        public SheetViewModel(string sheetName, Practitioner practitioner, DateTime startedIn, DateTime finishIn)
        {
            SheetName = sheetName;
            Practitioner = practitioner;
            StartedIn = startedIn;
            FinishIn = finishIn;
        }

        public string SheetName { get; set; }
        public Practitioner Practitioner { get; set; }
        public DateTime StartedIn { get; set; }
        public DateTime FinishIn { get; set; }
    }
}
