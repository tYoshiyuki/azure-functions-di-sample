namespace AzureFunctionsDiSample.Services
{
    public class HelloService : IHelloService
    {
        public string Greeting()
        {
            return "Hello World!";
        }
    }
}
