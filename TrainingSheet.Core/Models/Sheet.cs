using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingSheet.Core.Models
{
    public class Sheet : BaseEntity
    {
        public Sheet(string sheetName, int practitionerId, DateTime startedIn, DateTime finishIn)
            : base()
        {
            SheetName = sheetName;
            PractitionerId = practitionerId;
            StartedIn = startedIn;
            FinishIn = finishIn;

        }

        public string SheetName { get; set; }
        public int PractitionerId { get; set; }
        public virtual Practitioner Practitioner { get; set; }
        public DateTime StartedIn { get; set; }
        public DateTime FinishIn { get; set; }

    }
}
