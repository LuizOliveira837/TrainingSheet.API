using Microsoft.AspNetCore.Mvc;
using TrainingSheet.Application.InputModels.Practitioner;

namespace TrainingSheet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PractitionerController : ControllerBase
    {
        public PractitionerController()
        {

        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok("Ola");
        }

        [HttpGet("{id}")]
        public ActionResult GetById()
        {
            return Ok("Ola");
        }

        [HttpPost]
        public ActionResult Post([FromBody] PractitionerInputModel input)
        {
            return Ok(input);
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
