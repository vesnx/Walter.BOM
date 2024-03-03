WALTER
Introducing the WALTER Framework: Workable Algorithms for Location-aware Transmission, Encryption Response. Designed for modern developers, WALTER is a groundbreaking suite of NuGet packages crafted for excellence in .NET Standard 2.0, 2.1, Core 3.1, and .NET 6, 7, 8, as well as C++ environments. Emphasizing 100% AoT support and reflection-free operations, this framework is the epitome of performance and stability.

Whether you're tackling networking, encryption, or secure communication, WALTER offers unparalleled efficiency and precision in processing, making it an essential tool for developers who prioritize speed and memory management in their applications.

# About the Walter.BOM package
The Walter.BOM project provides a foundational set of basic data types and utilities designed to support a suite of .NET-based NuGet packages aimed at enhancing web application security, networking, and IO operations. It serves as the backbone for the following packages:

- **Walter.Net.HoneyPot**: Offers honey pot services for detecting and mitigating automated threats.
- **Walter.Net.LookWhosTalking**: Provides tools for gathering and analyzing application communication statistics.
- **Walter.Net.Networking**: Includes networking utilities and structures for robust network management.
- **Walter.IO**: Contains functionality for advanced IO operations.
- **Walter.Web.FireWall**: Integrates a Web Application Firewall (WAF) for protecting web applications from various attacks.

Additionally, Walter.BOM enriches applications with geographic extensions and basic country-level lookup capabilities for mapping and location services.

# Compatibility
The Walter.BOM project and its associated packages directly support the following frameworks, ensuring wide compatibility across various platforms:

- **.NET Standard 2.0**
- **.NET Standard 2.1**
- **.NET 6.0**
- **.NET 7.0**
- **.NET 8.0**

This compatibility range allows for the use of Walter.BOM in applications targeting Windows, MAUI, Unix, and more, providing flexibility and support for a broad array of development scenarios.

## Prerequisites
Before you begin, ensure you have met the following requirements:
- Compatible .NET framework installed (see Compatibility section above)
- Visual Studio 2019 or newer (for development)

## Installation
To use Walter.BOM in your project, install it via NuGet Package Manager or the .NET CLI:

```bash
dotnet add package Walter.BOM
```
### Introduction to NetworkService Example
The NetworkService class is a simple demonstration of how the Walter.BOM library can be utilized to manage and validate network addresses within your application. Specifically, this example showcases how to determine if an IP address is IPv4, which is currently supported, versus IPv6, which is intentionally not implemented in the current release. This approach leverages the NotImplementedByDesignException to clearly indicate features that are out of scope, improving code clarity and maintainability. Below is a sample implementation of the NetworkService class, which includes a method to check IP address support.

```c#

public class NetworkService
{
    public void CheckIPAddressSupport(IPAddress ipAddress)
    {
        if (ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
        {
            // IPv6 is found to be out of scope for the current release
            throw new NotImplementedByDesignException("IPv6 support is out of scope for the current release.");
        }
        else
        {
            Console.WriteLine("IPv4 address is supported.");
        }
    }
}
```
### Introduction to Program Main Method Example
The following code snippet demonstrates a practical application of the NetworkService within a console application. This example specifically illustrates error handling in scenarios where unsupported IPv6 addresses are encountered. By attempting to check the support for an IPv6 address, the application intentionally triggers a NotImplementedByDesignException. This exception is then gracefully caught and processed, providing the user with detailed feedback, including the method name, file path, and line number where the exception was thrown. This pattern is invaluable for debugging and supports a robust development process by explicitly handling out-of-scope functionality.

The documentation section of this github repository contains a AoT sample showing the use. 

```c#
class Program
{
    static void Main(string[] args)
    {


        var color= Console.ForegroundColor;
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
```

## Contributing
Contributions to the Walter.BOM project are welcome! If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".

Don't forget to give the project a star! Thanks again!

## Support and Contact
If you encounter any problems or have any questions, please contact us via GitHub issues or email (support@vesnx.com). We're here to help.
