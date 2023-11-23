using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingSheet.Application.ViewModels.PractitionerView;
using TrainingSheet.Core.Repositories;
using TrainingSheet.Infraestructure.Persistence;

namespace TrainingSheet.Application.Querys.PractitionerGetById
{
    public class PractitionerGetByIdQueryHandler : IRequestHandler<PractitionerGetByIdQuery, PractitionerViewModel>
    {
        private readonly IPractitionerRepository _repository;

        public PractitionerGetByIdQueryHandler(IPractitionerRepository repository)
        {
            _repository = repository;
        }
        public async Task<PractitionerViewModel> Handle(PractitionerGetByIdQuery request, CancellationToken cancellationToken)
        {
            var practitioner = await _repository.GetByIdAsync(request.Id);

            return new PractitionerViewModel(practitioner.Name, practitioner.BirthDate, practitioner.Email);
        }
    }
}
