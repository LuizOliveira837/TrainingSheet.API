using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingSheet.Core.Auth;
using TrainingSheet.Core.Models;
using TrainingSheet.Core.Repositories;
using TrainingSheet.Infraestructure.Auth;
using TrainingSheet.Infraestructure.Persistence;

namespace TrainingSheet.Application.Commands.PractitionerCommands.CreatePractitioner
{
    public class CreatePractitionerCommandHandler : IRequestHandler<CreatePractitionerCommand, int>
    {
        private readonly IPractitionerRepository _repository;
        private readonly IAuthService _authService;

        public CreatePractitionerCommandHandler(IPractitionerRepository repository, IAuthService authService)
        {
            _repository = repository;
            _authService = authService;

        }
        public async Task<int> Handle(CreatePractitionerCommand request, CancellationToken cancellationToken)
        {
            var passwordEncrypt = _authService.EncryptPassword(request.Password);
            var practitioner = new Practitioner(request.FullName, request.BirthDate, request.Email, passwordEncrypt);

            var id = await _repository.CreateAsync(practitioner);

            return id;
        }
    }
}
