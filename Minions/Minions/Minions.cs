using BepInEx;
using HarmonyLib;

namespace Minions
{
    [BepInPlugin(modGUID, "Minions", "1.0.0.0")]
    [BepInProcess("valheim.exe")]
    public class Minions : BaseUnityPlugin
    {
        // consts
        public const string modGUID = "Lee23.MinionsMod";

        private readonly Harmony harmony = new Harmony(modGUID);

        public void Awake()
        {
            harmony.PatchAll();
        }
    }
}