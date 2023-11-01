using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSheet.Application.ViewModels.PractitionerView;

namespace TrainingSheet.Application.Querys.PractitionerGetAll
{
    public class PractitionerGetAllQuery : IRequest<IList<PractitionerViewModel>>
    {
        public PractitionerGetAllQuery()
        {
            
        }
    }
}
