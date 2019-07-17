using Microsoft.Extensions.Configuration;

namespace Leonardo.Moreno.CORE.Config
{
    public class AppSettings
    {
        public string Environment { get; set; }
        public bool IsProdMode { get { return Environment == "Prod"; } }
        public string ConnectionString { get; set; }

        public static AppSettings GetSettings(IConfiguration config)
        {
            return config.GetSection(nameof(AppSettings)).Get<AppSettings>();
        }
    }
}
