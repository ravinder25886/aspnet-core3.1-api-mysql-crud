
namespace dc_common_view_model
{
    public class dc_messages
    {
        
        public static string CREATED_SUCCESSFULLY = "%s was created successfully.";
        public static string UPDATEDED_SUCCESSFULLY = "%s was updated successfully.";
        public static string DELETE_SUCCESSFULLY = "%s deleted successfully.";
        public static string NOT_FOUND = "%s not found";
        public static string WRONG_USER = "You have entered an invalid username or password";
        public static string ACCOUNT_DEACTIVATED = "Account deactivated please contact with support team";
        public static string LOGIN_SUCCESSFULLY = "You are successfully logged in";
        public static string SubjectCreatedSuccess(string data)
        {
            return CREATED_SUCCESSFULLY.Replace("%s", data);
        }
        public static string SubjectUpdatedSuccess(string data)
        {
            return UPDATEDED_SUCCESSFULLY.Replace("%s", data);
        }
        public static string SubjectDeletedSuccess(string data)
        {
            return DELETE_SUCCESSFULLY.Replace("%s", data);
        }
        public static string SubjectNotFound(string data)
        {
            return NOT_FOUND.Replace("%s", data);
        }
    }
}
