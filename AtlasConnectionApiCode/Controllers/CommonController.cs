using AtlasConnectionApiCode.Dto.Request;
using AtlasConnectionApiCode.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AtlasConnectionApiCode.Service;
using AtlasConnectionApiCode.Dto.Response;

namespace AtlasConnectionApiCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController(ICommonService commonService) : ControllerBase
    {
        private readonly ICommonService _commonService = commonService;

        [HttpGet]
        [Route("Get")]
        public async Task<GenericResponse<List<CommonTypeDtoResponse>>> GetCommon()
        {
            var response = await _commonService.ListAll();

            return response;
        }
    }
}
