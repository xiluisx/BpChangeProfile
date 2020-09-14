using BPPlasticSurgery.ExtensionMethods;
using BrokeProtocol.API;
using BrokeProtocol.Entities;
using BrokeProtocol.Managers;
using BrokeProtocol.Utility;
using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace BPPlasticSurgery.RegisteredEvents
{
    public class OnLeave : IScript
    {
        [Target(GameSourceEvent.PlayerDestroy, ExecutionMode.Event)]
        public void OnEvent(ShPlayer player)
        {
            if (player.GetExtendedPlayerPs().Skin != null)
            {
                int skin = MonoBehaviourSingleton<SceneManager>.Instance.entityCollection.FirstOrDefault(x => x.Value.name == player.GetExtendedPlayerPs().Skin).Key;
                Core.Instance.Logger.Log(skin.ToString());
                string accId = player.username;
                Core.Instance.PlayerHandler.Remove(player.ID);
                Core.Instance.SvManager.StartCoroutine(MethodTimer(2, delegate ()
                {
                    Core.Instance.SvManager.TryGetUserData(accId, out var user);
                    user.Character.SkinIndex = skin;
                    Core.Instance.SvManager.database.Users.Upsert(user);
                }));
            }
            else
            {
                Core.Instance.PlayerHandler.Remove(player.ID);
            }
        }

        private IEnumerator MethodTimer(int time, Action action)
        {
            yield return new WaitForSecondsRealtime(time);
            action.Invoke();
        }
    }
}