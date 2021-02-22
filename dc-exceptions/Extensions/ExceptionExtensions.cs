using dc_common_view_model;
using Microsoft.Extensions.Configuration;
using System;

namespace dc_exceptions.Extensions
{
    public static class ExceptionExtensions
    {
        public static int Log(this Exception exc, LoggedInUser user = null, bool sendEmail = false,  IConfiguration configuration = null)
        {
            // TODO Funtion for errro log
            try
            {
                if (configuration != null && configuration["AppEnvironment"] == "dev")
                {
                    sendEmail = false;
                }
                string Description = "Error Detail";
                if (sendEmail)
                {
                    string emailContent = ("Hello Dev Team ,<br/><br/>" + Description + "<br/><br/>" + "Regards <br/>Support Team");
                    //string subject = ("Erorr Occured on the project");

                    //var _emailSender = new EmailSender();
                }

                return 1;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
