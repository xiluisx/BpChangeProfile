using BPPlasticSurgery;
using BPPlasticSurgery.ExtendedPlayer;
using BrokeProtocol.Entities;
using BrokeProtocol.Utility;
using BrokeProtocol.Utility.Networking;

namespace BPPlasticSurgery.ExtensionMethods
{
    public static class ExtensionPlayer
    {
        public static PlayerItem GetExtendedPlayerPs(this ShPlayer player)
        {
            return Core.Instance.PlayerHandler.GetSafe(player.ID);
        }
    }
}