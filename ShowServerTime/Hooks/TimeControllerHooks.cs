using HarmonyLib;
using Il2Cpp;
using Il2CppTMPro;

namespace ShowServerTime.Hooks;

/// <summary>
/// Hooks for TimeController to get server time information
/// </summary>
[HarmonyPatch(typeof(TimeController), nameof(TimeController.Update))]
public class TimeControllerHook
{
    private static void Postfix(TimeController __instance)
    {
        var day = TimeController.previousDay;
        var hour = TimeController.previousHour;
        var minute = TimeController.previousMinute;
        
        // The actual time display update is handled in ModMain.OnUpdate
    }
} 