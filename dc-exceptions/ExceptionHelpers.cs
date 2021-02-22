using dc_common_view_model;
using dc_exceptions.Extensions;
using System;
using System.Collections.Generic;

namespace dc_exceptions
{
    public static class ExceptionHelpers
    {
        public static ErrorResponse GetErrorResponse(this Exception ex, LoggedInUser user = null, string customMessage = null)
        {
            string errorMessage = null;
            int errorId = ex.Log(user);

            if (String.IsNullOrWhiteSpace(customMessage))
            {
                errorMessage = $"Something went wrong on the server, Please reach out to support and refer to this errorId: {errorId}";
            }
            else
            {
                errorMessage = customMessage + $" Please reach out to support and refer to this errorId: {errorId}";
            }

            return new ErrorResponse { Errors = new List<string> { errorMessage }, IsSuccess = false, ErrorID = errorId };
        }
    }
}
