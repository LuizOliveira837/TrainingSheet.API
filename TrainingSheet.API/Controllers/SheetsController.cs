using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TrainingSheet.Application.Commands.SheetCommands.AddExerciseSheet;
using TrainingSheet.Application.Commands.SheetCommands.DisableSheet;
using TrainingSheet.Application.Commands.TrainingSheetCommands;
using TrainingSheet.Application.InputModels.Sheet;
using TrainingSheet.Application.InputModels.TrainingSheet;
using TrainingSheet.Application.Querys.SheetGetById;

namespace TrainingSheet.API.Controllers
{
    [Route("api/[controller]")]
    public class SheetsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SheetsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var query = new SheetGetByIdQuery(id);

            var sheet = await _mediator.Send(query);

            return Ok(sheet);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SheetInputModel input)
        {
            var command = new CreateSheetCommand(input.SheetName, input.PractitionerId, input.StartedIn, input.FinishIn);

            var id = await _mediator.Send(command);

            return Ok(id);
        }

        [HttpPost("{id}/Add-exercise")]
        public async Task<ActionResult> AddExercise([FromRoute] int id, [FromBody] SheetAddExerciseInputModel input)
        {
            var command = new AddExerciseSheetCommand(id, input.ExerciseId, input.Series, input.Repetitons);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPatch("{id}/Disable")]
        public async Task<ActionResult> Disable([FromRoute] int id)
        {
            var command = new DisableSheetCommand(id);

            await _mediator.Send(command);
            return Ok();
        }
    }
}
