using Serilog;

namespace DependencyInjection.Modules
{
    public class Logger
    {
        public Logger()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("..\\..\\logs\\application_logs.txt")
                .CreateLogger();
        }
    }
}