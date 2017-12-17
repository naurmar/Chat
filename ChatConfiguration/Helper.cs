using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using ModelsLibrary;

namespace ChatConfiguration
{
    internal class Helper
    {
        //Get local IPAddress and Port 4000
        internal static IPEndPoint GetIPEndPoint()
        {
            foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (IPA.AddressFamily.ToString() == "InterNetwork")
                {
                    return new IPEndPoint(IPA, 4000);
                }
            }
            return null;
        }

        //Get sound
        public static SoundPlayer GetMessageReceivedPlayer()
        {
            try
            {
                return new SoundPlayer(@"C:\Windows\Media\chimes.wav");
            }
            catch (Exception)
            {
                return null;
            }
        }

        //exePath is the full path + application name
        public void UpdateConfig(string key, string value, string exePath)
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(exePath);
            configFile.AppSettings.Settings[key].Value = value;
            // configFile.Sections[""].
            configFile.Save();
        }

        internal static DataBaseProvider GetProvider()
        {
            //Read the provider key
            string dataProvidrString = ConfigurationManager.AppSettings["Provider"];

            //Transform string to enum
            DataBaseProvider dataProvider = DataBaseProvider.None;
            if (Enum.IsDefined(typeof(DataBaseProvider), dataProvidrString))
            {
                dataProvider = (DataBaseProvider)Enum.Parse(typeof(DataBaseProvider), dataProvidrString);
                return dataProvider;
            }
            else
            {
                return DataBaseProvider.None;
            }

        }
    }
}
