using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace ExceptionConsoleSample
{
    internal class Program
    {
        static IServiceProvider _serviceProvider;
        static Program()
        {
            _serviceProvider = new ServiceCollection()
                                .AddLogging(setup => {
                                    setup.AddConsole();
                                    setup.SetMinimumLevel(LogLevel.Information);
                                })
                                .LogNotImplementedByDesignException(api:"https://localhost:5001")
                               .BuildServiceProvider();
            //add logging to the walter framework
            _serviceProvider.AddLoggingForWalter();

        }
        static void Main(string[] args)
        {
            
        }
    }
}
