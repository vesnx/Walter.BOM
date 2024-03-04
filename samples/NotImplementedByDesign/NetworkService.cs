// ***********************************************************************
// Assembly         : NotImplementedByDesign
// Author           : Walter Verhoeven
// Created          : Sun 03-Mar-2024
//
// Last Modified By : Walter Verhoeven
// Last Modified On : Sun 03-Mar-2024
// ***********************************************************************
// <copyright file="NetworkService.cs" company="VESNX SA">
//     Copyright (c) VESNX SA. All rights reserved.
// </copyright>
// <summary>
// shows the use of NotImplementedByDesignException in AoT compatible mode
// with the library being trimmed and published using AoT
// </summary>
// ***********************************************************************
using System.Net;

using Walter.BOM;

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
