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

        public string Message { get; set; }

        public IndexModel(ILogger logger)
        {
            this.logger = logger;
        }
        public void OnGet()
        {
            Log.Information("You requested the Index page.");

            Message = "Welcome";

        }
        public void OnPostChromeIngestLogs()
        {
            Message = "Chrome Ingest Logs generated.";
            ChromeIngestLogs();
        }
        
        public void OnPostLogs()
        {
            Message = "Random logs generated.";
            GenerateRandomLogs();
        }

        public void OnPostGenerateErrors()
        {
            Message = "Error logs generated.";
            GenerateErrorLogs();
        }
        public void OnPostGenerateApiErrors()
        {
            Message = "API Error logs generated.";
            GenerateApiErrors();
        }

        private void ChromeIngestLogs()
        {
            var chromeIngestLog = new ChromeIngest
            {
                App = "Incentives",
                Component = "chrome-ingest",
                DateTime = DateTime.UtcNow,
                Count = 148411,
            };

            this.logger.Information("Total count of incentives to process: {@structuredLog}", chromeIngestLog);

        }
        private void GenerateRandomLogs()
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

        private void GenerateErrorLogs()
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
                    App = "Incentives",
                    Message = "The specified argument (resources) cannot be empty.Parameter name: resources",
                    StackTract = "at System.Requires.NotNullOrEmpty[T](IEnumerable`1 collection, String name)" +
                                 "at AM.Resources.ResourceCollection`2..ctor(IEnumerable`1 resources)" +
                                 "at AM.Resources.Extensions.EnumerableExtensions.AsResourceCollection[TResource, TKey](IEnumerable`1 resources)" +
                                 "at AM.Resources.Extensions.EnumerableExtensions.AsResourceCollection[TResource, TKey](IEnumerable`1 resources, String method, String requestUri)" +
                                 "at Microsoft.AspNetCore.Mvc.ResourceCollectionOkResult`2.ExecuteResultAsync(ActionContext context)" +
                                 "at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.InvokeResultAsync(IActionResult result)" +
                                 "at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.InvokeResultFilters()" +
                                 "at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.InvokeNextResourceFilter()" +
                                 "at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Rethrow(ResourceExecutedContext context)" +
                                 "at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Next(State & next, Scope & scope, Object & state, Boolean & isCompleted)" +
                                 "at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.InvokeFilterPipelineAsync()" +
                                 "at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.InvokeAsync()" +
                                 "at Microsoft.AspNetCore.Builder.RouterMiddleware.Invoke(HttpContext httpContext)" +
                                 "at AM.Metrics.AspNetCore.Middleware.ErrorTrackingMiddleware.InvokeAsync(HttpContext context)" +
                                 "at AM.Metrics.AspNetCore.Middleware.ContentLengthTrackingMiddleware.InvokeAsync(HttpContext context)" +
                                 "at AM.Metrics.AspNetCore.Middleware.ActiveRequestTrackingMiddleware.InvokeAsync(HttpContext context)" +
                                 "at AM.Metrics.AspNetCore.Middleware.ApdexTrackingMiddleware.InvokeAsync(HttpContext context)" +
                                 "at AM.Metrics.AspNetCore.Middleware.RequestTrackingMiddleware.InvokeAsync(HttpContext context)" +
                                 "at Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpProtocol.ProcessRequests[TContext](IHttpApplication`1 application)"
                };

                this.logger.Error("Generated Error log. {@structuredLog}", structuredIncentivesLog);
            }
        }
        private void GenerateApiErrors()
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
