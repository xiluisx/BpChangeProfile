using BrokeProtocol.Entities;
using BrokeProtocol.Utility;
using System;
using System.Collections.Generic;

namespace BPPlasticSurgery.ExtendedPlayer
{
    [Serializable]
    public class PlayerItem : BPCoreLib.Abstractions.ExtendedPlayer
    {
        public PlayerItem(ShPlayer player) : base(player)
        {
        }

        public string Skin { get; set; }
    }
}