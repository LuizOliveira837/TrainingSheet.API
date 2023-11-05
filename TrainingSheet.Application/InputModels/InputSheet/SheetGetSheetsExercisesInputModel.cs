using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingSheet.Application.InputModels.InputSheet
{
    public class SheetGetSheetsExercisesInputModel
    {
        public SheetGetSheetsExercisesInputModel(int sheetId,int practitionerId)
        {
            PractitionerId = practitionerId;
            SheetId = sheetId;
        }

        public int PractitionerId { get; set; }
        public int SheetId { get; set; }
    }
}
