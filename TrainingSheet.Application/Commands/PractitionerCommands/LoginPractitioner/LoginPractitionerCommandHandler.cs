using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingSheet.Core.Auth;
using TrainingSheet.Core.Repositories;

namespace TrainingSheet.Application.Commands.PractitionerCommands.LoginPractitioner
{
    public class LoginPractitionerCommandHandler : IRequestHandler<LoginPractitionerCommand, string>
    {
        public readonly IPractitionerRepository _repository;

        private readonly IAuthService _service;

        public LoginPractitionerCommandHandler(IPractitionerRepository repository, IAuthService service)
        {
            _repository = repository;
            _service = service;
        }
        public async Task<string> Handle(LoginPractitionerCommand request, CancellationToken cancellationToken)
        {
            var passwordEncrypt = _service.EncryptPassword(request.Password);

            var practitoner = await _repository.GetByEmailAndPassword(request.Email, passwordEncrypt);

            if (practitoner is null) throw new NullReferenceException();

            return _service.GenerationToken(practitoner.Email);
        }
    }
}
