using BrokeProtocol.API;
using BrokeProtocol.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RoleCommands
{
    public class RegisterCommandsClass
    {
        public void RegisterCommands()
        {
            var RegisteredCommands = Core.Instance.config.data.commands;
            Debug.LogWarning("[RoleCommands] Loading...");

            foreach (CommandFormat command in RegisteredCommands)
            {
                CommandHandler.RegisterCommand(command.name, new Action<ShPlayer, string>(delegate (ShPlayer player, string message)
                {
                    if (command.type == 0)
                    {
                        string format = String.Format(command.format, player.username, player.ID, message);

                        InterfaceHandler.SendGameMessageToAll(format);
                    }
                    else if (command.type == 1)
                    {
                        string format = String.Format(command.format, player.username, player.ID, message);

                        var e = player.svPlayer.GetLocalInRange<ShPlayer>(command.range);

                        foreach (var p in e)
                        {
                            p.svPlayer.SendGameMessage(format);
                        }

                        player.svPlayer.SendGameMessage(format);
                    }
                }), null, null);
            }
            Debug.LogWarning("[RoleCommands] Loaded succesfully...");
        }
    }
}
