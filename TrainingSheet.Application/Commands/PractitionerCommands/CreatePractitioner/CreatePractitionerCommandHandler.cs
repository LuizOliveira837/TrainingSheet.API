using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingSheet.Core.Models;
using TrainingSheet.Core.Repositories;
using TrainingSheet.Infraestructure.Persistence;

namespace TrainingSheet.Application.Commands.PractitionerCommands.CreatePractitioner
{
    public class CreatePractitionerCommandHandler : IRequestHandler<CreatePractitionerCommand, int>
    {
        private readonly IPractitionerRepository _repository;

        public CreatePractitionerCommandHandler(IPractitionerRepository repository)
        {
            _repository = repository;

        }
        public async Task<int> Handle(CreatePractitionerCommand request, CancellationToken cancellationToken)
        {
            var practitioner = new Practitioner(request.FullName, request.BirthDate, request.Email, request.Password);

            var id = await _repository.CreateAsync(practitioner);

            return id;
        }
    }
}
