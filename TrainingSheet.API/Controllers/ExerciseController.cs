using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TrainingSheet.Application.Commands;
using TrainingSheet.Application.Commands.CreateExercise;
using TrainingSheet.Application.Commands.DeleteExercise;
using TrainingSheet.Application.Commands.UpdateExercise;
using TrainingSheet.Application.InputModels.Exercise;
using TrainingSheet.Application.Services.Interface;
using TrainingSheet.Core.Models;

namespace TrainingSheet.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExerciseController : ControllerBase
    {
        public readonly IExerciseService _service;
        public readonly IMediator _mediator;
        public ExerciseController(IExerciseService service, IMediator mediator)
        {
            _service = service;
            _mediator = mediator;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var exercises = _service.GetAll();

            return Ok(exercises);
        }

        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] int id)
        {
            if (id == null) return BadRequest();

            var exerciseViewModel = _service.GetById(id);

            return Ok(exerciseViewModel);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] InputCreateModel inputCreateModel)
        {
            var command = new CreateExerciseCommand(inputCreateModel.ExerciseName);

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, inputCreateModel);

        }

        [HttpPatch("{id}/disable")]
        public async Task<ActionResult> Disable([FromRoute] int id)
        {
            var command = new DisableExerciseCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] InputUpdateModel input)
        {

            var command = new UpdateExerciseCommand(id, input.ExerciseName);

            await _mediator.Send(command);

            return NoContent();


        }

    }
}
