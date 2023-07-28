using System.Reflection;
using HarmonyLib;

namespace GorillaShaders;

public class HarmonyPatches
{
	private static Harmony instance;
	public const string InstanceId = "com.notfishvr.gorillashaders";
	public static bool IsPatched { get; private set; }
	internal static void ApplyHarmonyPatches()
	{
		if (!IsPatched)
		{
			if (instance == null)
			{
				instance = new Harmony("com.notfishvr.gorillashaders");
			}
			instance.PatchAll(Assembly.GetExecutingAssembly());
			IsPatched = true;
		}
	}
	internal static void RemoveHarmonyPatches()
	{
		if (instance != null && IsPatched)
		{
			instance.UnpatchSelf();
			IsPatched = false;
		}
	}
}
