using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TrainingSheet.Application.Commands.SheetCommands.AddExerciseSheet;
using TrainingSheet.Application.Commands.SheetCommands.DisableSheet;
using TrainingSheet.Application.Commands.TrainingSheetCommands;
using TrainingSheet.Application.InputModels.InputSheet;
using TrainingSheet.Application.Querys.SheetGetById;
using TrainingSheet.Application.Querys.SheetGetSheetsExercises;
using TrainingSheet.Application.Validators;
using TrainingSheet.Core.Error;

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


        [HttpGet("sheet-exercises/{PractitionerId}/{SheetId}")]
        public async Task<ActionResult> GetSheetsExercises(int PractitionerId, int SheetId)
        {
            var query = new SheetGetSheetsExercisesQuery(SheetId, PractitionerId);

            await _mediator.Send(query);

            var sheet = await _mediator.Send(query);

            return Ok(sheet);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SheetInputModel input)
        {
            SheetInputModelValidate validator = new();
            var resultValidator = validator.Validate(input);

            if (!resultValidator.IsValid)
            {
                var messageError = resultValidator
                    .Errors
                        .Select(e => new MessageError(e.ErrorCode, e.ErrorMessage));

                return BadRequest(messageError);
            }

            var command = new CreateSheetCommand(input.SheetName, input.PractitionerId, input.StartedIn, input.FinishIn);

            var id = await _mediator.Send(command);

            return Ok(id);
        }

        [HttpPost("{SheetId}/Add-exercise")]
        public async Task<ActionResult> AddExercise([FromRoute] int SheetId, [FromBody] SheetAddExerciseInputModel input)
        {
            SheetAddExerciseInputModelValidator validate = new();

            var resultValidator = validate.Validate(input);

            if (!resultValidator.IsValid)
            {
                var messageError = resultValidator
                  .Errors
                      .Select(e => new MessageError(e.ErrorCode, e.ErrorMessage));

                return BadRequest(messageError);

            }

            var command = new AddExerciseSheetCommand(SheetId, input.ExerciseId, input.Series, input.Repetitons);

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
