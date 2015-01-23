using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Windows.Forms;


namespace CiscoDeviceInfo
{
    /// <summary>
    /// Used to enable double-buffering on a DataGridView, speeding up drawing.
    /// </summary>
    public static class ExtensionMethods
    {
        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }
    }


    class Util
    {
        /// <summary>
        /// Used to make a sysUpTimeInstance somewhat more useful.
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static string UptimeSecToTime(long seconds)
        {
            TimeSpan t = TimeSpan.FromSeconds(seconds);
           
            return t.Days + " Days, " + t.Hours + " Hours and " + t.Minutes + " minutes.";
        }


        /// <summary>
        /// Converts an routing protocol number as described in RFC1213-MIB to a string.
        /// </summary>
        /// <param name="protocol"></param>
        /// <returns></returns>
        public static string RouteProtocolToString(string protocol)
        {
            string szReturn = "Unknown";

            switch (protocol)
            {
                case "1":
                    szReturn = "Other";
                    break;
                case "2":
                    szReturn = "Local";
                    break;
                case "3":
                    szReturn = "NetMgmt";
                    break;
                case "4":
                    szReturn = "ICMP";
                    break;
                case "5":
                    szReturn = "EGP";
                    break;
                case "6":
                    szReturn = "GGP";
                    break;
                case "7":
                    szReturn = "HELLO";
                    break;
                case "8":
                    szReturn = "RIP";
                     break;
                case "9":
                    szReturn = "IS-IS";
                    break;
                case "10":
                    szReturn = "ES-IS";
                    break;
                case "11":
                    szReturn = "IGRP";
                    break;
                case "12":
                    szReturn = "BBN SPF IGP";
                    break;
                case "13":
                    szReturn = "OSPF";
                    break;
                case "14":
                    szReturn = "BGP";
                    break;
                case "15":
                    szReturn = "IDPR";
                    break;
                case "16":
                    szReturn = "EIGRP";
                    break;
                case "17":
                    szReturn = "DVMRP";
                    break;
                case "18":
                    szReturn = "RPL";
                    break;
            }

            return szReturn;
        }


        /// <summary>
        /// Resolves a route type to a string as described in RFC1213-MIB.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string RouteTypeToString(string type)
        {
            string szReturn = "Unknown";

            switch( type )
            {
                case "1":
                    szReturn = "Other";
                    break;
                case "2":
                    szReturn = "Invalid";
                    break;
                case "3":
                    szReturn = "Direct";
                    break;
                case "4":
                    szReturn = "Indirect";
                    break;
            }

            return szReturn;
        }


        /// <summary>
        /// Converts the Admin Status of an interface to a readable string.
        /// </summary>
        /// <param name="dAdminStatus"></param>
        /// <returns></returns>
        public static string InterfaceAdminStatusToString(int dAdminStatus)
        {
            string szAdminStatus = string.Empty;
            switch (dAdminStatus)
            {
                case 1:
                    szAdminStatus = "Up";
                    break;
                case 2:
                    szAdminStatus = "Down";
                    break;
                case 3:
                    szAdminStatus = "Testing";
                    break;
            }
            return szAdminStatus;
        }


        /// <summary>
        /// Converts an SNMP Operational Sttaus integer to a readable string.
        /// </summary>
        /// <param name="dOperStatus"></param>
        /// <returns></returns>
        public static string InterfaceOperStatusToString(int dOperStatus)
        {
            string szOperStatus = string.Empty;
            switch (dOperStatus)
            {
                case 1:
                    szOperStatus = "Up";
                    break;
                case 2:
                    szOperStatus = "Down";
                    break;
                case 3:
                    szOperStatus = "Testing";
                    break;
                case 4:
                    szOperStatus = "Unknown";
                    break;
                case 5:
                    szOperStatus = "Dormant";
                    break;
                case 6:
                    szOperStatus = "Not Present";
                    break;
                case 7:
                    szOperStatus = "Lower Layer Down";
                    break;
            }
            return szOperStatus;
        }


        /// <summary>
        /// Converts a MAC address represented as a byte array to a readable string.
        /// </summary>
        /// <param name="bMacAddress"></param>
        /// <param name="dOffset"></param>
        /// <returns></returns>
        public static string ParseSNMPMac(byte[] bMacAddress, int dOffset)
        {
            return BitConverter.ToString(bMacAddress, dOffset);
        }


        /// <summary>
        /// Resolves a long() of interface speed in bps to a humar readable speed.
        /// </summary>
        /// <param name="bitsPerSecond"></param>
        /// <returns></returns>
		public static string ParseIterfaceSpeed( long bitsPerSecond )
		{
			string szResult = "Unknown";
			decimal rate = (decimal)bitsPerSecond;
			var ordinal = 0;
			var ordinals = new[] { "", "K", "M", "G", "T", "P", "E" };

			while (rate > 1000)
			{
				rate /= 1000;
				ordinal++;
			}
			szResult = string.Format("{0} {1}bps", Math.Round(rate, 2, MidpointRounding.AwayFromZero), ordinals[ordinal]);

			return szResult;
		}


        /// <summary>
        /// Delegate for dnsReverseLookup
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        private delegate IPHostEntry GetHostEntryHandler(string ip);


        /// <summary>
        /// Performs reverse-DNS lookups
        /// </summary>
        /// <param name="szIPAddress"></param>
        /// <returns></returns>
        public static string dnsReverseLookup( string szIPAddress )
		{
            int dTimeoutMs = 50;
            try
            {
                GetHostEntryHandler callback = new GetHostEntryHandler(Dns.GetHostEntry);
                IAsyncResult result = callback.BeginInvoke(szIPAddress, null, null);
                if (result.AsyncWaitHandle.WaitOne(dTimeoutMs, false))
                {
                    return callback.EndInvoke(result).HostName;
                }
                else
                {
                    return szIPAddress;
                }
            }
            catch (Exception)
            {
                return szIPAddress;
            }
		}
    }
}
