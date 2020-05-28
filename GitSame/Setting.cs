using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;

namespace GitSame
{
    [DataContract]
    class Setting
    {
        [DataMember]
        public List<string> filters { get; set; }
        [DataMember]
        public bool allowRegExp { get; set; }
        [DataMember]
        public bool findAutoplagiat { get; set; }
        private static Setting instance;

        private static string settingPath;
        private Setting()
        {
            settingPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GitSame");
            settingPath = Path.Combine(settingPath, "setting.json");
            filters = new List<string>();
        }

        public bool isInFilters(string str)
        {
            var tokens = str.Split('/');
            foreach (var i in tokens)
            {
                if (allowRegExp)
                {
                    foreach (var filter in filters)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(i, filter))
                            return true;
                    }
                }
                else
                {
                    if (filters.Contains(i))
                        return true;
                }
            }
            return false;
        }

        public static Setting getInstance()
        {
            if (instance == null)
            {
                instance = new Setting();
                try
                {
                    if (File.Exists(settingPath))
                    {
                        using (FileStream file = new FileStream(settingPath, FileMode.Open, System.IO.FileAccess.Read))
                        {
                            var ser = new DataContractJsonSerializer(instance.GetType());
                            instance = ser.ReadObject(file) as Setting;
                            if (instance == null)
                                instance = new Setting();
                        }
                    }
                }
                catch
                {

                }
            }

            return instance;
        }
        ~Setting()
        {
            using (FileStream file = new FileStream(settingPath, FileMode.Create, System.IO.FileAccess.Write))
            {
                var ser = new DataContractJsonSerializer(typeof(Setting));
                ser.WriteObject(file, instance);
            }

        }
    }
}
