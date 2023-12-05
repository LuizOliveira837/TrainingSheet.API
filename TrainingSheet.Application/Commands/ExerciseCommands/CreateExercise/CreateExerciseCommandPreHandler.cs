﻿using FluentValidation;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingSheet.Application.Validators;
using TrainingSheet.Core.Error;

namespace TrainingSheet.Application.Commands.ExerciseCommands.CreateExercise
{
    internal class CreateExerciseCommandPreHandler : IRequestPreProcessor<CreateExerciseCommand>
    {
        public async Task Process(CreateExerciseCommand request, CancellationToken cancellationToken)
        {
            ExerciseInputModelValidator validator = new();

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
