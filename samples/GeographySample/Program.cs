// ***********************************************************************
// Assembly         : 
// Author           : Walter Verhoeven
// Created          : Mon 04-Mar-2024
//
// Last Modified By : Walter Verhoeven
// Last Modified On : Mon 04-Mar-2024
// ***********************************************************************
// <copyright file="Program.cs" company="VESNX SA">
//     Copyright (c) VESNX SA. All rights reserved.
// </copyright>
// <summary>
// Use Case: Applying Geographic-Specific Promotions Without Duplication
//
// Background: An e-commerce platform offers special promotions for customers
// in Latin America and South America. Some promotions are specific to
// countries, while others apply to entire regions. Given the overlap between
// these regions (e.g., countries like Brazil are part of both Latin America
// and South America), there's a risk of applying the same promotion multiple
// times to customers from overlapping countries.
// 
// Challenge: Ensure that each eligible country within overlapping regions
// is identified uniquely to apply promotions accurately without duplication,
// even when regions overlap.
// 
// Solution: Use the Expand method to convert regional representations into
// unique, constituent country-level GeoLocations. This approach guarantees
// that each country is considered only once when determining eligibility
// for promotions, regardless of regional overlaps.
// 
// 
// </summary>
// ***********************************************************************
using System;

using Walter.BOM.Geo;

Console.WriteLine("Enter 2 letter country code of a latin america country");
GeoLocationMapping.TryGetValue(Console.ReadLine()?.Trim(),out var choice);

// Sample regions with potential overlap
var promotionalRegions = new[] { GeoLocation.LATIN_AMERICA, GeoLocation.SOUTH_AMERICA };

// Expand regions into a unique list of constituent countries
var eligibleCountries = promotionalRegions.Expand().Distinct();

// Example function to apply promotions based on country
void ApplyPromotions(IEnumerable<GeoLocation> countries)
{
    var color= Console.ForegroundColor;
    foreach (var country in countries)
    {
        // Logic to apply country-specific promotions

        if (country == choice)
        { 
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Discount is applicable for {0}", choice);
        }
        else
        { 
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Skipping promotions for {country}.");
        }
    }
    Console.ForegroundColor = color;
}

// Apply promotions without duplication
ApplyPromotions(eligibleCountries);

#if !DEBUG
Console.WriteLine("press any key to exit");
Console.ReadKey();
#endif
