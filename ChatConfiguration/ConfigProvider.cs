using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Media;
using System.Configuration;
using System.Reflection;
using System.Data;
using ModelsLibrary;

namespace ChatConfiguration
{

    /// <summary>
    /// This class represent Chat Application configuration
    /// </summary>
    public class ConfigProvider
    {
        //IPAddress and Port 
        public static IPEndPoint ConnectionPoint
        {
            get { return Helper.GetIPEndPoint(); }
        }//property

        // Default avatar file path
        public static string DefaultAvatarUrl
        {
            get
            {
                return "Avatar.jpg";
            }
        }

        //Default log folder path
        public static string LogFolder
        {
            get
            {
                return ConfigurationManager.AppSettings["logFolder"] ?? "~/Logs";
            }
        }

        public static string ConnectionString
        {
            get
            {
                string connectionString = null;
                try
                {
                    connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

                }
                catch (Exception)
                {
                    //connectionString = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                }
                return connectionString;
            }
        }

        public static SoundPlayer MessageReceivedPlayer
        {
            get { return Helper.GetMessageReceivedPlayer(); }
        }

        public static DataBaseProvider Provider
        {
            get { return Helper.GetProvider(); }
        }

    }//ConfigProvider
}
