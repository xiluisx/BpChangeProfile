using BPPlasticSurgery.ExtensionMethods;
using BrokeProtocol.API;
using BrokeProtocol.Entities;
using BrokeProtocol.Utility.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BPPlasticSurgery.Commands
{
    internal class ChangeSkin : IScript
    {
        public ChangeSkin()
        {
            List<string> cmds = new List<string> { "changeskin", "plasticsurgery" };
            CommandHandler.RegisterCommand(cmds, new Action<ShPlayer, string, ShPlayer>(OnCommandInvoke), null, nameof(ChangeSkin));
            Core.Instance.Logger.LogInfo("Registered " + nameof(ChangeSkin));
        }

        public void OnCommandInvoke(ShPlayer player, string Skin, ShPlayer target = null)
        {
            if (target != player && !player.svPlayer.HasPermission(Core.Instance.Info.GroupNamespace + ".changeothersskin"))
            {
                player.svPlayer.Send(SvSendType.Self, Channel.Unsequenced, ClPacket.GameMessage, "You can only change your skin");
                return;
            }
            target = target ?? player;
            if (player.manager.skinPrefabs.FirstOrDefault(x => x.name.ToLower() == Skin.ToLower()) == null)
            {
                player.svPlayer.Send(SvSendType.Self, Channel.Unsequenced, ClPacket.GameMessage, "Skin not found");
                return;
            }
            target.GetExtendedPlayerPs().Skin = player.manager.skinPrefabs.FirstOrDefault(x => x.name.ToLower() == Skin.ToLower()).name;
            target.svPlayer.Send(SvSendType.Self, Channel.Unsequenced, ClPacket.GameMessage, "Reconnect to apply new skin.");
        }
    }
}