using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ItemSO", menuName = "Item/ConsumableItem")]

public class ConsumableItemSO : ScriptableObject
{
    [Header("Basic Item Settings")]
    public ItemType itemType;
    public GameObject ItemPrefab;
    public Sprite ImageSprite;
    [Header("Attribute Gain Settings")]
    public Gains GainType;
    public int AmountGain;
    [Header("Consumable item Settings")]
    public bool LimitlessItem;
    public int BonusGainTime;
    public bool HoldBonusValueOverTime;
    public bool RampValueOverTime;
    public bool ChangeValueOverTime;
    public ItemsSoDIsplay ItemsInfoDisplay;
    public bool IsItemInInvetory;

    public enum ItemType
    {
        PowerUp,
        Consumable
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
    public enum PowerUpType
    {
        none,
        MinorSpeedBoost
    }
    [Header("PowerUp Item Settings")]
    public PowerUpType PowerUpTypes;
}
