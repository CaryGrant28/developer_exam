using Developer_Exam.Models;
using Developer_Exam.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Developer_Exam.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _PersonService;

        public PersonController(IPersonService PersonService)
        {
            _PersonService = PersonService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> All()
        {
            try
            {
                return Ok(await _PersonService.All());
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse
                {
                    Status = "error",
                    Message = ex.ToString(),
                    Data = null
                });

            }
        }

        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Person model)
        {
            try
            {
                int result = await _PersonService.Save(model);

                if (result > 0)
                {
                    return Ok(new APIResponse
                    {
                        Status = "success",
                        Message = "User sucessfully created",
                        Data = null
                    });
                }
                else
                    return BadRequest(new APIResponse
                    {
                        Status = "error",
                        Message = "Failed to create user",
                        Data = null
                    });
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse
                {
                    Status = "error",
                    Message = ex.ToString(),
                    Data = null
                });
            }
        }

        [Authorize]
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] Person model)
        {
            try
            {
                int result = await _PersonService.Save(model);

                if (result > 0)
                {
                    return Ok(new APIResponse
                    {
                        Status = "success",
                        Message = "User sucessfully updated",
                        Data = null
                    });
                }
                else
                    return BadRequest(new APIResponse
                    {
                        Status = "error",
                        Message = "Failed to update user",
                        Data = null
                    });
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse
                {
                    Status = "error",
                    Message = ex.ToString(),
                    Data = null
                });
            }
        }

        [Authorize]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                int result = await _PersonService.Delete(id);

                if (result > 0)
                {
                    return Ok(new APIResponse
                    {
                        Status = "success",
                        Message = "User sucessfully deleted",
                        Data = null
                    });
                }
                else
                    return BadRequest(new APIResponse
                    {
                        Status = "error",
                        Message = "Failed to delete user",
                        Data = null
                    });
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse
                {
                    Status = "error",
                    Message = ex.ToString(),
                    Data = null
                });
            }
        }
    }

}
