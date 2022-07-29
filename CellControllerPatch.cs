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
			__result = __instance.plantStatus.PlantStatusLevel > 0 && (__instance.CropData.CropType & (int)CROP_TYPE.RF4_CROP_TYPE_TREE) != 0;
			__result = __result || __instance.plantStatus.IsStatusMax();
			return false;
		}
	}

	[HarmonyPatch(typeof(Farm.CellController), nameof(Farm.CellController.DoChop))]
	public class CellControllerDoChop
	{
		static bool Prefix(HumanController humanController, Farm.CellController __instance)
		{
			// 如果是树且没有果实
			if ((__instance.CropData.CropType & (int)CROP_TYPE.RF4_CROP_TYPE_TREE) != 0 &&
				!Farm.FarmManager.Instance.rf4FreeFarmCropPickupOkCheck(__instance.FarmId, __instance.CellSetId, __instance.CellId, true))
				return true;

			__instance.Harvest(humanController, true);
			return false;
		}
	}
}
