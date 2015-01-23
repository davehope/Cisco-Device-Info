using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Configuration;
using System.Collections.Specialized;

namespace CiscoDeviceInfo
{
    [Serializable()]
    class DeviceConfiguration : ISerializable
    {
        public enum SNMPVersion { V1, V2C, V3 }
        public enum V3AuthTypes { NoAuth, MD5, SHA1 }
        public enum V3PrivTypes { NoPriv, DES, AES }

        public string Name { get; set; }
        public string Address { get; set; }
        public int Port { get; set; }
        public SNMPVersion Version;

        public string CommunityRO { get; set; }
        public string CommunityRW { get; set; }

        public string Username { get; set; }
        public V3AuthTypes AuthType;
        public string AuthPass { get; set; }

        public V3PrivTypes PrivType;
        public string PrivPass { get; set; }

        public DeviceConfiguration()
        {
        }


        /// <summary>
        /// Reads an object from serialization infomration.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="ctxt"></param>
        public DeviceConfiguration(SerializationInfo info, StreamingContext ctxt)
        {
            this.Name = (string)info.GetValue("Name", typeof(string));
            this.Address = (string)info.GetValue("Address", typeof(string));
            this.Port = (int)info.GetValue("Port", typeof(int));
            this.Version = (SNMPVersion)info.GetValue("Version", typeof(SNMPVersion));

            this.CommunityRO = (string)info.GetValue("CommunityRO", typeof(string));
            this.CommunityRW = (string)info.GetValue("CommunityRW", typeof(string));

            this.Username = (string)info.GetValue("Username", typeof(string));
            this.AuthType = (V3AuthTypes)info.GetValue("AuthType", typeof(V3AuthTypes));
            this.AuthPass = (string)info.GetValue("AuthPass", typeof(string));

            this.PrivType = (V3PrivTypes)info.GetValue("PrivType", typeof(V3PrivTypes));
            this.PrivPass = (string)info.GetValue("PrivPass", typeof(string));
        }


        /// <summary>
        /// Converts the object to serialization information.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="ctxt"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Name", this.Name);
            info.AddValue("Address", this.Address);
            info.AddValue("Port", this.Port);
            info.AddValue("Version", this.Version);

            info.AddValue("CommunityRO", this.CommunityRO);
            info.AddValue("CommunityRW", this.CommunityRW);

            info.AddValue("Username", this.Username);

            info.AddValue("AuthType", this.AuthType);
            info.AddValue("AuthPass", this.AuthPass);

