using System.Net;

namespace EventManager.Core.Models.Responses;

public static class CommonResponses
{
    private const string InternalServerErrorResponseMessage = "Something bad happened, try again later.";
    private const string FailedDependencyErrorResponseMessage = "An error occured, try again later";
    private const string DefaultOkResponseMessage = "Retrieved successfully";
    private const string DefaultCreatedResponseMessage = "Created successfully";
    private const string DefaultDeletedResponseMessage = "Deleted successfully";

    public static class ErrorResponse
    {
        public static BaseResponse<T> InternalServerErrorResponse<T>()
        {
            return new BaseResponse<T>
            {
                Code = (int)HttpStatusCode.InternalServerError,
                Message = InternalServerErrorResponseMessage
            };
        }

        public static BaseResponse<T> BadRequestResponse<T>(string message)
        {
            return new BaseResponse<T>
            {
                Code = (int)HttpStatusCode.BadRequest,
                Message = message
            };
        }

        public static BaseResponse<T> FailedDependencyErrorResponse<T>()
        {
            return new BaseResponse<T>
            {
                Code = (int)HttpStatusCode.FailedDependency,
                Message = FailedDependencyErrorResponseMessage
            };
        }

        public static BaseResponse<T> NotFoundErrorResponse<T>(string message)
        {
            return new BaseResponse<T>
            {
                Code = (int)HttpStatusCode.NotFound,
                Message = message
            };
        }

        public static BaseResponse<T> ConflictErrorResponse<T>(string message)
        {
            return new BaseResponse<T>
            {
                Code = (int)HttpStatusCode.Conflict,
                Message = message
            };
        }
    }

    public static class SuccessResponse
    {
        public static BaseResponse<T> OkResponse<T>(T data, string message = null)
        {
            return new BaseResponse<T>
            {
                Code = (int)HttpStatusCode.OK,
                Message = message ?? DefaultOkResponseMessage,
                Data = data
            };
        }

        public static BaseResponse<T> CreatedResponse<T>(T data)
        {
            return new BaseResponse<T>
            {
                Code = (int)HttpStatusCode.Created,
                Message = DefaultCreatedResponseMessage,
                Data = data
            };
        }

        public static BaseResponse<EmptyResponse> DeletedResponse()
        {
            return new BaseResponse<EmptyResponse>
            {
                Code = (int)HttpStatusCode.OK,
                Message = DefaultDeletedResponseMessage
            };
        }
    }
}