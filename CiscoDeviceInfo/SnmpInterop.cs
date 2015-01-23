using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Net;
using System.Net.Sockets;
using Lextm.SharpSnmpLib;
using Lextm.SharpSnmpLib.Security;
using Lextm.SharpSnmpLib.Messaging;
using System.Text.RegularExpressions;
namespace CiscoDeviceInfo
{
    class SnmpInterop
    {
        //
        // SNMP Configuration information
        IPEndPoint snmpEndpoint;
        OctetString snmpCommunity;
        VersionCode snmpVersion;
        OctetString snmpUser;
        IAuthenticationProvider snmpAuth;
        IPrivacyProvider snmpPriv;
        int snmpTimeout = ConfigurationSettings.SNMPTimeout;
        public bool dnsLookups = false;

        //
        // Device information used by various methods.
        public readonly Dictionary<int, string> deviceInterfaces = new Dictionary<int, string>();
        public long deviceUptime;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        public SnmpInterop(DeviceConfiguration device)
        {
            //
            // Basic setup, version and community.
            switch (device.Version)
            {
                case DeviceConfiguration.SNMPVersion.V1:
                    snmpVersion = VersionCode.V1;
                    snmpCommunity = new OctetString(device.CommunityRO);
                    break;
                case DeviceConfiguration.SNMPVersion.V2C:
                    snmpVersion = VersionCode.V2;
                    snmpCommunity = new OctetString(device.CommunityRO);
                    break;
                case DeviceConfiguration.SNMPVersion.V3:
                    snmpVersion = VersionCode.V3;
                    snmpUser = new OctetString(device.Username);
                    // SNMP Auth types.
                    if (device.AuthType == DeviceConfiguration.V3AuthTypes.MD5)
                    {
                        snmpAuth = new Lextm.SharpSnmpLib.Security.MD5AuthenticationProvider(new OctetString(device.AuthPass));
                    }
                    else if (device.AuthType == DeviceConfiguration.V3AuthTypes.SHA1)
                    {
                        snmpAuth = new Lextm.SharpSnmpLib.Security.SHA1AuthenticationProvider(new OctetString(device.AuthPass));
                    }
                    else
                    {
                        snmpAuth = Lextm.SharpSnmpLib.Security.DefaultAuthenticationProvider.Instance;
                    }

                    // SNMP Privacy settings
                    if (device.PrivType == DeviceConfiguration.V3PrivTypes.DES)
                    {
                        snmpPriv = new Lextm.SharpSnmpLib.Security.DESPrivacyProvider(new OctetString(device.PrivPass), snmpAuth);
                    }
                    else if (device.PrivType == DeviceConfiguration.V3PrivTypes.AES)
                    {
                        snmpPriv = new Lextm.SharpSnmpLib.Security.AESPrivacyProvider(new OctetString(device.PrivPass), snmpAuth);
                    }
                    else
                    {
                        snmpPriv = new Lextm.SharpSnmpLib.Security.DefaultPrivacyProvider(snmpAuth);
                    }
                    break;
            }


            //
            // Determine where we should connect.
            IPAddress snmpAddr;
            if (!IPAddress.TryParse(device.Address, out snmpAddr))
            {
                IPAddress[] ipAddr;
                try
                {
                    ipAddr = Dns.GetHostAddresses(device.Address);
                }
                catch
                {
                    throw new Exception("Unable to resolve hostname of the device to its IP address.");
                }

                foreach (IPAddress ip in Dns.GetHostAddresses(device.Address).Where(address => address.AddressFamily == AddressFamily.InterNetwork))
                {
                    snmpAddr = ip;
                }

                if (snmpAddr == null)
                {
                    throw new Exception("Unable to resolve hostname of the device to a suitable InterNetwork IP address.");
                }
            }
            snmpEndpoint = new IPEndPoint(snmpAddr, device.Port);

            // Test to see if we can actually communicate.
            validConnection();
        }


