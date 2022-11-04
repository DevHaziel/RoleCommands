using BrokeProtocol.API;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrokeProtocol.Entities;

namespace RoleCommands
{
    public class CommandLoader : ManagerEvents
    {
        [Execution(ExecutionMode.Event)]
        public override bool Start()
        {
            Core.Instance.commandHandler.RegisterCommands();
            return true;
        }

        
    }
}
