using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace RF5_AxeHarvest
{
	[HarmonyPatch(typeof(Farm.CellController), nameof(Farm.CellController.CanChop))]
	public class CellControllerCanChop
	{
		static bool Prefix(Farm.CellController __instance, ref bool __result)
		{
			__result = __instance.plantStatus.PlantStatusLevel > 0 && Main.TreeCropIds.Contains((CropID)__instance.CropData.CropID);
			__result = __result || __instance.plantStatus.IsStatusMax();
			return false;
		}
	}

	[HarmonyPatch(typeof(Farm.CellController), nameof(Farm.CellController.DoChop))]
	public class CellControllerDoChop
	{
		static bool Prefix(HumanController humanController, Farm.CellController __instance)
		{
			bool isTree = Main.TreeCropIds.Contains((CropID)__instance.CropData.CropID);
			bool canHarvest = Farm.FarmManager.Instance.rf4FreeFarmCropPickupOkCheck(__instance.FarmId, __instance.CellSetId, __instance.CellId, true);
			bool haveProduct = __instance.CropData.HarvestItemID != ItemID.ITEM_EMPTY;
			Main.Log.LogDebug(string.Format("DoChop CropID:{0}, IsTree:{1}, CanHarvest:{2}, HaveProduct:{3}", __instance.CropData.CropID, isTree, canHarvest, haveProduct));

			// 如果是树且没有果实
			if (isTree && (!canHarvest || !haveProduct))
				return true;

			__instance.Harvest(humanController, true);
			return false;
		}
	}
}
