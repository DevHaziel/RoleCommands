using BrokeProtocol.API;
using BrokeProtocol.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleCommands.Commands
{
    public class reload : IScript
    {
        public reload()
        {
            CommandHandler.RegisterCommand("reload", new Action<ShPlayer>(onCommand), null, null);
        }

        public void onCommand(ShPlayer player)
        {
            Core.Instance.config.Load();
            Core.Instance.commandHandler.RegisterCommands();
        }
    }
}
