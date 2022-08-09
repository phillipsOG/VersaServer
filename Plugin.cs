using BepInEx;
using BepInEx.IL2CPP;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;

namespace VersaServer
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BasePlugin
    {
        public static ManualLogSource Logger;
        public static WebServer webServer;
        private Harmony _harmony;
        
        public Plugin()
        {
            
        }

        public override void Load()
        {
            _harmony = Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());
            Logger = Log;
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            webServer = new WebServer(8080);
            webServer.Start();
        }

        public override bool Unload()
        {
            webServer.Stop();
            return base.Unload();
        }
    }
}
