// ***********************************************************************
// Assembly         : GeoSamples
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
// Console application demonstrating some of the GEO API
// </summary>
// ***********************************************************************
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;

using Walter.BOM.Geo;

namespace GeoSamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Enter the 2 letter ISO code of a country and press enter:");

            var country = Walter.BOM.Geo.GeoLocation.UnKnown;
            do
            {
                var letters = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(letters)
                    || letters.Length != 2
                    || !GeoLocationMapping.TryGetValue(letters, out var mapping))
                {
                    Console.WriteLine("2 letter country code, like DE, NL, US,GB...");
                }
                else
                {
                    country = mapping;
                }
            } while (country == GeoLocation.UnKnown);
            var capitol = country.GetCapitol();
            
            Console.WriteLine();
            Console.WriteLine($"CITY: {capitol.City}");
            Console.WriteLine($"LOCALIZED COUNTRY: {country.GetInternationalCountryName(country)}");
            Console.WriteLine($"en-US COUNTRY: {country.GetCountryName()}");
            Console.WriteLine($"GPS LAT/LONG: {capitol.Lat.LatitudeDegrees()}/{capitol.Lng.LongitudeDegrees()}");
            Console.WriteLine($"DMS LAT/LONG: {capitol.Lat.ToDmsLatitude()}/{capitol.Lng.ToDmsLongitude()}");
            Console.CancelKeyPress += Console_CancelKeyPress;
            OpenLocationInGoogleMaps(capitol.Lng, capitol.Lat);

            
            #if !DEBUG
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
#endif
            Console.CancelKeyPress -= Console_CancelKeyPress;
        }

        private static void Console_CancelKeyPress(object? sender, ConsoleCancelEventArgs e)
        {
            Console.CancelKeyPress -= Console_CancelKeyPress;
            Process.GetCurrentProcess().Kill();
        }

        static void OpenLocationInGoogleMaps(double latitude, double longitude)
        {
            Console.WriteLine("Enter your google GEO API key and press enter (CTRL+C to exit):");
            var key = Console.ReadLine();

            // Generate the Google Maps URL: 
            string mapsUrl = $"https://maps.googleapis.com/maps/api/geocode/json?latlng={latitude},{longitude}&key={key}";

            Console.WriteLine(mapsUrl);
            // Open the URL in the default browser
            try
            {
                OpenUrl(mapsUrl);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while trying to open the URL: " + ex.Message);
            }

            static void OpenUrl(string url)
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
            }
        }
    }
}