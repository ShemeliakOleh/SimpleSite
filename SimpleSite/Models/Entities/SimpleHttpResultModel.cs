using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace SimpleSite.Entities
{
    public class SimpleHttpResultModel<T>
    {
        public bool IsSuccessStatusCode { get; set; }

        public string Message { get; set; }

        public T Content { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public SimpleHttpResultModel(bool isSuccessStatusCode)
        {
            IsSuccessStatusCode = isSuccessStatusCode;
        }
        public SimpleHttpResultModel(bool isSuccessStatusCode, HttpStatusCode statusCode)
        {
            IsSuccessStatusCode = isSuccessStatusCode;
            StatusCode = statusCode;
        }
    }
}