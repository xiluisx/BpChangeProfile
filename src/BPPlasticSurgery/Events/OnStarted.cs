using BrokeProtocol.API;
using BrokeProtocol.Managers;
using System;

namespace BPPlasticSurgery.RegisteredEvents
{
    public class OnStarted : IScript
    {
        [Target(GameSourceEvent.ManagerStart, ExecutionMode.Event)]
        public void OnEvent(SvManager svManager)
        {
            Core.Instance.SvManager = svManager;
        }
    }
}
