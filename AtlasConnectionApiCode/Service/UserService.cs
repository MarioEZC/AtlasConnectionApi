using AtlasConnectionApiCode.DataAccess;
using AtlasConnectionApiCode.Dto;
using AtlasConnectionApiCode.Dto.Request;
using AtlasConnectionApiCode.Model;
using AutoMapper;
using MongoDB.Bson;

namespace AtlasConnectionApiCode.Service
{
    public interface IUserService
    {
        Task<GenericResponse> SaveUser(SaveUserDtoRequest request);
    }

    public class UserService(UserDataAccess dataAccess, IMapper mapper) : IUserService
    {
        private readonly UserDataAccess _dataAccess = dataAccess;
        private readonly IMapper _mapper = mapper;

        public async Task<GenericResponse> SaveUser(SaveUserDtoRequest request)
        {
            var response = new GenericResponse();
            try
            {
                var model = _mapper.Map<UserModel>(request);

                if (request.Id == ObjectId.Empty || request.Id == null)
                {
                    await _dataAccess.CreateAsync(model);
                }
                else
                {

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
