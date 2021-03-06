using System.Collections.Generic;
using InfoHub.ORM.Interfaces;

namespace InfoHub.ORM.Models
{
    public class ConfigurationBase : IConfiguration
    {
        public string Host { get; set; }
        public string Database { get; set; }
        public string Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsValid { get; protected set; }

        public string ConnectionString
        {
            get
            {
                return string.Format("SERVER={0}; DATABASE={1}; UID= {2}; PASSWORD={3};",
                    Host, Database, Username, Password);
            }
        }

        public Dictionary<string, string> AdditionalParameters { get; set; }

        public ConfigurationBase(string host, string database, string port, string username, string password)
        {
            Host = host;
            Database = database;
            Port = port;
            Username = username;
            Password = password;
            IsValid = true;
        }

        public void Dispose()
        {
            IsValid = false;
        }
    }
}