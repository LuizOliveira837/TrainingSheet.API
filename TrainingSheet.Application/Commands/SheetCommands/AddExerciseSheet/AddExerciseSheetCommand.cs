using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingSheet.Application.Commands.SheetCommands.AddExerciseSheet
{
    public class AddExerciseSheetCommand : IRequest<Unit>
    {
        public AddExerciseSheetCommand(int sheetId, int exerciseId, int series, int repetitons)
        {
            SheetId = sheetId;
            ExerciseId = exerciseId;
            Series = series;
            Repetitons = repetitons;
        }

        public int SheetId { get; set; }
        public int ExerciseId { get; set; }
        public int Series { get; set; }
        public int Repetitons { get; set; }
    }
}
