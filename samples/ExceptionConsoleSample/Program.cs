// ***********************************************************************
// Assembly         : ExceptionConsoleSample
// Author           : Walter Verhoeven
// Created          : Sun 03-Mar-2024
//
// Last Modified By : Walter Verhoeven
// Last Modified On : Sun 03-Mar-2024
// ***********************************************************************
// <copyright file="Program.cs" company="VESNX SA">
//     ©2024 VESNX SA, all rights reserved.
// </copyright>
// <summary>
// Demonstrating not implemented by design in interaction with the Sample Web application
// </summary>
// ***********************************************************************
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using System.Net;

using Walter.BOM;


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
                                .LogNotImplementedByDesignException(api:"http://localhost:5098/log-exception")
                               .BuildServiceProvider();
            //add logging to the walter framework
            _serviceProvider.AddLoggingForWalter();

        }
        static void Main(string[] args)
        {
            var color = Console.ForegroundColor;
            var networkService = new NetworkService();
            try
            {
                // Assuming an IPv6 address for demonstration
                IPAddress ipv6Address = IPAddress.Parse("2001:0db8:85a3:0000:0000:8a2e:0370:7334");
                networkService.CheckIPAddressSupport(ipv6Address);
            }
            catch (NotImplementedByDesignException ex)
            {

                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine($"Error: {ex.Message}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Please contact support with the following details:");
                Console.WriteLine($"Member Name: {ex.CallerMemberName}");
                Console.WriteLine($"File Path: {ex.FilePath}");
                Console.WriteLine($"Line: {ex.Line}");
            }
            finally
            {
#if !DEBUG
            Console.ForegroundColor = color;
            Console.WriteLine();

Console.WriteLine("Press any key to exit");
            Console.ReadKey();
#endif
            }
        }
    }
}
