using BrokeProtocol.API;
using BrokeProtocol.Entities;
using BrokeProtocol.Utility.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BPPlasticSurgery.Commands
{
    internal class Skins : IScript
    {
        public Skins()
        {
            List<string> cmds = new List<string> { "skins", "skinlist" };
            CommandHandler.RegisterCommand(cmds, new Action<ShPlayer>(OnCommandInvoke), null, nameof(Skins));
            Core.Instance.Logger.LogInfo("Registered " + nameof(Skins));
        }

        public void OnCommandInvoke(ShPlayer player)
        {
            string list = "";
            player.manager.skinPrefabs.ToList().ForEach(x => list += x.name + "\n");
            player.svPlayer.SendTextPanel("Skin List", list);
        }
    }
}