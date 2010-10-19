﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Xml.Serialization;
using System.ComponentModel;

namespace VectorNet.Server
{
    public partial class Server
    {
        public class ConfigurationData
        {
            public bool isAES { get; set; }
            public bool isChallenge { get; set; }
            public bool isIdleSystem { get; set; }

            public int ListenPort { get; set; }
            public string HostedBy { get; set; }
            public string MOTD { get; set; }
        }

        protected ConfigurationData Config = new ConfigurationData();
        protected string ConfigurationFile = "config.xml";

        protected void SaveConfig()
        {
            SaveConfig(ConfigurationFile);
        }

        protected void SaveConfig(string filename)
        {
            XmlSerializer x = new XmlSerializer(Config.GetType());
            using (StreamWriter sw = new StreamWriter(filename))
            {
                x.Serialize(sw, Config);
                sw.Close();
            }
        }

        protected void LoadConfig()
        {
            LoadConfig(ConfigurationFile);
        }

        protected void LoadConfig(string filename)
        {
            XmlSerializer x = new XmlSerializer(Config.GetType());
            if (!File.Exists(filename))
                // Set VectorNet defaults

                Config.HostedBy = null;
                Config.isAES = false;
                Config.isChallenge = false;
                Config.ListenPort = 4800;
                Config.MOTD = null;
                Config.isIdleSystem = false;

                return;
            using (StreamReader sr = new StreamReader(filename))
            {
                Config = (ConfigurationData)x.Deserialize(sr);
                sr.Close();
            }
        }
    }
}
