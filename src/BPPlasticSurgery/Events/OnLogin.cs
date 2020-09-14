using BrokeProtocol.API;
using BrokeProtocol.Entities;
using System;

namespace BPPlasticSurgery.RegisteredEvents
{
    public class OnLogin : IScript
    {
        [Target(GameSourceEvent.PlayerInitialize, ExecutionMode.Event)]
        public void OnEvent(ShPlayer player)
        {
            Core.Instance.PlayerHandler.AddOrReplace(player);
        }
    }
}