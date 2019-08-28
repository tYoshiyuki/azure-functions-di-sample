using AzureFunctionsDiSample.Configs;
using AzureFunctionsDiSample.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AzureFunctionsDiSample.Applications
{
    /// <summary>
    /// メイン処理クラス
    /// </summary>
    public class Application : BaseApplication
    {
        private readonly AppSettings _appSettings;
        private readonly IHelloService _service;

        public Application(ILogger<IApplication> logger, IOptions<AppSettings> optionsAccessor, IHelloService service) : base(logger)
        {
            _appSettings = optionsAccessor.Value;
            _service = service;
        }

        /// <summary>
        /// メイン処理
        /// </summary>
        protected override void Main()
        {
            Logger.LogInformation(_service.Greeting());
            Logger.LogInformation(_appSettings.SampleSettings.Key); // Sample Code
        }
    }
}
