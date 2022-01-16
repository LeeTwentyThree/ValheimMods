using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;

namespace Minions
{
    [HarmonyPatch()]
    public static class Patches
    {
        private static string _greylingIdentifier = "$enemy_greyling";

        [HarmonyPatch(typeof(Humanoid), "Start")]
        [HarmonyPostfix]
        public static void GreylingBehaviourPatch(Humanoid __instance)
        {
            if (__instance.m_name != _greylingIdentifier)
            {
                return;
            }
            ModifyGreyling(__instance);
        }

        private static void ModifyGreyling(Humanoid greyling)
        {
            Debug.Log("Modifying greyling!");
            var ai = greyling.gameObject.GetComponent<MonsterAI>();
            ai.m_consumeItems = new List<ItemDrop>() { };
            ai.m_consumeRange = 1f;
            ai.m_consumeSearchRange = 10f;
            ai.m_consumeSearchInterval = 3f;
            greyling.gameObject.AddComponent<MinionBehaviour>();
        }

        [HarmonyPatch(typeof(MonsterAI), "CanConsume")]
        [HarmonyPostfix]
        public static void GreylingCanConsumePatch(MonsterAI __instance, ItemDrop.ItemData item, ref bool __result)
        {
            var mc = __instance.gameObject.GetComponent<MinionBehaviour>();
            if (mc == null)
            {
                return;
            }
            __result = item.m_shared.m_name == "$item_coins";
        }
    }
}
