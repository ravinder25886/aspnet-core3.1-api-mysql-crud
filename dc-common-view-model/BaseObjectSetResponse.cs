using System;
using System.Collections.Generic;

namespace dc_common_view_model
{
   public class BaseObjectSetResponse<T> : /*BaseOldResponse,*/ IErrorResponse
    {
        public BaseObjectSetResponse()
        {
            Errors = new List<string>();
        }

        public T Data { get; set; }
        //Error Response
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; } = 200;
        public List<string> Errors { get; set; }
        public Exception OriginalException { get; set; }
        public string CustomErrorMessage { get; set; }
        public string Message { get; set; }
        public int ErrorID { get; set; }
    }
}
