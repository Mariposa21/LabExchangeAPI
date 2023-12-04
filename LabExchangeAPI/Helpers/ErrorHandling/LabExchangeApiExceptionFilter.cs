using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using LabExchangeAPI.LogicLayer.Models;

namespace LabExchangeAPI.Helpers.ErrorHandling
{
    public class LabExchangeApiExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            LabApiErrorResponse apiErrorResponse = new LabApiErrorResponse()
            {
                ErrorDateTimeUtc = DateTime.UtcNow
            }; 

            switch(context.Exception)
            {
                case ArgumentException:
                    context.Result = new BadRequestObjectResult("Bad request.");
                    break;
                case LabApiResponseException:
                    LabApiResponseException labApiResponseException = context.Exception as LabApiResponseException; ;
                    apiErrorResponse.ErrorMessage = labApiResponseException.ErrorMessage; 
                    context.Result = new ObjectResult(apiErrorResponse);
                    context.HttpContext.Response.StatusCode = labApiResponseException.StatusCode; 
                    break; 
                default:
                    context.Result = new BadRequestObjectResult("Unknown error.");
                    break; 
            }
        }
    }
}
