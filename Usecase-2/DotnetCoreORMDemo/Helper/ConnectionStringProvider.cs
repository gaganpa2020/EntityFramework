using System.Configuration;

namespace DotnetCoreORMDemo.Helper
{
    public static class ConnectionStringProvider
    {
        public static string Get()
        {
            return ConfigurationManager.ConnectionStrings["CustomerManagementConnectionString"].ConnectionString;
        }
    }
}
