using System;
using System.Collections.Generic;

namespace dc_common_view_model
{
    public class ErrorResponse : IErrorResponse
    {
        public ErrorResponse()
        {
            //APIErrors = new List<string>();
            Errors = new List<string>();
        }

        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; } = 200;
        //public List<string> APIErrors { get; set; }
        public List<string> Errors { get; set; }
        public Exception OriginalException { get; set; }
        public string CustomErrorMessage { get; set; }
        public int ErrorID { get; set; }
    }
}
