using Microsoft.Extensions.Configuration;
using Serilog;

namespace Application.Services
{
    public static class Extensions
    {

        public static LoggerConfiguration ConfigureFromJSON(this LoggerConfiguration configuration)
        {
            return configuration.ReadFrom
                .Configuration(new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build());
        }

    }
}
