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
        const string fileName = "SyncConfig.xml";
        public string SourceFolder { get; set; }
        public string DestinationFolder { get; set; }
        /// <summary>
        /// 0: default (normal)
        /// 1: exhaustive
        /// </summary>
        public TraceLevels TraceLevel { get; set; }

        public static SyncConfig ReadConfig()
        {
            SyncConfig retValue = null;
            string path = FullPath;
            if (!File.Exists(path))
            {
                retValue = new SyncConfig();
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
        static string FullPath
        {
            get { return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName); }
        }
        public static void WriteConfig(SyncConfig syncConfig)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SyncConfig));
            using (StreamWriter textWriter = new StreamWriter(FullPath))
                xmlSerializer.Serialize(textWriter, syncConfig);
        }
    }
}
