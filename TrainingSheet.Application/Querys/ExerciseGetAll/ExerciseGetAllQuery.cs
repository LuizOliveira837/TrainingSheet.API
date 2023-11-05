using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSheet.Application.ViewModels.ExerciseView;

namespace TrainingSheet.Application.Querys.ExerciseGetAll
{
    public class ExerciseGetAllQuery : IRequest<IList<ExerciseViewModel>>
    {
        public ExerciseGetAllQuery()
        {
        }
    }
}
