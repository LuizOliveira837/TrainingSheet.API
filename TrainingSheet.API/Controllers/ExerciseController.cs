using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using TrainingSheet.Application.Commands.ExerciseCommands.CreateExercise;
using TrainingSheet.Application.Commands.ExerciseCommands.DisableExercise;
using TrainingSheet.Application.Commands.ExerciseCommands.UpdateExercise;
using TrainingSheet.Application.InputModels.InputExercise;
using TrainingSheet.Application.Querys.ExerciseGetAll;
using TrainingSheet.Application.Querys.ExerciseGetById;
using TrainingSheet.Application.Validators;
using TrainingSheet.Application.ViewModels.ExerciseView;
using TrainingSheet.Core.Error;

namespace TrainingSheet.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExerciseController : ControllerBase
    {
        public readonly IMediator _mediator;

        public ExerciseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var command = new ExerciseGetAllQuery();
            var exercises = await _mediator.Send(command);

            return Ok(exercises);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExerciseViewModel>> GetById([FromRoute] int id)
        {
            var command = new ExerciseGetByIdQuery(id);

            var exerciseViewModel = await _mediator.Send(command);

            return Ok(exerciseViewModel);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ExerciseInputCreateModel input)
        {
            ExerciseInputModelValidator validator = new();
          
            var resultValidator = await validator.ValidateAsync(input);

            if (!resultValidator.IsValid) {

                var messageError = resultValidator
                .Errors
                    .Select(e => new MessageError(e.ErrorCode, e.ErrorMessage));

                return BadRequest(messageError);
            }

            var command = new CreateExerciseCommand(input.ExerciseName);

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, input);

        }

        [HttpPatch("{id}/disable")]
        public async Task<ActionResult> Disable([FromRoute] int id)
        {
            var command = new DisableExerciseCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] ExerciseInputCreateModel input)
        {
            ExerciseInputModelValidator validator = new();

            var resultValidator = await validator.ValidateAsync(input);

            if (!resultValidator.IsValid)
            {

                var messageError = resultValidator
                .Errors
                    .Select(e => new MessageError(e.ErrorCode, e.ErrorMessage));

                return BadRequest(messageError);
            }

            var command = new UpdateExerciseCommand(id, input.ExerciseName);

            await _mediator.Send(command);

            return NoContent();
        }

    }
}
