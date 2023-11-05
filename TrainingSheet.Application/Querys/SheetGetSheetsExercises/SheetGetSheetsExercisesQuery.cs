using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSheet.Application.ViewModels.ExerciseView;
using TrainingSheet.Application.ViewModels.SheetView;

namespace TrainingSheet.Application.Querys.SheetGetSheetsExercises
{
    public class SheetGetSheetsExercisesQuery : IRequest<IList<SheetExerciseViewModel>>
    {
        public SheetGetSheetsExercisesQuery(int practitionerId, int sheetId)
        {
            PractitionerId = practitionerId;
            SheetId = sheetId;
        }

        public int PractitionerId { get; set; }
        public int SheetId { get; set; }
    }
}
