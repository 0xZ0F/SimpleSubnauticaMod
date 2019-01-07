using System.Reflection;
using Harmony;

// You can use this file almost as-is. Just change the marked lines below. This will be the main file of each mod that tells Harmony to load your changes.
namespace SubnauticaModTest1     // Change this line to match your mod.
{
    public class MainPatcher
    {
        public static void Patch()
        {
            var harmony = HarmonyInstance.Create("com.z0f.subnautica.test.mod");   // Change this line to match your mod. 
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

    }
}