            info.AddValue("PrivType", this.PrivType);
            info.AddValue("PrivPass", this.PrivPass);
        }

    }


    [Serializable()]
    class DeviceConfigurationList : ISerializable
    {

        /// <summary>
        /// Deserializes the device list from a file.
        /// </summary>
        /// <returns></returns>
        public static DeviceConfigurationList GetDeviceList(string szFileName)
        {
            DeviceConfigurationSerializer serializer = new DeviceConfigurationSerializer();
            return serializer.DeSerializeObject(szFileName);
        }

        /// <summary>
        /// Serializes the device list to a file.
        /// </summary>
        /// <param name="szFileName"></param>
        /// <param name="devices"></param>
        public static void SaveDeviceList(string szFileName, DeviceConfigurationList devices)
        {
            DeviceConfigurationSerializer serializer = new DeviceConfigurationSerializer();
            serializer.SerializeObject(szFileName, devices);
        }


        private List<DeviceConfiguration> devices;


        public List<DeviceConfiguration> Devices
        {
            get { return this.devices; }
            set { this.devices = value; }
        }


        public DeviceConfigurationList()
        {
            Devices = new List<DeviceConfiguration>();
        }


        public DeviceConfigurationList(SerializationInfo info, StreamingContext ctxt)
        {
            this.devices = (List<DeviceConfiguration>)info.GetValue("Devices", typeof(List<DeviceConfiguration>));
        }


        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Devices", this.devices);
        }
    }


    class DeviceConfigurationSerializer
    {

        /// <summary>
        /// Serializes a DeviceConfigurationList object to a file.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="objectToSerialize"></param>
        public void SerializeObject(string filename, DeviceConfigurationList objectToSerialize)
        {
            Stream stream = File.Open(filename, FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, objectToSerialize);
            stream.Close();
        }


        /// <summary>
        /// Deserializes a DeviceConfigurationList object from a file.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public DeviceConfigurationList DeSerializeObject(string filename)
        {
            DeviceConfigurationList objectToSerialize;
            try
            {
                Stream stream = File.Open(filename, FileMode.Open);
                BinaryFormatter bFormatter = new BinaryFormatter();
                objectToSerialize = (DeviceConfigurationList)bFormatter.Deserialize(stream);
                stream.Close();
            }
            catch
            {
                return new DeviceConfigurationList();
            }
            return objectToSerialize;
        }
    }


    class ConfigurationSettings
    {
        private static ExeConfigurationFileMap confFile()
        {
            string szConfigFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"CiscoDeviceInformation\Settings.xml");
            ExeConfigurationFileMap confFile = new ExeConfigurationFileMap();
            confFile.ExeConfigFilename = szConfigFile;
            return confFile;
        }


        /// <summary>
        /// Gets the default storage location.
        /// </summary>
        /// <returns></returns>
        public static string DefaultStoragePath
        {
			get
			{
				string szDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"CiscoDeviceInformation\"); ;
				string szFile = "DeviceSettings.dat";

				if (!Directory.Exists(szDirectory))
				{
					Directory.CreateDirectory(szDirectory);
				}

				return Path.Combine(szDirectory, szFile);
			}
        }


		/// <summary>
		/// Gets the path to device settings
		/// </summary>
		public static string DeviceSettingsPath
		{
			get
			{
				string szPath = DefaultStoragePath;
				try
				{
					Configuration config = ConfigurationManager.OpenMappedExeConfiguration(confFile(), ConfigurationUserLevel.None);
					if (config.AppSettings.Settings["CentralStoragePath"] != null)
						szPath = config.AppSettings.Settings["CentralStoragePath"].Value;
				}
				catch { }
				return szPath;
			}
			set
			{
				Configuration config = ConfigurationManager.OpenMappedExeConfiguration(confFile(), ConfigurationUserLevel.None);
				if (config.AppSettings.Settings["CentralStoragePath"] != null)
					config.AppSettings.Settings.Remove("CentralStoragePath");

				if (DefaultStoragePath != value)
				{
					config.AppSettings.Settings.Add("CentralStoragePath", value);
				}
				else
				{
					config.AppSettings.Settings.Remove("CentralStoragePath");
				}
				config.Save(ConfigurationSaveMode.Minimal, true);
				ConfigurationManager.RefreshSection("appSettings");
			}
		}


		/// <summary>
		/// Setting for interface descriptions.
		/// </summary>
		/*
		public static bool ShowInterfaceDescriptions
		{
			get
			{
				try
				{
					Configuration config = ConfigurationManager.OpenMappedExeConfiguration(confFile(), ConfigurationUserLevel.None);
					if (config.AppSettings.Settings["ShowInterfaceDescriptions"] != null && Convert.ToBoolean(config.AppSettings.Settings["ShowInterfaceDescriptions"].Value))
					{
						return true;
					}
				}
				catch { }
				return false;
			}
			set
			{
				Configuration config = ConfigurationManager.OpenMappedExeConfiguration(confFile(), ConfigurationUserLevel.None);
				if( config.AppSettings.Settings["ShowInterfaceDescriptions"] != null )
					config.AppSettings.Settings.Remove("ShowInterfaceDescriptions");
				config.AppSettings.Settings.Add("ShowInterfaceDescriptions", value.ToString());
				config.Save(ConfigurationSaveMode.Minimal, true);
				ConfigurationManager.RefreshSection("appSettings");
			}
		}
		*/

		/// <summary>
		/// Setting for whether DNS lookups are enabled or not.
		/// </summary>
		public static bool DNSLookups
		{
			get
			{
				try
				{
					Configuration config = ConfigurationManager.OpenMappedExeConfiguration(confFile(), ConfigurationUserLevel.None);
					if (config.AppSettings.Settings["DNSLookups"] != null && Convert.ToBoolean(config.AppSettings.Settings["DNSLookups"].Value))
					{
						return true;
					}
				}
				catch { }
				return false;
			}
			set
			{
				Configuration config = ConfigurationManager.OpenMappedExeConfiguration(confFile(), ConfigurationUserLevel.None);
				if (config.AppSettings.Settings["DNSLookups"] != null)
					config.AppSettings.Settings.Remove("DNSLookups");
				config.AppSettings.Settings.Add("DNSLookups", value.ToString());
				config.Save(ConfigurationSaveMode.Minimal, true);
				ConfigurationManager.RefreshSection("appSettings");
			}
		}


		/// <summary>
		/// Timeout value (in milliseconds) for SNMP operations.
		/// </summary>
		public static int SNMPTimeout
		{
			get
			{
				try
				{
					Configuration config = ConfigurationManager.OpenMappedExeConfiguration(confFile(), ConfigurationUserLevel.None);
					if (config.AppSettings.Settings["SNMPTimeout"] != null)
					{
						return Convert.ToInt32(config.AppSettings.Settings["SNMPTimeout"].Value);
					}
				}
				catch{}
				return 10000;
			}
			set
			{
				Configuration config = ConfigurationManager.OpenMappedExeConfiguration(confFile(), ConfigurationUserLevel.None);
				if (config.AppSettings.Settings["SNMPTimeout"] != null)
					config.AppSettings.Settings.Remove("SNMPTimeout");
				config.AppSettings.Settings.Add("SNMPTimeout", value.ToString());
				config.Save(ConfigurationSaveMode.Minimal, true);
				ConfigurationManager.RefreshSection("appSettings");
			}
		}
    }
}
