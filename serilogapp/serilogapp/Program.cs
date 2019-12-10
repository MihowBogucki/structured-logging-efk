namespace serilogapp
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;
    using Serilog;
    using Serilog.Events;

    public class Program
    {
        public static void Main(string[] args) => BuildWebHost(args).Run();

        private static IWebHost BuildWebHost(string[] args)
            => WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseSerilog((ctx, config) => config
                    .MinimumLevel.Debug()
                    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                    .Enrich.FromLogContext()
                    .WriteToConsole(ctx.HostingEnvironment.IsDevelopment()))
                .UseStartup<Startup>()
                .Build();
    }
}
