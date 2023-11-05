using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSheet.Application.ViewModels.ExerciseView;

namespace TrainingSheet.Application.Querys.ExerciseGetById
{
    public class ExerciseGetByIdQuery : IRequest<ExerciseViewModel>
    {
        public ExerciseGetByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }


    }
}
