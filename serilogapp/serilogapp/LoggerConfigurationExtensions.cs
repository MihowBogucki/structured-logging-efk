

namespace serilogapp
{
    using Serilog;
    using Serilog.Formatting.Elasticsearch;

    public static class LoggerConfigurationExtensions
    {
        public static LoggerConfiguration WriteToConsole(this LoggerConfiguration config, bool isDevelopment = false)
        {
            if (isDevelopment)
            {
                config.WriteTo.Console(new ElasticsearchJsonFormatter(renderMessage: false));
            }
            else
            {
                config.WriteTo.Console(new ExceptionAsObjectJsonFormatter());
            }

            return config;
        }
    }
}
