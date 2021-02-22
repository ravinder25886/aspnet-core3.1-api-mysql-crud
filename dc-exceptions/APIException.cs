using System;
namespace dc_exceptions
{
    public class APIException : Exception
    {
        public APIException(string message) : base(message) { }

        public string CustomMessage { get; set; }
        public Exception CustomException { get; set; }
    }
}
