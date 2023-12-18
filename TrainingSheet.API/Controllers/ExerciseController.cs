using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
       // [Authorize]

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


        //[Authorize]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateExerciseCommand command)
        {
         
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);

        }

        [HttpPatch("{id}/disable")]
        public async Task<ActionResult> Disable([FromRoute] int id)
        {
            var command = new DisableExerciseCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] CreateExerciseCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

    }
}
