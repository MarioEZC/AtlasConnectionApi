using AtlasConnectionApiCode.DataAccess;
using AtlasConnectionApiCode.Dto;
using AtlasConnectionApiCode.Dto.Response;
using AtlasConnectionApiCode.Model;
using AutoMapper;

namespace AtlasConnectionApiCode.Service
{
    public interface ICommonService
    {
        Task<GenericResponse<List<CommonTypeDtoResponse>>> ListAll();
    }
    public class CommonService(CommonDataAccess dataAccess, IMapper mapper) : ICommonService
    {
        private readonly CommonDataAccess _dataAccess = dataAccess;
        private readonly IMapper _mapper = mapper;
        public async Task<GenericResponse<List<CommonTypeDtoResponse>>> ListAll()
        {
            var response = new GenericResponse<List<CommonTypeDtoResponse>>();

            try
            {
                var data = await _dataAccess.GetAsync();
                if (data != null)
                {
                    response.Data = _mapper.Map<List<CommonModel>, List<CommonTypeDtoResponse>>(data);
                }
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
