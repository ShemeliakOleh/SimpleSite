using SimpleSite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace SimpleSite.Services
{
    public static class ApiErrorHandler
    {
        public static SimpleHttpResultModel<string> HandleExceptionAsResult(Exception ex)
        {
            return new SimpleHttpResultModel<string>(false, HttpStatusCode.InternalServerError)
            {
                Message = ex.Message,
                Content = $"Base exception message: {ex.GetBaseException().Message}"
            };
        }
    }
}