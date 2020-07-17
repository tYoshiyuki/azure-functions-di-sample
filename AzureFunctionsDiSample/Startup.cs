using AzureFunctionsDiSample;
using AzureFunctionsDiSample.Applications;
using AzureFunctionsDiSample.Configs;
using AzureFunctionsDiSample.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace AzureFunctionsDiSample
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var services = builder.Services;
            var provider = services.BuildServiceProvider();
            var configuration = provider.GetRequiredService<IConfiguration>();

            // 設定ファイルの内容をバインドする
            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));

            // サービスのDI設定を行う
            services.AddTransient<IHelloService, HelloService>();
            services.AddTransient<IApplication, Application>();
        }
    }
}
