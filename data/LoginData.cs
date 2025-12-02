using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrtoGreenE2E.data
{
    public class LoginData
    {
        public static string Config(bool isEmail)
        {
            var config = new ConfigurationManager();
            config.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);

            var emailEnv = Environment.GetEnvironmentVariable("ORTOGREEN_EMAIL");
            var passEnv = Environment.GetEnvironmentVariable("ORTOGREEN_PASS");
            var emailConfig = config["Credentials:Email"];
            var passConfig = config["Credentials:Password"];

            var email = emailConfig ?? emailEnv;
            var senha = passConfig ?? passEnv;

            return isEmail ? $"{email}" : $"{senha}";
        }

        public string UserEmail { get; set; }
        public string UserPassword { get; set; }

        public LoginData()
        {
            UserEmail = Config(true);
            UserPassword = Config(false);
        }
    }
}
}
