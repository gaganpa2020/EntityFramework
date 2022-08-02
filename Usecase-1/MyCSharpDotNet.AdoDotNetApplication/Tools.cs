
namespace MyCSharpDotNet.AdoDotNetApplication
{
    static class Tools
    {
        // A helper property to have the connection string at one place
        public static string ConnectionString
        {
            get
            {
                return
                    "Server=GAGANPC;" +
                    "Database=Trick;" +
                    "User Id=sa;" +
                    "Password=Passw0rd;";
            }
        }

        // A helper method to return "NULL" if the value itself is null,
        // otherwise it returns the value
        public static string WriteNullForNull(object value)
        {
            if (value == null)
                return "NULL";
            else
                return value.ToString();
        }
    }
}
