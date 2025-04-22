using AtlasConnectionApiCode.Dto.Response;

namespace AtlasConnectionApiCode.Service
{
    public interface ICommonService
    {
        List<CommonTypeDtoResponse> ListCommons();
    }
    public class CommonService : ICommonService
    {
        public List<CommonTypeDtoResponse> ListCommons()
        {
            throw new NotImplementedException();
        }
    }
}
