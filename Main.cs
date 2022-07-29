using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using HarmonyLib;
using BepInEx.IL2CPP;
using BepInEx.Logging;

namespace RF5_AxeHarvest
{
	[BepInPlugin(GUID, NAME, VERSION)]
	[BepInProcess(GAME_PROCESS)]
	public class Main : BasePlugin
	{
		#region PluginInfo
		private const string GUID = "34A85B08-B01E-B507-8262-32619D84AA37";
		private const string NAME = "RF5_AxeHarvest";
		private const string VERSION = "1.0.1";
		private const string GAME_PROCESS = "Rune Factory 5.exe";
		#endregion

		public static new ManualLogSource Log;
		public static HashSet<CropID> TreeCropIds;

		public override void Load()
		{
			Log = base.Log;
			SetupTreeCropIds();
			new Harmony(GUID).PatchAll();
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
}
