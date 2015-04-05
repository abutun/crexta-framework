/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*	CREXTA - Web Data Extraction Framework  							*
*																		*
*	Copyright (C) 2009-2011  Ahmet BÜTÜN (ahmetbutun@gmail.com)			*
*	http://www.ahmetbutun.net |	http://www.abbsolutions.com				*
*																		*
*	www.me-like.biz														*
*																		*
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *  */
using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net;

namespace Crexta.Utilities
{
    public class NetworkUtility
    {

        public NetworkUtility()
        {
        }

        /// <summary>
        /// returns the mac address of the first operation nic found.
        /// </summary>
        /// <returns></returns>
        public static string GetFirstOperationalMacAddress()
        {
            string macAddresses = "";

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }
            return macAddresses;
        }

        public static string GetMachineName()
        {
            return Environment.MachineName;
        }

        public static string GetHostName()
        {
            return Dns.GetHostName();
        }

        public static string GetLocalIPAddress()
        {
            string result = "";

            // create collection to hold network interfaces
            System.Net.NetworkInformation.NetworkInterface[] Interfaces;

            // get list of all interfaces
            Interfaces = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();

            // loop through interfaces
            foreach (System.Net.NetworkInformation.NetworkInterface Interface in Interfaces)
            {
                if (Interface.OperationalStatus == OperationalStatus.Up)
                {
                    // create collection to hold IP information for interfaces
                    System.Net.NetworkInformation.UnicastIPAddressInformationCollection IPs;

                    // get list of all unicast IPs from current interface
                    IPs = Interface.GetIPProperties().UnicastAddresses;

                    // loop through IP address collection
                    foreach (System.Net.NetworkInformation.UnicastIPAddressInformation IP in IPs)
                    {
                        // check IP address for IPv4
                        if (IP.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            if (IP.Address.ToString() != "127.0.0.1")
                            {
                                result = IP.Address.ToString();

                                break;
                            }
                        }
                    }
                }
            }

            return result;
        }

        public static bool IsConnectedToInternet()
        {
            bool result = true;

            try
            {
                System.Net.IPHostEntry hostentry = System.Net.Dns.GetHostEntry("www.google.com");
            }
            catch
            {
                // try another one
                try
                {
                    System.Net.IPHostEntry hostentry = System.Net.Dns.GetHostEntry("www.microsoft.com");
                }
                catch
                {
                    // now we are sure!
                    result = false;
                }
            }

            return result;
        }
    }
}
