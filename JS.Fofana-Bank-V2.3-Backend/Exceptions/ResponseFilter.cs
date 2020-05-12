using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using ExceptionFilterAttribute = System.Web.Http.Filters.ExceptionFilterAttribute;

namespace JS.Fofana_Bank_V2._3_Backend.Exceptions
{
    public class ResponseFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            string exceptionMessage = string.Empty;
            if (context.Exception.InnerException == null)
            {
                exceptionMessage = context.Exception.Message;
            }
            else
            {
                exceptionMessage = context.Exception.InnerException.Message;
            }
            //We can log this exception message to the file or database.  
            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("An unhandled exception was thrown by service."),  
                    ReasonPhrase = "Internal Server Error.Please Contact your Administrator."
            };
            context.Response = response; base.OnException(context);
        }
    }
}