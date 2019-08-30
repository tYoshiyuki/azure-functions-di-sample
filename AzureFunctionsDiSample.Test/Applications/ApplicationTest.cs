using AzureFunctionsDiSample.Applications;
using AzureFunctionsDiSample.Configs;
using AzureFunctionsDiSample.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace AzureFunctionsDiSample.Test.Applications
{
    public class ApplicationTest
    {
        [Fact]
        public void Run_正常系()
        {
            // Arrange
            var logger = Mock.Of<ILogger<IApplication>>();

            var service = new Mock<IHelloService>();
            service.Setup(_ => _.Greeting())
                .Returns("hello")
                .Verifiable();

            var settings = new SampleSettings { SampleKey = "value" };
            var appSettings = new AppSettings { SampleSettings = settings };
            var options = new Mock<IOptions<AppSettings>>();
            options.Setup(_ => _.Value)
                .Returns(appSettings)
                .Verifiable();

            var application = new Application(logger, options.Object, service.Object);

            // Act
            application.Run();

            // Assert
            service.Verify(_ => _.Greeting(), Times.Once);
            options.Verify(_ => _.Value, Times.Once);
        }
    }
}
