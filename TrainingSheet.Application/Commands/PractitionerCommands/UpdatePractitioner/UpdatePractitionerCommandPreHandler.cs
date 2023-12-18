using FluentValidation;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingSheet.Application.Validators;
using TrainingSheet.Core.Error;

namespace TrainingSheet.Application.Commands.PractitionerCommands.UpdatePractitioner
{

    public class UpdatePractitionerCommandPreHandler : IRequestPreProcessor<UpdatePractitionerCommand>
    {
        public readonly IValidator<UpdatePractitionerCommand> _validator;
        public UpdatePractitionerCommandPreHandler(IValidator<UpdatePractitionerCommand> validator)
        {
            _validator = validator;
        }
        public async Task Process(UpdatePractitionerCommand request, CancellationToken cancellationToken)
        {

            var resultValidator = await _validator.ValidateAsync(request);

            if (!resultValidator.IsValid)
            {
                var messageError = resultValidator
                    .Errors
                    .Select(e => new MessageError(e.ErrorCode, e.ErrorMessage));

                throw new Exception(messageError.ToString());
            }


        }
    }
}
