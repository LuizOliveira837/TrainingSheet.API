using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingSheet.Application.Commands.PractitionerCommands.CreatePractitioner;
using TrainingSheet.Application.Commands.PractitionerCommands.DisablePractitioner;
using TrainingSheet.Application.Commands.PractitionerCommands.LoginPractitioner;
using TrainingSheet.Application.Commands.PractitionerCommands.UpdatePractitioner;
using TrainingSheet.Application.InputModels.InputPractitioner;
using TrainingSheet.Application.Querys.PractitionerGetAll;
using TrainingSheet.Application.Querys.PractitionerGetById;
using TrainingSheet.Application.Validators;
using TrainingSheet.Application.ViewModels.PractitionerView;
using TrainingSheet.Core.Error;

namespace TrainingSheet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PractitionerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PractitionerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IList<PractitionerViewModel>>> GetAll()
        {
            var command = new PractitionerGetAllQuery();

            var practitioners = await _mediator.Send(command);

            return Ok(practitioners);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PractitionerViewModel>> GetById([FromRoute] int id)
        {
            var commad = new PractitionerGetByIdQuery(id);

            var pratitioner = await _mediator.Send(commad);

            return Ok(pratitioner);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody] CreatePractitionerCommand command)
        {

            var practitionerId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = practitionerId }, command);

        }

        [HttpPut("{id}/update")]
        public async Task<ActionResult> Put([FromRoute] int id, [FromBody] UpdatePractitionerCommand command)
        {

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPatch("{id}/disable")]
        public async Task<ActionResult> Disable(int id)
        {

            var command = new DisablePractitionerCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("Login")]

        public async Task<ActionResult> Login(LoginPractitionerCommand command)
        {
            var token = await _mediator.Send(command);

            return Ok(new
            {
                Token = token,
                Email = command.Email
            });
        }



    }
}
