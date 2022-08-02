using System.Configuration;

namespace DotnetCoreORMDemo.Helper
{
    public static class ConnectionStringProvider
    {
        /*
        public static string ConnectionString()
        {
            return
                "Data source=GAGANPC;" +
                "Initial catalog=CustomerManagement;" +
                "User Id=sa;" +
                "Password=Passw0rd;";
        }
        */

        public static string Get()
        {
            return ConfigurationManager.ConnectionStrings["CustomerManagementConnectionString"].ConnectionString;
        }
    }
}
