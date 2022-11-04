using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrokeProtocol.API;
using BrokeProtocol.Managers;

namespace RoleCommands
{
    public class Core : Plugin
    {
        public static Core Instance { get; set; }
        public SvManager SvManager { get; set; }

        public RegisterCommandsClass commandHandler { get; set; } = new RegisterCommandsClass();


        public ConfigFile config { get; set; } = new ConfigFile();
        public Core()
        {
            Instance = this;
            Info = new PluginInfo("Role Command", "rcmd")
            {
                Description = "Basic roleplay commands plugin",
                Website = ""
            };

            config.Load();
        }
    }
}
