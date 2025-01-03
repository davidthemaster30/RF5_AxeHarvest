using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;

namespace RF5_AxeHarvest;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
[BepInProcess(GAME_PROCESS)]
public class Main : BasePlugin
{
	public static new ManualLogSource Log;
	public static HashSet<CropID> TreeCropIds;
	private const string GAME_PROCESS = "Rune Factory 5.exe";

	public override void Load()
	{
		Log = base.Log;
		SetupTreeCropIds();
		new Harmony(MyPluginInfo.PLUGIN_GUID).PatchAll();
	}

	private void SetupTreeCropIds()
	{
		TreeCropIds = new HashSet<CropID> {
				CropID.CROP_GLITTERTREE,
				CropID.CROP_GLITTERTREE_BIG,
				CropID.CROP_GLITTERTREE_KING,
				CropID.CROP_APPLETREE,
				CropID.CROP_APPLETREE_BIG,
				CropID.CROP_APPLETREE_KING,
				CropID.CROP_ORANGETREE,
				CropID.CROP_ORANGETREE_BIG,
				CropID.CROP_ORANGETREE_KING,
				CropID.CROP_GRAPETREE,
				CropID.CROP_GRAPETREE_BIG,
				CropID.CROP_GRAPETREE_KING
			};
	}
}
