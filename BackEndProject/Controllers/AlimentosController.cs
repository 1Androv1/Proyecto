using Dtos;
using Dtos.Returns;
using Helpers.Errors;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BackEndProject.Controllers
{
    [ApiController]
    [Route("api")]
    public class AlimentosController(IAlimentosService alimentosService): ControllerBase
    {
        [HttpGet, Route("allAlimentos")]
        [SwaggerOperation(
            Description = "This endpoint is only for tests.",
            OperationId = "GetTheAlimentos",
            Tags = ["Task"]
        )]
        public async Task<IActionResult> GetTheAlimentos()
        {
            try
            {
                return Ok(await alimentosService.GetAllAlimentos());
            }
            catch (Exception e)
            {
                return StatusCode(500, HelperError.GetErrorAndInnerError(e));
            }
        }
    } 
}

