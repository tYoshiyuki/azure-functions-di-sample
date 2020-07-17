using AzureFunctionsDiSample.Applications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace AzureFunctionsDiSample
{
    public class EntryPoint
    {
        private readonly IApplication _application;
        private readonly ILogger<EntryPoint> _log;

        public EntryPoint(IApplication application, ILogger<EntryPoint> log)
        {
            _application = application;
            _log = log;
        }

        [FunctionName("FunctionsDiSample")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Function Run");

            _log.LogInformation("This is Test");

            _application.Run();

            return new OkObjectResult("Hello Functions DI Sample");
        }

        [FunctionName("FunctionsDiRouteSample")]
        public IActionResult RunWithRoute(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "sample/{parameter}/hello")] HttpRequest req,
            string parameter,
            ILogger log)
        {
            log.LogInformation("Function Run");

            _log.LogInformation($"This is Test {parameter}");

            _application.Run();

            return new OkObjectResult($"Hello Functions DI Sample {parameter}");
        }

    }
}
