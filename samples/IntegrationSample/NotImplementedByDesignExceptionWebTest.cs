// ***********************************************************************
// Assembly         : IntegrationSample
// Author           : Walter Verhoeven
// Created          : Sun 03-Mar-2024
//
// Last Modified By : Walter Verhoeven
// Last Modified On : Sun 03-Mar-2024
// ***********************************************************************
// <copyright file="NotImplementedByDesignExceptionWebTest.cs" company="VESNX SA">
//     ©2024 VESNX SA, all rights reserved.
// </copyright>
// <summary>
// Integration sample showing dependency injection and exception logging
// </summary>
// ***********************************************************************
using AoTWebApplication;

using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IntegrationSample
{
    [TestClass]
    public class NotImplementedByDesignExceptionWebTest
    {
        private static WebApplicationFactory<Program> _factory = new();
        private static IServiceProvider? _services;
        [TestInitialize]
        public static void TestInitialize(TestContext context)
        { 
            _services= new ServiceCollection()
                        .AddLogging()
                        .LogNotImplementedByDesignException("/api/log-exception",_factory.CreateClient())
                        .BuildServiceProvider();

        }
        [TestCleanup]
        public static void TestCleanup()
        {
            _factory.Dispose();
        }

        [TestMethod]
        
        public async Task GenerateExceptionTest()
        {
            var logger= _services?.GetService<ILogger>();
            try
            {
                throw new NotImplementedException();
            }catch (NotImplementedException) 
            {
                logger?.LogInformation("Should have executed API endpoint");
            }

            await Task.Delay(1000);
        }
    }
}