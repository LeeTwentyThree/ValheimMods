using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;

namespace Minions
{
    internal class Patches
    {
        private static string _greylingIdentifier = "$enemy_greyling";

        [HarmonyPatch(typeof(Humanoid), "Start")]
        [HarmonyPostfix()]
        internal void GreylingBehaviourPatch(Humanoid __instance)
        {
            if (__instance.m_name != _greylingIdentifier)
            {
                return;
            }
            __instance.transform.localScale *= 5f;
        }
    }
}
