using System.ComponentModel.DataAnnotations;
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
            Tags = ["Alimentos"]
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
        
        [HttpPost, Route("saveAlimentos")]
        [SwaggerOperation(
            Summary = "Create a new Alimento in Alimentos table.",
            OperationId = "SaveNewAlimentos",
            Tags = ["Alimentos"]
        )]
        public async Task<IActionResult> SaveNewAlimentos([FromBody] AlimentosDto alimentosDto)
        {
            try
            {
                await alimentosService.SaveAnNewAlimentos(alimentosDto);

                return Created(string.Empty, new BasicReturnCreatedDto());
            }
            catch (ValidationException ex)
            {
                return BadRequest(HelperError.GetErrorAndInnerError(ex));
            }
            catch (Exception e)
            {
                return StatusCode(500, HelperError.GetErrorAndInnerError(e));
            }
        }

        [HttpPost, Route("updateAlimentos")]
        [SwaggerOperation(
            Summary = "Update an Alimentos.",
            Tags = ["Task"]
        )]
       
        public async Task<IActionResult> UpdateTask([FromBody] AlimentosUpdateDto alimentosUpdateDto)
        {
            try
            {
                await alimentosService.UpdateAlimentos(alimentosUpdateDto);
                return Created(string.Empty, new BasicReturnCreatedDto());
            }
            catch (ValidationException ex)
            {
                return BadRequest(HelperError.GetErrorAndInnerError(ex));
            }
            catch (Exception e)
            {
                return StatusCode(500, HelperError.GetErrorAndInnerError(e));
            }
        }
        
        [HttpGet, Route("deleteAlimento/{id}")]
        [SwaggerOperation(
            Summary = "Delete an Alimento.",
            Tags = ["Task"]
        )]
        public async Task<IActionResult> DeleteTask(int id)
        {
            try
            {
                var alimentos = await alimentosService.GetDetailAlimentos(id);

                if (alimentos == null)
                    throw new InvalidOperationException($"No se encontró ningun Alimento con idAlimento = {alimentos!.IdAlimentos}.");

                await alimentosService.DeletedAlimentosId(id);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, HelperError.GetErrorAndInnerError(e));
            }
        }
    } 
}

