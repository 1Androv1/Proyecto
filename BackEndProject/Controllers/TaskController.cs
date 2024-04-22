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
    public class TaskController(ITaskService taskService) : ControllerBase
    {
        [HttpGet, Route("allTask")]
        [SwaggerOperation(
            Description = "This endpoint is only for tests.",
            OperationId = "GetTheTask",
            Tags = ["Task"]
        )]
        public async Task<IActionResult> GetTheUsers()
        {
            try
            {
                return Ok(await taskService.GetAllTask());
            }
            catch (Exception e)
            {
                return StatusCode(500, HelperError.GetErrorAndInnerError(e));
            }
        }

        [HttpPost, Route("saveTask")]
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
        
        [HttpPost, Route("updateTask")]
        [SwaggerOperation(
            Summary = "Update an Task.",
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
        
        [HttpGet, Route("deleteTask/{id}")]
        [SwaggerOperation(
            Summary = "Delete an Task.",
            Tags = ["Task"]
        )]
        public async Task<IActionResult> DeleteTask(int id)
        {
            try
            {
                var task = await taskService.GetDetailTask(id);

                if (task == null)
                    throw new InvalidOperationException($"No se encontró ninguna tarea con IdTask = {task!.IdTask}.");

                await taskService.DeletedTaskId(id);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, HelperError.GetErrorAndInnerError(e));
            }
        }
    }
}

    
