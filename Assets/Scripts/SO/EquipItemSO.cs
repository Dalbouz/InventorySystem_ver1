using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Item/EquippableItem")]

public class EquipItemSO : ScriptableObject
{
    [Header("Basic Item Settings")]
    public ItemType itemType;
    public GameObject ItemPrefab;
    public Sprite ImageSprite;
    [Header("Item Durability Settings")]
    public int MaximumDurability;
    public int CurrentDurability;
    [Header("Attribute Gain Settings")]
    public Gains GainType;
    public int AmountGain;
    public ItemsSoDIsplay ItemsInfoDisplay;
    public enum ItemType
    {
        Head,
        Torso,
        Weapon,
        Shield,
        Boots,
        Ring
    }

    public enum Gains
    {
        none,
        Strength,
        Dexterity,
        Agility,
        Intelligence,
        Health,
        Mana,
        Luck
    }
 
}
