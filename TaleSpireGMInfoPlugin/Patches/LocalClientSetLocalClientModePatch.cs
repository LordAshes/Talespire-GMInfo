using System.Collections.Generic;
using HarmonyLib;
using TMPro;
using UnityEngine;

namespace GMInfoPlugin.Patches
{
    [HarmonyPatch(typeof(LocalClient), "SetLocalClientMode")]
    internal sealed class LocalClientSetLocalClientModePatch
    {
        internal static List<GameObject> TrackedTexts = new List<GameObject>();

        public static void Postfix(ref ClientMode mode)
        {
            var enabled = mode == ClientMode.GameMaster;
            for (var index = 0; index < TrackedTexts.Count; index++)
                TrackedTexts[index].GetComponent<TextMeshPro>().enabled = enabled;
        }
    }

    [HarmonyPatch(typeof(CreaturePresenter), "OnCreatureDeleted")]
    internal sealed class CreaturePresenterOnCreatureDeleted
    {
        public static void Postfix()
        {
            LocalClientSetLocalClientModePatch.TrackedTexts.RemoveAll(null);
        }
    }

}
