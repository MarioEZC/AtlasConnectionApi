using AtlasConnectionApiCode.DataAccess;
using AtlasConnectionApiCode.Dto;
using AtlasConnectionApiCode.Dto.Request;
using AtlasConnectionApiCode.Dto.Response;
using AtlasConnectionApiCode.Model;
using AtlasConnectionApiCode.Validation;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace AtlasConnectionApiCode.Service
{
    public interface IUserService
    {
        Task<GenericResponse> SaveUser(SaveUserDtoRequest request);
        Task<GenericResponse<List<FindUserDtoResponse>>> FindUser(FindUserDtoRequest request);
        Task<GenericResponse> DeleteUser(DeleteUserDtoRequest request);

    }

    public class UserService([FromServices] UserDataAccess dataAccess, [FromServices] IMapper mapper) : IUserService
    {
        private readonly UserDataAccess _dataAccess = dataAccess;
        private readonly IMapper _mapper = mapper;


        public async Task<GenericResponse> SaveUser(SaveUserDtoRequest request)
        {
            var response = new GenericResponse();
            try
            {
                var validator = new SaveUserDtoRequestValidation();
                var validateRequest = validator.Validate(request);
                if (!validateRequest.IsValid)
                {
                    response.Success = false;
                    response.Message = $"{validateRequest.Errors[0].ErrorCode} - {validateRequest.Errors[0].ErrorMessage}";
                    return response;
                }

                var model = _mapper.Map<UserModel>(request);

                if (string.IsNullOrEmpty(request.Id))
                {
                    await _dataAccess.CreateAsync(model);
                }
                else
                {
                    await _dataAccess.UpdateAsync(model.Id, model);
                }
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<GenericResponse<List<FindUserDtoResponse>>> FindUser(FindUserDtoRequest request)
        {
            var response = new GenericResponse<List<FindUserDtoResponse>>();

            try
            {
                var validator = new FindUserDtoRequestValidation();
                var validateRequest = validator.Validate(request);
                if (!validateRequest.IsValid)
                {
                    response.Success = false;
                    response.Message = $"{validateRequest.Errors[0].ErrorCode} - {validateRequest.Errors[0].ErrorMessage}";
                    return response;
                }

                if (string.IsNullOrEmpty(request.Id))
                {
                    var data = await _dataAccess.GetAsync();
                    response.Data = _mapper.Map<List<UserModel>, List<FindUserDtoResponse>>(data);
                }
                else
                {
                    var data = await _dataAccess.GetAsync(ObjectId.Parse(request.Id));
                    response.Data = [
                        _mapper.Map<FindUserDtoResponse>(data)
                    ];
                }
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<GenericResponse> DeleteUser(DeleteUserDtoRequest request)
        {
            var response = new GenericResponse();

            try
            {
                var validator = new DeleteUserDtoRequestValidation();
                var validateRequest = validator.Validate(request);
                if (!validateRequest.IsValid)
                {
                    response.Success = false;
                    response.Message = $"{validateRequest.Errors[0].ErrorCode} - {validateRequest.Errors[0].ErrorMessage}";
                    return response;
                }

                await _dataAccess.RemoveAsync(ObjectId.Parse(request.Id));
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
