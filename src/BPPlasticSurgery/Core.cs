using BPCoreLib.Interfaces;
using BPCoreLib.Util;
using BrokeProtocol.API;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using BrokeProtocol.Managers;
using BrokeProtocol.Entities;
using BPPlasticSurgery.ExtendedPlayer;

namespace BPPlasticSurgery
{
    public class Core : Plugin
    {
        public static Core Instance { get; internal set; }

        public static string Version { get; } = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;

        public BPCoreLib.PlayerFactory.ExtendedPlayerFactory<PlayerItem> PlayerHandler { get; internal set; } = new ExtendedPlayerFactory();

        public ILogger Logger { get; } = new Logger();

        public SvManager SvManager { get; set; }

        public Core()
        {
            Instance = this;
            Info = new PluginInfo("BPPlasticSurgery", "PS")
            {
                Description = "Allows players to change how they look."
            };
            SetCutsomData();

            EventsHandler.Add("ps:version", new Action<string>(OnVersionRequest));
            Logger.LogInfo($"BP Plastic Surgery v{Version} loaded in successfully!");
        }

        private void SetCutsomData()
        {
            CustomData.AddOrUpdate("version", Version);
        }

        public void OnVersionRequest(string callback)
        {
            if (callback.StartsWith("ps:"))
            {
                return;
            }
            EventsHandler.Exec(callback, Version);
        }
    }
}