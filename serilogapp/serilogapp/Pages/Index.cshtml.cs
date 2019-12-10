using System;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace serilogapp.Pages
{
    using Serilog;
    using serilogapp.Dtos;
    using serilogapp.Enums;

    public class IndexModel : PageModel
    {
        private readonly ILogger logger;

        public IndexModel(ILogger logger)
        {
            this.logger = logger;
        }
        public void OnGet()
        {
            Log.Information("You requested the Index page.");

            GenerateRandomLogs();

        }
        public void GenerateRandomLogs()
        {
            this.logger.Information(("You requested the Index page."));

            Random random = new Random();
            var maxLogCount = random.Next(1, 1000);
            var logCountErrorNumber = random.Next(1, maxLogCount);

            try
            {
                for (int i = 0; i < maxLogCount; i++)
                {
                    if (i == logCountErrorNumber)
                    {
                        GenerateErrorLogs();
                    }
                    else
                    {
                        this.logger.Information("The value of i is {LoopCountValue}", i);
                    }

                }
            }
            catch (Exception ex)
            {
                this.logger.Error(ex, "We caught this exception in the Index Get Call.");
            }
        }

        public void GenerateErrorLogs()
        {
            var random = new Random();
            var numberOfErrors = random.Next(1, 10);

            for (int i = 0; i < numberOfErrors; i++)
            {
                var randomBrand = GetRandomBrand();

                var structuredIncentivesLog = new IncentivesError
                {
                    BrandName = randomBrand,
                    IncentiveId = Guid.NewGuid(),
                    DateTime = DateTime.UtcNow,
                    App = "Incentives"

                };

                this.logger.Error("Generated Error log. {@structuredLog}", structuredIncentivesLog);
            }
        }

        private static Brand GetRandomBrand()
        {
            var values = Enum.GetValues(typeof(Brand));
            var random = new Random();
            var randomBrand = (Brand)values.GetValue(random.Next(values.Length));
            return randomBrand;
        }
    }
}
