using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingSheet.Core.Repositories;
using TrainingSheet.Infraestructure.Persistence;

namespace TrainingSheet.Application.Commands.PractitionerCommands.UpdatePractitioner
{
    public class UpdatePractitionerCommandHandler : IRequestHandler<UpdatePractitionerCommand, Unit>
    {
        public readonly IPractitionerRepository _repository;
        public UpdatePractitionerCommandHandler(IPractitionerRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(UpdatePractitionerCommand request, CancellationToken cancellationToken)
        {
            var practitioner = await _repository
                .GetByIdAsync(request.Id);

            practitioner.Update(request.Name, request.BirthDate, request.Email);

            _repository.UpdateAsync();

            return Unit.Value;
        }
    }
}
