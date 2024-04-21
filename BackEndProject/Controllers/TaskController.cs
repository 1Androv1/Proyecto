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
    [Route("api/saveTask")]
    public class TaskController(ITaskService taskService) : ControllerBase
    {
        [HttpPost, Route("")]
        [SwaggerOperation(
            Summary = "Create a new Task in Task table.",
            OperationId = "SaveNewTask",
            Tags = ["Task"]
        )]
        public async Task<IActionResult> SaveNewTask([FromBody] TaksDto taksDto)
        {
            try
            {
                await taskService.SaveAnNewTask(taksDto);

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
        
        [HttpPut, Route("")]
        [SwaggerOperation(
            Summary = "Update an user.",
            Tags = ["Task"]
        )]
       
        public async Task<IActionResult> UpdateTask([FromBody] TaskUpdateDto taskUpdateDto)
        {
            try
            {
                await taskService.UpdateATask(taskUpdateDto);
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
    }
}

    
