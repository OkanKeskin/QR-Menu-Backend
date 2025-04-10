using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Services
{
    public class ApiException : Exception
    {
        public int StatusCode { set; get; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public string Code { get; set; }
        public new string StackTrace { get; set; }
        public List<string> Errors { get; set; }
    }

    public class ApiExceptions
    {
        public static ApiException GetValidationException(List<string> errors)
        {
            return new ApiException
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Code = "NJgyXb",
                //Title = "Validation error",
                Title = "400_ApiException_Title",
                Errors = errors
            };
        }

        public static ApiException GetGenericException(string title, string message)
        {
            if (string.IsNullOrEmpty(title))
            {
                title = "Default Title";
            }
            return new ApiException
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Code = "Az35ka",
                Title = title,
                Detail = message
            };
        }
    }
}
