using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MusicStreaming.Streaming.Application;

namespace MusicStreaming.Streaming.API.Controllers
{   
    
        [Route("api/[controller]")]
        [ApiController]
        public class PlanoController : ControllerBase
        {
            private PlanoService service { get; set; }

            public PlanoController()
            {
                this.service = new PlanoService();
            }

            [HttpGet("{id}")]
            public IActionResult GetPlano(Guid id)
            {
                var result = this.service.ObterPlano(id);

                if (result == null)
                    return NotFound();

                return Ok(result);

            }
        }
}
