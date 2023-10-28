using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrainingSheet.Application.Commands.PractitionerCommands.CreatePractitioner;
using TrainingSheet.Application.InputModels.Practitioner;
using TrainingSheet.Application.Querys.PractitionerGetAll;
using TrainingSheet.Application.Querys.PractitionerGetById;
using TrainingSheet.Application.ViewModels.Exercise;
using TrainingSheet.Application.ViewModels.Practitioner;

namespace TrainingSheet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

            var pratitioner = _mediator.Send(commad);

            return Ok(pratitioner);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PractitionerInputModel input)
        {
            var command = new CreatePractitionerCommand(input.FullName, input.BirthDate, input.Email, input.Password);

            var practitionerId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = practitionerId }, command);

        }

        [HttpPut("{id}/update")]
        public ActionResult Put(int id)
        {
            return Ok("Ola");
        }

        [HttpPatch("{id}/disable")]
        public ActionResult Disable([FromRoute] int id)
        {
            return Ok("Ola");
        }



    }
}
