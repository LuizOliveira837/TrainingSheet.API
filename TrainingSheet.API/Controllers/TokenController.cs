using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace TrainingSheet.API.Controllers
{
    [ApiController]
    [Route("api/geraToken")]
    public class TokenController : ControllerBase
    {
       // public JwtTokenGenerator _jwtTokenGenerator { get; set; }
        public TokenController(IConfiguration configuration)
        {
           // _jwtTokenGenerator = new JwtTokenGenerator(configuration);
        }

        [HttpGet()]
        public void Get()
        {
            //return Ok(_jwtTokenGenerator.GenerationToken("Luiz"));
        }
    }
}
