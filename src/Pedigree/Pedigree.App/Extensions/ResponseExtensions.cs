using Microsoft.AspNetCore.Mvc;
using Vouzamo.Interop.Interfaces;

namespace Pedigree.App.Extensions
{
    public static class ResponseExtensions
    {
        public static IActionResult ToResult(this IResponse response)
        {
            if (response.Success)
            {
                return new StatusCodeResult(200);
            }

            return response.ToServerErrorObjectResult();
        }

        public static ObjectResult ToObjectResult<T>(this IResponse<T> response)
        {
            if (response.Success)
            {
                return new ObjectResult(response.Result);
            }

            return response.ToServerErrorObjectResult();
        }

        public static ObjectResult ToClientErrorObjectResult<T>(this IResponse<T> response)
        {
            return new ObjectResult(response.Result)
            {
                StatusCode = 400
            };
        }

        public static ObjectResult ToServerErrorObjectResult(this IResponse response)
        {
            return new ObjectResult(response.Errors)
            {
                StatusCode = 500
            };
        }
    }
}
