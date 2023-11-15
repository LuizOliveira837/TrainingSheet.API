using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingSheet.Application.Commands.PractitionerCommands.DisablePractitioner;
using TrainingSheet.Core.Repositories;
using TrainingSheet.Infraestructure.Persistence;

namespace TrainingSheet.Application.Commands.PractitionerCommands.DeletePractitioner
{
    public class DisablePractitionerCommandHandler : IRequestHandler<DisablePractitionerCommand, Unit>
    {
        private readonly IPractitionerRepository _repository;

        public DisablePractitionerCommandHandler(IPractitionerRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DisablePractitionerCommand request, CancellationToken cancellationToken)
        {
            _repository.DisableAsync(request.Id);

            return Unit.Value;
        }
    }
}