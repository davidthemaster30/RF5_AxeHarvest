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
		private const string VERSION = "1.0";
		private const string GAME_PROCESS = "Rune Factory 5.exe";
		#endregion

		public static new ManualLogSource Log;

		public override void Load()
		{
			Log = base.Log;
			new Harmony(GUID).PatchAll();
		}
	}
}
