using System;
using System.Configuration;

namespace WebDBserverAPI
{
    public class ConnStr
    {
        public static string Get()
        {
            var uriString = ConfigurationManager.AppSettings["ELEPHANTSQL_URL"] ?? "postgres://geoxbaal:94pUQGCtr5DO8tB7LCIYz6PcWS6ha-xz@abul.db.elephantsql.com/geoxbaal";
            Console.WriteLine($"uriString: {uriString}");
            var uri = new Uri(uriString);
            var db = uri.AbsolutePath.Trim('/');
            var user = uri.UserInfo.Split(':')[0];
            var passwd = uri.UserInfo.Split(':')[1];
            var port = uri.Port > 0 ? uri.Port : 5432;
            var connStr = string.Format("Server={0};Database={1};User Id={2};Password={3};Port={4}",
                uri.Host, db, user, passwd, port);
            return connStr;
        }
    }
}
