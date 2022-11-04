using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleCommands
{
    public class ConfigFile
    {
        public ConfigModel data { get; set; }

        public void Load()
        {
            if (!File.Exists(Path.Combine("Plugins", "RoleCommands", "Config.json")))
            {
                Save();
                return;
            }
            data = JsonConvert.DeserializeObject<ConfigModel>(File.ReadAllText(Path.Combine("Plugins", "RoleCommands", "Config.json")));
        }
        public void Save()
        {
            if (!Directory.Exists(Path.Combine("Plugins", "RoleCommands"))) Directory.CreateDirectory(Path.Combine("Plugins", "RoleCommands"));

            if(!File.Exists(Path.Combine("Plugins", "RoleCommands", "Config.json")))
            {
                ConfigModel cfg = new ConfigModel()
                {
                    commands = new List<CommandFormat>()
                    {
                        new CommandFormat()
                        {
                            name = "anon",
                            type = 0,
                            range = 0f,
                            format = "&4[&fANON&4] &fUnknown User &4=> &f{2}",
                            description = ""
                        },
                        new CommandFormat()
                        {
                            name = "crime",
                            type = 0,
                            range = 0f,
                            format = "&4[&fCRIME&4] &fUnknown User &4=> &f{2}",
                            description = ""
                        },
                        new CommandFormat()
                        {
                            name = "mega",
                            type = 0,
                            range = 0f,
                            format = "&1[&fPOLICE&1] &f{0} &1=> &f{2}",
                            description = ""
                        },
                        new CommandFormat()
                        {
                            name = "ooc",
                            type = 0,
                            range = 0f,
                            format = "&c[&fOOC&c] &2[&f{1}&2] &f{0} &c=> &f{2}",
                            description = ""
                        },

                        new CommandFormat()
                        {
                            name = "me",
                            type = 1,
                            range = 40f,
                            format = "&b[&fME&b] &f{0} &b=> &f{2}",
                            description = ""
                        },
                        new CommandFormat()
                        {
                            name = "do",
                            type = 1,
                            range = 40f,
                            format = "&6[&fDO&6] &f{0} &6=> &f{2}",
                            description = ""
                        }
                    }
                };

                File.WriteAllText(Path.Combine("Plugins", "RoleCommands", "Config.json"), JsonConvert.SerializeObject(cfg, Formatting.Indented));

            }
            data = JsonConvert.DeserializeObject<ConfigModel>(File.ReadAllText(Path.Combine("Plugins", "RoleCommands", "Config.json")));

        }
    }

    public class ConfigModel
    {
        public List<CommandFormat> commands { get; set; }
    }
    public class CommandFormat
    {
        public string name { get; set; }
        public int type { get; set; }
        public float range { get; set; }
        public string format { get; set; }
        public string description { get; set; }
    }
}
