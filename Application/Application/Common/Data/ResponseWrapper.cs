using Application.Common.Validation;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Application.Common.Data
{
    public class ResponseWrapper : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            ResponseData response = new ResponseData();
            if (actionExecutedContext.Exception != null && !(actionExecutedContext.Exception is ValidationException)) {
                response.SetStatus(HttpStatusCode.InternalServerError);
            }
            if (actionExecutedContext.Exception != null && actionExecutedContext.Exception is ValidationException)
            {
                ValidationException exception = actionExecutedContext.Exception as ValidationException;
                response.SetErrors(exception.Errors);
                response.SetStatus(HttpStatusCode.BadRequest);
            }
            if (actionExecutedContext.Exception == null && actionExecutedContext.Response.StatusCode != HttpStatusCode.NoContent)
            {
                ObjectContent content = (ObjectContent)actionExecutedContext.Response.Content;
                response.SetData(content.Value);
                response.SetStatus(HttpStatusCode.OK);
            }   
            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}