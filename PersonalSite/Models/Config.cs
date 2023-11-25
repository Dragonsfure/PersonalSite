using NuGet.Protocol;

namespace PersonalSite.Models {
    public static class Config {

        private static readonly IConfiguration _configuration;

        /// <summary>
        /// Sets the Connection to the AppSettings-File.
        /// </summary>
        static Config() {
            if (IsDevelopment) {
                _configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.Development.json").Build();
            } else {
                _configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();
            }
        }

        /// <summary>
        /// Gets if the Programm is in Development-Mode or not.
        /// </summary>
        public static bool IsDevelopment {
            get {
                return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != Environments.Development;
            }
        }

        /// <summary>
        /// Gets the MailAdress, from the AppSettings.json.
        /// </summary>
        public static string MailAdress {
            get {
                return _configuration.GetValue<string>(nameof(MailAdress));
            }
        }

        /// <summary>
        /// Gets the AppPassword, from the AppSettings.json.
        /// </summary>
        public static string AppPassword {
            get {
                return _configuration.GetValue<string>(nameof(AppPassword));
            }
        }

        /// <summary>
        /// Gets the SMTPAdress, from the AppSettings.json.
        /// </summary>
        public static string SMTPAdress {
            get {
                return _configuration.GetValue<string>(nameof(SMTPAdress));
            }
        }
    }
}
