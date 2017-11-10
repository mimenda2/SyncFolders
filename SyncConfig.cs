using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace SyncFolders
{
    public enum TraceLevels
    {
        Normal = 0,
        All = 1
    }
    public class SyncConfig
    {
        /// <summary>
        /// Conf file name
        /// </summary>
        const string fileName = "SyncConfig.xml";
        /// <summary>
        /// Last source folder
        /// </summary>
        public string SourceFolder { get; set; }
        /// <summary>
        /// Last destination folder
        /// </summary>
        public string DestinationFolder { get; set; }
        /// <summary>
        /// Ignore files
        /// </summary>
        public List<string> IgnoreFiles { get; set; }
        /// <summary>
        /// 0: default (normal)
        /// 1: exhaustive
        /// </summary>
        public TraceLevels TraceLevel { get; set; }
        /// <summary>
        /// Read the configuration
        /// </summary>
        /// <returns></returns>
        public static SyncConfig ReadConfig()
        {
            SyncConfig retValue = null;
            string path = FullPath;
            if (!File.Exists(path))
            {
                retValue = new SyncConfig();
                retValue.IgnoreFiles = new List<string>()
                {
                    "Thumbs.db"
                };
                WriteConfig(retValue);
            }
            else
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(SyncConfig));
                using (StreamReader textReader = new StreamReader(path))
                    retValue = xmlSerializer.Deserialize(textReader) as SyncConfig;

            }
            return retValue;
        }
        /// <summary>
        /// PAth to save the conf file
        /// </summary>
        static string FullPath
        {
            get { return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName); }
        }
        /// <summary>
        /// Save the conf file
        /// </summary>
        /// <param name="syncConfig"></param>
        public static void WriteConfig(SyncConfig syncConfig)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SyncConfig));
            using (StreamWriter textWriter = new StreamWriter(FullPath))
                xmlSerializer.Serialize(textWriter, syncConfig);
        }
    }
}
