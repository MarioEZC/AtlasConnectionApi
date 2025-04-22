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
        public async Task<GenericResponse> SetUser(SaveUserDtoRequest request)
        {
            var response = await _userService.SaveUser(request);

            return response;
        }
    }
}
