using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingSheet.Application.ViewModels.PractitionerView;
using TrainingSheet.Core.Repositories;
using TrainingSheet.Infraestructure.Persistence;

namespace TrainingSheet.Application.Querys.PractitionerGetAll
{
    public class PractitionerGetAllQueryHandler : IRequestHandler<PractitionerGetAllQuery, IList<PractitionerViewModel>>
    {
        public readonly IPractitionerRepository _repository;

        public PractitionerGetAllQueryHandler(IPractitionerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<PractitionerViewModel>> Handle(PractitionerGetAllQuery request, CancellationToken cancellationToken)
        {
            var practitioners = _repository
                .GetAllAsync();

            return practitioners
                .Select(P => new PractitionerViewModel(P.FullName, P.BirthDate, P.Email))
                .ToList();

        }
    }
}