        /// <summary>
        /// Tests a single OID to validate that we have a connection.
        /// </summary>
        /// <returns></returns>
        private bool validConnection()
        {
            try
            {
                List<Variable> listOids = new List<Variable>();
                listOids.Add(new Variable(new ObjectIdentifier(".1.3")));
                if (GetOidValues(listOids).Count() == 0)
                    return false;
            }
            catch (Lextm.SharpSnmpLib.Messaging.TimeoutException)
            {
                throw new Exception("A timeout occured trying to connect to the device, double-check the address and community information.");
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }


        /// <summary>
        /// Returns a list of OID values as Variable's.
        /// </summary>
        /// <param name="requestedVariables"></param>
        /// <returns></returns>
        public List<Variable> GetOidValues(List<Variable> requestedVariables)
        {
            List<Variable> oidResults;
            try
            {

                // SNMPv2
                if (snmpVersion != VersionCode.V3)
                {
                    oidResults = new List<Variable>(Messenger.Get(snmpVersion, snmpEndpoint, snmpCommunity, requestedVariables, snmpTimeout));
                }
                // SNMPv3
                else
                {
                    Discovery snmpDiscovery = Messenger.NextDiscovery;
                    ReportMessage snmpRepMsg = snmpDiscovery.GetResponse(snmpTimeout, snmpEndpoint);
                    GetRequestMessage snmpRequest = new GetRequestMessage(snmpVersion, Messenger.NextMessageId, Messenger.NextRequestId, snmpUser, requestedVariables, snmpPriv, Messenger.MaxMessageSize, snmpRepMsg);
                    ISnmpMessage snmpRespMsg = snmpRequest.GetResponse(snmpTimeout, snmpEndpoint);
                    if (snmpRespMsg.Pdu().ErrorStatus.ToInt32() != 0)
                    {
                        throw Lextm.SharpSnmpLib.Messaging.ErrorException.Create("Error in SNMP Response, ", snmpEndpoint.Address, snmpRespMsg);
                    }
                    oidResults = new List<Variable>(snmpRespMsg.Pdu().Variables);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return oidResults;
        }


        /// <summary>
        /// Walks a given OID.
        /// </summary>
        /// <param name="requestedOid"></param>
        /// <returns></returns>
        private Dictionary<string, ISnmpData> GetOidWalk(ObjectIdentifier requestedOid)
        {
            List<Variable> oidResults = new List<Variable>();

            try
            {
                if (snmpVersion == VersionCode.V1)
                {
                    Messenger.Walk(snmpVersion, snmpEndpoint, snmpCommunity, requestedOid, oidResults, snmpTimeout, WalkMode.WithinSubtree);
                }
                else if (snmpVersion == VersionCode.V2)
                {
                    Messenger.BulkWalk(snmpVersion, snmpEndpoint, snmpCommunity, requestedOid, oidResults, snmpTimeout, 255, WalkMode.WithinSubtree, null, null);
                }
                else
                {
                    Discovery snmpDiscovery = Messenger.NextDiscovery;
                    ReportMessage snmpRepMsg = snmpDiscovery.GetResponse(snmpTimeout, snmpEndpoint);
                    Messenger.BulkWalk(snmpVersion, snmpEndpoint, snmpUser, requestedOid, oidResults, snmpTimeout, 255, WalkMode.WithinSubtree, snmpPriv, snmpRepMsg);
                }
            }
            catch (Exception)
            {
                throw;
            }

            // Convert list to dictionary.
            Dictionary<string, ISnmpData> dictResults = new Dictionary<string, ISnmpData>();
            foreach (var li in oidResults)
            {
                if (!dictResults.Keys.Contains(li.Id.ToString()))
                    dictResults.Add(li.Id.ToString(), li.Data);
            }

            return dictResults;
        }


        /// <summary>
        /// Walks an OID (within subtree) and tries to map it into a table layout.
        /// </summary>
        /// <param name="requestedOid"></param>
        /// <returns></returns>
        private Dictionary<int, object>[] OidWalkTable(ObjectIdentifier requestedOid, int oidRowId = 0)
        {
            List<Variable> oidResults = new List<Variable>();
            string szBaseOid = requestedOid.ToString();

            // Walk the OID.
            try
            {
                if (snmpVersion == VersionCode.V1)
                {
                    Messenger.Walk(snmpVersion, snmpEndpoint, snmpCommunity, requestedOid, oidResults, snmpTimeout, WalkMode.WithinSubtree);
                }
                else if (snmpVersion == VersionCode.V2)
                {
                    Messenger.BulkWalk(snmpVersion, snmpEndpoint, snmpCommunity, requestedOid, oidResults, snmpTimeout, 255, WalkMode.WithinSubtree, null, null);
                }
                else
                {
                    IList<Variable> result = new List<Variable>();
                    Discovery snmpDiscovery = Messenger.NextDiscovery;
                    ReportMessage snmpRepMsg = snmpDiscovery.GetResponse(snmpTimeout, snmpEndpoint);
                    Messenger.BulkWalk(snmpVersion, snmpEndpoint, snmpUser, requestedOid, result, snmpTimeout, 255, WalkMode.WithinSubtree, snmpPriv, snmpRepMsg);

                    oidResults = new List<Variable>(result);
                }
            }
            catch (Exception)
            {
                throw;
            }

            //
            // Determine the numbe of rows.
            // Get a list of all the interfaces
            ArrayList dRowArray = new ArrayList();
            int dRowsAdded = 0;
            foreach (Variable v in oidResults)
            {
                // Get the row ID from the penultimate value.
                string[] szRowOid = v.Id.ToString().Split('.');
                if (oidRowId == 0)
                {
                    oidRowId = szRowOid.Length - 1;
                }
                int dThisRowId = Convert.ToInt32(szRowOid[oidRowId]);

                // Build an array of row IDs, since they're not always sequential.
                if (!dRowArray.Contains(dThisRowId))
                {
                    dRowArray.Add(dThisRowId);
                    dRowsAdded++;
                }
            }


            //
            // Loop over each row, add object ID and value to a dictionary array.
            Dictionary<int, object>[] results = new Dictionary<int, object>[dRowArray.Count];
            int dCurrentRow = 0;
            foreach (int rowId in dRowArray)
            {
                List<Variable> listRowCells = oidResults.FindAll(o => o.Id.ToString().Split('.').Last() == rowId.ToString());
                foreach (Variable v in listRowCells)
                {
                    string[] szOidParts = v.Id.ToString().Remove(0, 1).Split('.');
                    int dObjectId = Convert.ToInt32(szOidParts[szOidParts.Length - 2]);

                    if (results[dCurrentRow] == null)
                        results[dCurrentRow] = new Dictionary<int, object>();
                    results[dCurrentRow].Add(dObjectId, v.Data);
                }
                dCurrentRow++;
            }

            return results;
        }


        /// <summary>
        /// Dictionary containing IP addresses bound to interfaces.
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, ArrayList> GetIPInterfaces()
        {
            ObjectIdentifier oidAddrTable = new ObjectIdentifier(".1.3.6.1.2.1.4.20.1");
            string szBaseOid = oidAddrTable.ToString() + ".";
            Dictionary<string, ISnmpData> dictResults;
            Dictionary<int, ArrayList> dictIpAddr = new Dictionary<int, ArrayList>();
            try
            {
                dictResults = GetOidWalk(oidAddrTable);
            }
            catch(Exception)
            {
                throw;
            }

            //
            // Determine the number of rows.
            // Get a list of all the interfaces
            ArrayList dRowArray = new ArrayList();
            int dRowsAdded = 0;
            foreach (string s in dictResults.Keys)
            {
                // Get the row ID from the penultimate value.
                string[] szRowOid = s.Split('.');
                int dDataTypeId = Convert.ToInt32(szRowOid[9]);
                string szRowIdPart = szRowOid[11] + "." + szRowOid[12] + "." + szRowOid[13] + "." + szRowOid[14];

                // Build an array of row IDs, since they're not always sequential.
                if (!dRowArray.Contains(szRowIdPart))
                {
                    dRowArray.Add(szRowIdPart);
                    dRowsAdded++;
                }
            }

                // Now we have the row parts, get the values.
            int rowCurrent = 0;
            int dRowCount = dRowArray.Count;
            while (rowCurrent < dRowCount)
            {
                string szRowCurrentOid = dRowArray[rowCurrent].ToString();
                int dIfIndex = ((Integer32)dictResults[szBaseOid + 2+ "." + szRowCurrentOid]).ToInt32();
                string szIPAddr = ((IP)dictResults[szBaseOid + 1 + "." + szRowCurrentOid]).ToString();

                if (dictIpAddr.Keys.Contains(dIfIndex))
                {
                    ArrayList al = dictIpAddr[dIfIndex];
                    al.Add(szIPAddr);
                    dictIpAddr[dIfIndex] = al;
                }
                else
                {
                    ArrayList al = new ArrayList();
                    al.Add(szIPAddr);
                    dictIpAddr.Add(dIfIndex, al);
                }

                rowCurrent++;
            }

            return dictIpAddr;
        }


        /// <summary>
        /// Returns basic device information such as model, serial number and uptime.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> DictionaryBasicInfo()
        {
            // OIDs
            ObjectIdentifier oidHostname = new ObjectIdentifier(".1.3.6.1.2.1.1.5.0");
            ObjectIdentifier oidUptime = new ObjectIdentifier(".1.3.6.1.2.1.1.3.0");
            ObjectIdentifier oidModel = new ObjectIdentifier(".1.3.6.1.2.1.47.1.1.1.1.13.1");
            ObjectIdentifier oidSerial = new ObjectIdentifier(".1.3.6.1.2.1.47.1.1.1.1.11.1");
            ObjectIdentifier oidContact = new ObjectIdentifier(".1.3.6.1.2.1.1.4.0");
            ObjectIdentifier oidLocation = new ObjectIdentifier(".1.3.6.1.2.1.1.6.0");
            ObjectIdentifier oidVersion = new ObjectIdentifier(".1.3.6.1.2.1.1.1.0");

            // Where our SNMP results are going.
            List<Variable> oidResults = new List<Variable>();
            Dictionary<string, string> dictReturn = new Dictionary<string, string>();

            // OID's we're going to retrieve.
            List<Variable> oidList = new List<Variable>();
            oidList.Add(new Variable(oidHostname));
            oidList.Add(new Variable(oidUptime));
            oidList.Add(new Variable(oidModel));
            oidList.Add(new Variable(oidSerial));
            oidList.Add(new Variable(oidContact));
            oidList.Add(new Variable(oidLocation));
            oidList.Add(new Variable(oidVersion));

            // Storage for OID data;
            try
            {
                oidResults = this.GetOidValues(oidList);
            }
            catch (Exception)
            {
                throw;
            }

            long dSysUptime = Convert.ToInt64(oidResults.Find(o => o.Id == oidUptime).Data.ToString().Split(' ')[0]);
            this.deviceUptime = dSysUptime;

            string szHostname = oidResults.Find(o => o.Id == oidHostname).Data.ToString();
            string szUptime = Util.UptimeSecToTime(dSysUptime / 100);
            string szModel = oidResults.Find(o => o.Id == oidModel).Data.ToString();
            string szSerial = oidResults.Find(o => o.Id == oidSerial).Data.ToString();
            string szContact = oidResults.Find(o => o.Id == oidContact).Data.ToString();
            string szLocation = oidResults.Find(o => o.Id == oidLocation).Data.ToString();
            string szVersion = oidResults.Find(o => o.Id == oidVersion).Data.ToString();

            dictReturn.Add("Hostname", szHostname);
            dictReturn.Add("Uptime", szUptime);
            dictReturn.Add("Model", szModel);
            dictReturn.Add("Serial", szSerial);
            dictReturn.Add("Contact", szContact);
            dictReturn.Add("Location", szLocation);
            dictReturn.Add("Version", szVersion);

            return dictReturn;
        }


		/// <summary>
		/// Handles interfacee size for interfaces faster than 4GBps.
		/// </summary>
		/// <param name="ifIndex"></param>
		/// <returns></returns>
		private Int64 GetHighSpeedInterfaceSpeed(int ifIndex)
		{
			
			ObjectIdentifier oidRequested = new ObjectIdentifier(".1.3.6.1.2.1.31.1.1.1.15." + ifIndex);
			List<Variable> oidList = new List<Variable>();
            oidList.Add(new Variable(oidRequested));

			// Where our SNMP data will go.
			List<Variable> oidResults = new List<Variable>();

			try
			{
				oidResults = this.GetOidValues(oidList);
			}
			catch (Exception)
			{
				throw;
			}

			string szIfSpeed = oidResults.Find(o => o.Id == oidRequested).Data.ToString();

			return Convert.ToInt64(szIfSpeed);

		}


        /// <summary>
        /// Returns a DataTable listing all interfaces.
        /// </summary>
        /// <returns></returns>
        public DataTable DataTableInterfaces()
        {
            // OID Value
            ObjectIdentifier oidIntTable = new ObjectIdentifier(".1.3.6.1.2.1.2.2.1");

            // Where our SNMP data will go.
            Dictionary<int, object>[] snmpResult;
            DataTable tableResults = new DataTable();
			tableResults.Columns.Add("ID");
            tableResults.Columns.Add("Name");
            tableResults.Columns.Add("MTU");
            tableResults.Columns.Add("Speed");
            tableResults.Columns.Add("Physical Address");
            tableResults.Columns.Add("L3 address");
            tableResults.Columns.Add("Admin Status");
            tableResults.Columns.Add("Oper Status");
            tableResults.Columns.Add("Last Change");
			tableResults.Columns.Add("Description");

            try
            {
                snmpResult = this.OidWalkTable(oidIntTable);
            }
            catch (Exception)
            {
                throw;
            }

            // List of interface to IP mappings and if Descriptions.
            Dictionary<int, ArrayList> alAddresses = this.GetIPInterfaces();
			Dictionary<int, string> dictIfDesc = this.GetInterfaceDescriptions();

			// Iterate over each interface.
            foreach (Dictionary<int, object> d in snmpResult)
            {
				int dIfId = Convert.ToInt32(d[1].ToString());
                string szIfName = d[2].ToString();
                string szIfMTU = string.Empty;
                Lextm.SharpSnmpLib.Gauge32 gIntSpeed = (Lextm.SharpSnmpLib.Gauge32)d[5];
				string szIfSpeed = Util.ParseIterfaceSpeed(Convert.ToInt64(gIntSpeed.ToUInt32()));

				if (gIntSpeed.ToUInt32() == 4294967295)
					szIfSpeed = Util.ParseIterfaceSpeed(GetHighSpeedInterfaceSpeed(dIfId)*1000000);

                string szMacAddress = string.Empty;
                string szIfAdmin = Util.InterfaceAdminStatusToString(Convert.ToInt32(d[7].ToString()));
                string szIfOper = Util.InterfaceOperStatusToString(Convert.ToInt32(d[8].ToString()));
                TimeSpan tIfLastChange = TimeSpan.FromSeconds((deviceUptime - Convert.ToInt64(d[9].ToString().Split(' ')[0])) / 100);
                

                // MTU. Not always present.
                if (d.ContainsKey(4))
                    szIfMTU = d[4].ToString();

                // Physical Address - Not always present.
                OctetString osMac = (OctetString)d[6];
                if (d.ContainsKey(6) && d[6].ToString().Length > 2)
                    szMacAddress = Util.ParseSNMPMac(osMac.GetRaw(), 0);

                // L3 Address - Not always present.
                string szL3 = String.Empty;
                if (alAddresses.Keys.Contains(dIfId))
                {
                    int dIPAddrCount = alAddresses[dIfId].Count;
                    for (int i = 0; i < dIPAddrCount; i++)
                    {
                        szL3 += alAddresses[dIfId][i];
                        if (i != dIPAddrCount -1)
                        {
                            szL3 += System.Environment.NewLine;
                        }
                    }
                }

				// Add this interface to a list of interfaces.
                if (!deviceInterfaces.Keys.Contains(dIfId))
					deviceInterfaces.Add(dIfId, szIfName);

				string szIfDesc = string.Empty;
				if (dictIfDesc.Keys.Contains(dIfId))
					szIfDesc = dictIfDesc[dIfId];

				tableResults.Rows.Add(dIfId, szIfName, szIfMTU, szIfSpeed, szMacAddress, szL3, szIfAdmin, szIfOper, tIfLastChange.ToString(@"d\d\ hh\h\ mm\m\ ss\s"), szIfDesc);
            }
            return tableResults;
        }


		/// <summary>
		/// Returns interface descriptions, indexed by IfIndex.
		/// </summary>
		/// <returns></returns>
		public Dictionary<int, string> GetInterfaceDescriptions()
		{
			// OID Value
			ObjectIdentifier oidRequested = new ObjectIdentifier(".1.3.6.1.2.1.31.1.1");
			string szBaseOid = oidRequested.ToString() + ".1.";

			// Where our SNMP data will go.
			Dictionary<string, ISnmpData> snmpResult = new Dictionary<string,ISnmpData>();
			Dictionary<int, string> dictResult = new Dictionary<int, string>();
			
			try
			{
				snmpResult = this.GetOidWalk(oidRequested);
			}
			catch{}

			//
			// Determine the number of rows.
			// Get a list of all the interfaces
			ArrayList dRowArray = new ArrayList();
			int dRowsAdded = 0;
			foreach (string s in snmpResult.Keys)
			{
				// Get the row ID from the penultimate value.
				string[] szRowOid = s.Split('.');
				int dDataTypeId = Convert.ToInt32(szRowOid[10]);
				string szRowIdPart = szRowOid[11];

				// Build an array of row IDs, since they're not always sequential.
				if (!dRowArray.Contains(szRowIdPart))
				{
					dRowArray.Add(szRowIdPart);
					dRowsAdded++;
				}
			}

			// Now we have the row parts, get the values.
			int rowCurrent = 0;
			int dRowCount = dRowArray.Count;
			while (rowCurrent < dRowCount)
			{
				string szDescription = string.Empty;
				string szRowCurrentOid = dRowArray[rowCurrent].ToString();
				int ifIndex = Convert.ToInt32(szRowCurrentOid);
				if (snmpResult.Keys.Contains(szBaseOid + 18 + "." + szRowCurrentOid))
				{
					szDescription = snmpResult[szBaseOid + 18 + "." + szRowCurrentOid].ToString();
				}
				
				dictResult.Add(ifIndex, szDescription);
				rowCurrent++;
			}

			return dictResult;
		}


        /// <summary>
        /// Returns a DataTable listing switch stack members.
        /// </summary>
        /// <returns></returns>
        public DataTable DataTableSwitchStack()
        {
            // OID Value
            ObjectIdentifier oidTable = new ObjectIdentifier(".1.3.6.1.4.1.9.5.1.3.1");

            // Where our SNMP data will go.
            Dictionary<int, object>[] snmpResult;
            DataTable tableResults = new DataTable();
            tableResults.Columns.Add("Module");
            tableResults.Columns.Add("Model");
            tableResults.Columns.Add("Serial Number");
            tableResults.Columns.Add("# Ports");
            tableResults.Columns.Add("IP Address");
            tableResults.Columns.Add("VLAN");
			tableResults.Columns.Add("Status");

            try
            {
                snmpResult = this.OidWalkTable(oidTable);
            }
            catch (Exception)
            {
                throw;
            }

            foreach (Dictionary<int, object> d in snmpResult)
            {
                string szModule = ((Integer32)d[1]).ToString();
                string szModel = d[17].ToString();
                string szSerial = d[26].ToString();
                int dStatus = ((Integer32)d[10]).ToInt32();
                string szStatus = string.Empty;
                if (dStatus == 1)
                {
                    szStatus = "Other";
                }
                else if (dStatus == 2)
                {
                    szStatus = "OK";
                }
                else if (dStatus == 3)
                {
                    szStatus = "Minor Fault";
                }
                else if (dStatus == 4)
                {
                    szStatus = "Major Fault";
                }
                int dNumPorts = ((Integer32)d[14]).ToInt32();
                string szIPAddr = ((IP)d[22]).ToString();
                string szVLAN = d[23].ToString();

				tableResults.Rows.Add(szModule, szModel, szSerial, dNumPorts, szIPAddr, szVLAN, szStatus);
            }
            return tableResults;

        }


        /// <summary>
        /// Populates the route DataGridView.
        /// </summary>
        /// <returns></returns>
        public DataTable DataTableRoutes()
        {
            // OID Value
            ObjectIdentifier oidRouteTableCidr = new ObjectIdentifier(".1.3.6.1.2.1.4.24.4");

            // Where our SNMP data will go.
            Dictionary<string, ISnmpData> dictResults;
            DataTable tableResults = new DataTable();
            tableResults.Columns.Add("Destination");
            tableResults.Columns.Add("Mask");
            tableResults.Columns.Add("Next Hop");
            tableResults.Columns.Add("Metric");
            tableResults.Columns.Add("Interface");
            tableResults.Columns.Add("Protocol");
            tableResults.Columns.Add("Type");
            tableResults.Columns.Add("Age");

            string szBaseOid = oidRouteTableCidr.ToString() + ".1.";
            try
            {
                dictResults = this.GetOidWalk(oidRouteTableCidr);
            }
            catch (Exception)
            {
                throw;
            }

            //
            // Determine the number of rows.
            // Get a list of all the interfaces
            ArrayList dRowArray = new ArrayList();
            int dRowsAdded = 0;
            foreach (string s in dictResults.Keys)
            {
                // Get the row ID from the penultimate value.
                string[] szRowOid = s.Split('.');
                int dDataTypeId = Convert.ToInt32(szRowOid[11]);
                string szRowIdPart = szRowOid[12] + "."
                    + szRowOid[13] + "." + szRowOid[14] + "." + szRowOid[15] + "."
                    + szRowOid[16] + "." + szRowOid[17] + "." + szRowOid[18] + "."
                    + szRowOid[19] + "." + szRowOid[20] + "." + szRowOid[21] + "."
                    + szRowOid[22] + "." + szRowOid[23] + "." + szRowOid[24];

                // Build an array of row IDs, since they're not always sequential.
                if (!dRowArray.Contains(szRowIdPart))
                {
                    dRowArray.Add(szRowIdPart);
                    dRowsAdded++;
                }
            }

            // Now we have the row parts, get the values.
            int rowCurrent = 0;
            int dRowCount = dRowArray.Count;
            while (rowCurrent < dRowCount)
            {
                string szRowCurrentOid = dRowArray[rowCurrent].ToString();
                string szInterface = string.Empty, szDestination = string.Empty, szMask = string.Empty, szNextHop = string.Empty, szMetric = string.Empty, szRouteProtocol = string.Empty, szRouteType = string.Empty, szRouteAge = string.Empty;
				TimeSpan tRouteAge = TimeSpan.Zero;
				int dIfIndex = 0;

				if (dictResults.Keys.Contains(szBaseOid + 5 + "." + szRowCurrentOid))
				{
					dIfIndex = ((Integer32)dictResults[szBaseOid + 5 + "." + szRowCurrentOid]).ToInt32();
				}
				else
				{
					continue;
				}
                deviceInterfaces.TryGetValue(dIfIndex, out szInterface);

				try
				{
					if( dictResults.Keys.Contains(szBaseOid + 1 + "." + szRowCurrentOid) )
						szDestination = ((IP)dictResults[szBaseOid + 1 + "." + szRowCurrentOid]).ToString();

					if (dictResults.Keys.Contains(szBaseOid + 2 + "." + szRowCurrentOid))
						szMask = ((IP)dictResults[szBaseOid + 2 + "." + szRowCurrentOid]).ToString();

					if (dictResults.Keys.Contains(szBaseOid + 4 + "." + szRowCurrentOid))
						szNextHop = ((IP)dictResults[szBaseOid + 4 + "." + szRowCurrentOid]).ToString();

					if (dictResults.Keys.Contains(szBaseOid + 11 + "." + szRowCurrentOid))
						szMetric = ((Integer32)dictResults[szBaseOid + 11 + "." + szRowCurrentOid]).ToString();

					if (dictResults.Keys.Contains(szBaseOid + 7 + "." + szRowCurrentOid))
						szRouteProtocol = Util.RouteProtocolToString( ((Integer32)dictResults[szBaseOid + 7 + "." + szRowCurrentOid]).ToString() );

					if (dictResults.Keys.Contains(szBaseOid + 6 + "." + szRowCurrentOid))
						szRouteType = Util.RouteTypeToString( ((Integer32)dictResults[szBaseOid + 6 + "." + szRowCurrentOid]).ToString() );

					if (dictResults.Keys.Contains(szBaseOid + 8 + "." + szRowCurrentOid))
						tRouteAge = TimeSpan.FromSeconds(((Integer32)dictResults[szBaseOid + 8 + "." + szRowCurrentOid]).ToInt32());
				}
				catch {
					throw;
				}
                tableResults.Rows.Add(szDestination, szMask, szNextHop, szMetric, szInterface, szRouteProtocol, szRouteType, tRouteAge.ToString(@"d\d\ hh\h\ mm\m\ ss\s"));

                rowCurrent++;
            }

            return tableResults;
        }


        /// <summary>
        /// Populates the IPSec DataGridView.
        /// </summary>
        /// <returns></returns>
        public DataTable DataTableIPSec()
        {
            // OID Value
            ObjectIdentifier oidIpsecTable = new ObjectIdentifier(".1.3.6.1.4.1.9.9.171.1.3.2");

            // Where our SNMP data will go.
            Dictionary<int, object>[] snmpResult;
            DataTable tableResults = new DataTable();
            tableResults.Columns.Add("Local Address");
            tableResults.Columns.Add("Remote Address");
            tableResults.Columns.Add("Phase 1 Active", typeof(bool));
            tableResults.Columns.Add("Packets In");
            tableResults.Columns.Add("Packets Out");
			tableResults.Columns.Add("Active Time");

            try
            {
                snmpResult = this.OidWalkTable(oidIpsecTable);
            }
            catch (Exception)
            {
                throw;
            }

            foreach (Dictionary<int, object> d in snmpResult)
            {
                OctetString osLocalAddr = (OctetString)d[4];
                byte[] bLocalAddr = osLocalAddr.GetRaw();
                string szLocalAddr = bLocalAddr[0].ToString() + "." + bLocalAddr[1].ToString() + "." + bLocalAddr[2].ToString() + "." + bLocalAddr[3].ToString();
                
                OctetString osRemoteAddr = (OctetString)d[5];
                byte[] bRemoteAddr = osRemoteAddr.GetRaw();
                string szRemoteAddr = bRemoteAddr[0].ToString() + "." + bRemoteAddr[1].ToString() + "." + bRemoteAddr[2].ToString() + "." + bRemoteAddr[3].ToString();
                
                // DNS Lookups
                if (dnsLookups)
                {
                    szLocalAddr = Util.dnsReverseLookup(szLocalAddr);
                    szRemoteAddr = Util.dnsReverseLookup(szRemoteAddr);
                }
                bool phase1Active = false;
                int phase1ActiveD = Convert.ToInt32(d[3].ToString());
                if (phase1ActiveD == 1)
                    phase1Active = true;

                string szTunActiveTime = Util.UptimeSecToTime(Convert.ToInt32(d[10].ToString()) / 100);
                string szPacketsIn = d[32].ToString();
                string szPacketsOut = d[45].ToString();

				tableResults.Rows.Add(szLocalAddr, szRemoteAddr, phase1Active, szPacketsIn, szPacketsOut, szTunActiveTime);
            }

            return tableResults;
        }


        /// <summary>
        /// Populates a DataGridView with the ARP Cache.
        /// </summary>
        /// <returns></returns>
        public DataTable DataTableARP()
        {
            // OID Value
            ObjectIdentifier oidArpTable = new ObjectIdentifier(".1.3.6.1.2.1.3.1");

            // Where our SNMP data will go.
            Dictionary<string, ISnmpData> dictResults;
            DataTable tableResults = new DataTable();
            tableResults.Columns.Add("Interface");
            tableResults.Columns.Add("Physical Address");
            tableResults.Columns.Add("Network Address");
            string szBaseOid = oidArpTable.ToString() + ".1.";

            try
            {
                dictResults = this.GetOidWalk(oidArpTable);
            }
            catch (Exception)
            {
                throw;
            }


            //
            // Determine the number of rows.
            // Get a list of all the interfaces
            ArrayList dRowArray = new ArrayList();
            int dRowsAdded = 0;
            foreach (string s in dictResults.Keys)
            {
                // Get the row ID from the penultimate value.
                string[] szRowOid = s.Split('.');
                int dDataTypeId = Convert.ToInt32(szRowOid[9]);
                string szRowIdPart = szRowOid[11] + "." + szRowOid[12] + "."
                    + szRowOid[13] + "." + szRowOid[14] + "." + szRowOid[15]
                    + "." + szRowOid[16];

                // Build an array of row IDs, since they're not always sequential.
                if (!dRowArray.Contains(szRowIdPart))
                {
                    dRowArray.Add(szRowIdPart);
                    dRowsAdded++;
                }
            }

            // iterate over SNMP arp cache entries.
            int rowCurrent = 0;
            while (rowCurrent < dRowArray.Count)
            {
                string szRowCurrentOid = dRowArray[rowCurrent].ToString();
                string szInterface = string.Empty;
                int dIfIndex = ((Integer32)dictResults[szBaseOid + 1 + "." + szRowCurrentOid]).ToInt32();
                deviceInterfaces.TryGetValue(dIfIndex, out szInterface);
                string szPhysicalAddr = Util.ParseSNMPMac(
                    ((OctetString)dictResults[szBaseOid + 2 + "." + szRowCurrentOid]).ToBytes(),
                    2);
                string szIpAddr = ((IP)dictResults[szBaseOid + 3 + "." + szRowCurrentOid]).ToString();

                tableResults.Rows.Add(szInterface, szPhysicalAddr, szIpAddr);
                rowCurrent++;
            }
            return tableResults;
        }


        /// <summary>
        /// Populates the CDP DataGridView
        /// </summary>
        public DataTable DataTableCDP()
        {
            // OID Value
            ObjectIdentifier oidCDPTable = new ObjectIdentifier(".1.3.6.1.4.1.9.9.23.1.2.1");
            string szBaseOid = oidCDPTable.ToString() + ".1.";

            Dictionary<string, ISnmpData> dictResults;
            DataTable tableResults = new DataTable();
            tableResults.Columns.Add("Interface");
            tableResults.Columns.Add("Hostname");
            tableResults.Columns.Add("IP Address");
            tableResults.Columns.Add("Platform");
            tableResults.Columns.Add("Version");
            tableResults.Columns.Add("Native VLAN");
            try
            {
                dictResults = this.GetOidWalk(oidCDPTable);
            }
            catch (Exception)
            {
                throw;
            }

            //
            // Determine the numbe of rows.
            // Get a list of all the interfaces
            Dictionary<int, int> dRowArray = new Dictionary<int, int>();
            int dRowsAdded = 0;
            foreach (string s in dictResults.Keys)
            {
                // Get the row ID from the penultimate value.
                string[] szRowOid = s.Split('.');
                int dThisRowId = Convert.ToInt32(szRowOid[szRowOid.Length - 1]);

                // Build an array of row IDs, since they're not always sequential.
                if (!dRowArray.Keys.Contains(dThisRowId))
                {
                    dRowArray.Add(dThisRowId, dThisRowId = Convert.ToInt32(szRowOid[szRowOid.Length - 2]));
                    dRowsAdded++;
                }
            }

            //
            // .1.3.6.1.4.1.9.9.23.1.2.1.1.3.8.1
            // ... 
            // 3 = data type?
            // 8 = interface ID
            // 1 = device ID?
            foreach (KeyValuePair<int, int> row in dRowArray)
            {
                string szInterface = string.Empty;
                deviceInterfaces.TryGetValue(row.Value, out szInterface);

                string szHostname = ((OctetString)dictResults[szBaseOid + 6 + "." + row.Value + "." + row.Key]).ToString();

                // IP address of device.
                string szAddress = string.Empty;
                int dAddressType = ((Integer32)dictResults[szBaseOid + 3 + "." + row.Value + "." + row.Key]).ToInt32();
                if (dAddressType == 1)
                {
                    byte[] bAddress = ((OctetString)dictResults[szBaseOid + 4 + "." + row.Value + "." + row.Key]).ToBytes();
                    szAddress = bAddress[2] + "." + bAddress[3] + "." + bAddress[4] + "." + bAddress[5];
                }
                // Platform
                string szPlatform = ((OctetString)dictResults[szBaseOid + 8 + "." + row.Value + "." + row.Key]).ToString();
                szPlatform = szPlatform.Replace("cisco ", string.Empty).Trim();

                // Version
                string szVersion = "Unknown";
                string szVersionTmp = ((OctetString)dictResults[szBaseOid + 5 + "." + row.Value + "." + row.Key]).ToString();
                Match regexVersion = Regex.Match(szVersionTmp, "Version ([0-9A-Za-z.()]{2,})");
                if (regexVersion.Success)
                    szVersion = regexVersion.Value.ToString().Replace("Version ", string.Empty);

                // Native VLAN.
                string szNativeVlan = ((Integer32)dictResults[szBaseOid + 11 + "." + row.Value + "." + row.Key]).ToString();

                tableResults.Rows.Add(szInterface, szHostname, szAddress, szPlatform, szVersion, szNativeVlan);
            }
            return tableResults;
        }
    }
}
