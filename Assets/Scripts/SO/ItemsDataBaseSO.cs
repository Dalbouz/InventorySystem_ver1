using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="ItemSO", menuName ="Item/ItemDataBase")]

public class ItemsDataBaseSO : ScriptableObject
{
    public EquipItemSO[] EquipItems;
    public ConsumableItemSO[] ConsumableItems;
}


