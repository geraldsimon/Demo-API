using Microsoft.Extensions.Configuration;

namespace Demo.BDD.Test.Config
{
    public class ConfigurationHelper
    {
        private readonly IConfiguration _config;

        public ConfigurationHelper()
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public string WebDrivers => $"{_config.GetSection("WebDrivers").Value}";
        public string EdgeDriver => $"{_config.GetSection("EdgeDriver").Value}";
        public string FolderPath => $"{_config.GetSection("FolderPath").Value}";
        public string FolderPicture => $"{_config.GetSection("FolderPicture").Value}";


        public string SiteUrl => _config.GetSection("SiteUrl").Value;
    }
}