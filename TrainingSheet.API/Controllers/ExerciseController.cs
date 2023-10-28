using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TrainingSheet.Application.Commands.ExerciseCommands.CreateExercise;
using TrainingSheet.Application.Commands.ExerciseCommands.DisableExercise;
using TrainingSheet.Application.Commands.ExerciseCommands.UpdateExercise;
using TrainingSheet.Application.InputModels.Exercise;
using TrainingSheet.Application.Querys.ExerciseGetAll;
using TrainingSheet.Application.Querys.ExerciseGetById;
using TrainingSheet.Application.Services.Interface;
using TrainingSheet.Application.ViewModels.Exercise;

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
