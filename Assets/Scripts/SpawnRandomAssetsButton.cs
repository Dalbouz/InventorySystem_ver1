using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomAssetsButton : MonoBehaviour
{
    public ItemsDataBaseSO ItemDataBaseSO;

    public void SpawnRandomAssets()
    {
        Vector2 RandPos = new Vector2(Player.instance.transform.position.x + Random.Range(-5, 5), Player.instance.transform.position.y + Random.Range(-5, 5));
        int Rand;
        int RandType = Random.Range(0, 2);
        if(RandType == 0)
        {
            Rand = Random.Range(0, ItemDataBaseSO.EquipItems.Length);
            Instantiate(ItemDataBaseSO.EquipItems[Rand].ItemPrefab, RandPos, Quaternion.identity);
            ItemDataBaseSO.EquipItems[Rand].CurrentDurability = ItemDataBaseSO.EquipItems[Rand].MaximumDurability;
        }
        else
        {
            Rand = Random.Range(0, ItemDataBaseSO.ConsumableItems.Length);
            Instantiate(ItemDataBaseSO.ConsumableItems[Rand].ItemPrefab, RandPos, Quaternion.identity);
        }
    }
}
