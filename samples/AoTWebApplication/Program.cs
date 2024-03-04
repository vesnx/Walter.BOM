// ***********************************************************************
// Assembly         : AoTWebApplication
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
// Minimal API showing exception logging and native AoT compatibility
// </summary>
// ***********************************************************************
using Walter.BOM;
namespace AoTWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateSlimBuilder(args);

            builder.Services.ConfigureHttpJsonOptions(options =>
            {
                options.SerializerOptions.TypeInfoResolverChain.Insert(0, Walter.BOM.ExceptionLoggingJsonContext.Default);
            });

            var app = builder.Build();
            app.MapPost("/api/log-exception", (ExceptionLogging exceptionLogging) =>
            {
                if (exceptionLogging == null)
                {
                    return Results.BadRequest("Exception details are required.");
                }

                // Log the exception details. Here, we're just writing to the console for demonstration.
                Console.WriteLine($"ApplicationName: {exceptionLogging.ApplicationName}");
                Console.WriteLine($"Message: {exceptionLogging.Message}");
                Console.WriteLine($"CallingMethod: {exceptionLogging.CallingMethod}");
                Console.WriteLine($"FileName: {exceptionLogging.FileName}");
                Console.WriteLine($"LineNumber: {exceptionLogging.LineNumber}");

                // Respond that the exception details have been received and logged.
                return Results.Ok("Exception details logged successfully.");
            });

            app.Run();
        }
    }


}
