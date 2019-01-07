using Harmony;
using UnityEngine;

namespace SubnauticaModTest1
{
    [HarmonyPatch(typeof(Player))]
    [HarmonyPatch("Update")]
    internal class Player_Update_Patch
    {
        [HarmonyPostfix]
        public static void Postfix()
        {
            if (Input.GetKeyDown(KeyCode.F2))
            {
                IngameMenu.main.SaveGame();
                IngameMenu.main.QuitSubscreen(); // Previous call can cause a 'ghost menu' to be brought up and invisible. This closes it.

            }
        }

        [HarmonyPostfix]
        public static void Heal()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                Player.main.liveMixin.ResetHealth();
            }
        }
    }

    // -----------------------------------------------------------------------------------------------------------------------------

    [HarmonyPatch(typeof(LiveMixin))]
    [HarmonyPatch("TakeDamage")]
    internal class Player_Health_Patch
    {
        [HarmonyPrefix]
        public static bool Preifx()
        {
            Player.main.liveMixin.ResetHealth();
            return false;   // This will also prevent any FX - Use Postfix if you don't want this.
        }
    }
}
