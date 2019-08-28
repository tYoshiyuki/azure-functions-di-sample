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

        public EntryPoint(IApplication application)
        {
            _application = application;
        }

        [FunctionName("FunctionsDiSample")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Function Run");

            _application.Run();

            return new OkObjectResult("Hello Functions DI Sample");
        }
    }
}
