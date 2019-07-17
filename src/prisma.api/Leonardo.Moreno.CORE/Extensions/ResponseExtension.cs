using Leonardo.Moreno.CORE.Response;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;

namespace Leonardo.Moreno.CORE.Externsions
{
    public static class ResponseExtensions
    {
        public static IActionResult ToHttpResponse(this SvcResponse response)
        {
            response.ResponseCode = response.HasError ? HttpStatusCode.InternalServerError : HttpStatusCode.OK;
            return new ObjectResult(response)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }

        public static IActionResult ToHttpResponse<TModel>(this SvcSingleResponse<TModel> response)
        {
            var status = HttpStatusCode.OK;

            if (response.HasError)
                status = HttpStatusCode.InternalServerError;
            else if (response.Data == null)
                status = HttpStatusCode.NotFound;

            response.ResponseCode = status;
            return new ObjectResult(response)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }

        public static IActionResult ToHttpResponse<TModel>(this SvcListResponse<TModel> response)
        {
            var status = HttpStatusCode.OK;

            if (response.HasError)
                status = HttpStatusCode.InternalServerError;
            else if (!response.Data.Any())
                response.ResponseCode = HttpStatusCode.NoContent;

            if (response.ResponseCode != HttpStatusCode.NoContent)
                response.ResponseCode = status;

            return new ObjectResult(response)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
