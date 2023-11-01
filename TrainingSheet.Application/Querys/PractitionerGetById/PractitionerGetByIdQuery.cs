using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSheet.Application.ViewModels.PractitionerView;

namespace TrainingSheet.Application.Querys.PractitionerGetById
{
    public class PractitionerGetByIdQuery : IRequest<PractitionerViewModel>
    {
        public PractitionerGetByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
