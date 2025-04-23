using AtlasConnectionApiCode.Dto;
using AtlasConnectionApiCode.Dto.Request;
using AtlasConnectionApiCode.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtlasConnectionApiCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService service) : ControllerBase
    {
        private readonly IUserService _userService = service;

        [HttpPost]
        [Route("Set")]
        public async Task<ActionResult<GenericResponse>> SetUser(SaveUserDtoRequest request)
        {
            var response = await _userService.SaveUser(request);

            if (response.Success) return Ok(response);
            else return BadRequest(response);
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<GenericResponse>> GetUser(FindUserDtoRequest request)
        {
            var response = await _userService.FindUser(request);

            if (response.Success) return Ok(response);
            else return BadRequest(response);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<GenericResponse>> DeleteUser(DeleteUserDtoRequest request)
        {
            var response = await _userService.DeleteUser(request);

            if (response.Success) return Ok(response);
            else return BadRequest(response);
        }
    }
}
