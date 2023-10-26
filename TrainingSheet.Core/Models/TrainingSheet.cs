using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingSheet.Core.Models
{
    public class TrainingSheet : BaseEntity
    {
        public TrainingSheet(string trainingSheetName, int studentId, DateTime startedIn, DateTime finishIn)
            :base()
        {
            TrainingSheetName = trainingSheetName;
            StudentId = studentId;
            StartedIn = startedIn;
            FinishIn = finishIn;

        }

        public string TrainingSheetName { get; set; }
        public int StudentId { get; set; }
        public Practitioner Student { get; set; }
        public DateTime StartedIn { get; set; }
        public DateTime FinishIn { get; set; }

    }
}
