using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingSheet.Application.Validators;
using TrainingSheet.Core.Error;

namespace TrainingSheet.Application.Commands.ExerciseCommands.UpdateExercise
{
    public class UpdateExerciseCommandPreHandler : IRequestPreProcessor<UpdateExerciseCommand>
    {

        public async Task Process(UpdateExerciseCommand request, CancellationToken cancellationToken)
        {
            ExerciseUpdateModelValidator validator = new();

            var resultValidator = await validator.ValidateAsync(request);

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
