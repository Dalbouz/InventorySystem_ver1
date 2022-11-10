using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributesManager : MonoBehaviour
{
    public static PlayerAttributesManager instance;
    private ConsumableItemSO _itemHoldBonus;
    private ConsumableItemSO _itemRampValue;
    private ConsumableItemSO _itemTickMannerValue;
    private InventoryIcon _inventoryIcon;
    public bool IsRampConsumableActive = false;
    public bool IsChangeValueOverTimeActive = false;
    private float _currentPlayerAttributeValue;


    [SerializeField]
    private float _rampValueUpTime = 2;
    [SerializeField]
    private float _changeValueOverTime = 3;
    private void Awake()
    {
        if (this.gameObject.activeInHierarchy) instance = this;
    }
    public void Ring2Decrease()
    {
        switch (Player.instance.EquippedRing2.GainType)
        {
            case EquipItemSO.Gains.none:
                break;
            case EquipItemSO.Gains.Strength:
                Player.instance.Strength -= Player.instance.EquippedRing2.AmountGain;
                UiManager.instance.Strength.text = "Strength: " + Player.instance.Strength;
                if (Player.instance.Strength < 0)
                {
                    Player.instance.Strength = 0;
                    UiManager.instance.Strength.text = "Strength: " + Player.instance.Strength;
                }
                break;
            case EquipItemSO.Gains.Dexterity:
                Player.instance.Dexterity -= Player.instance.EquippedRing2.AmountGain;
                UiManager.instance.Dexterity.text = "Dexterity: " + Player.instance.Dexterity;
                if (Player.instance.Dexterity < 0)
                {
                    Player.instance.Dexterity = 0;
                    UiManager.instance.Dexterity.text = "Dexterity: " + Player.instance.Dexterity;
                }
                break;
            case EquipItemSO.Gains.Agility:
                Player.instance.Agility -= Player.instance.EquippedRing2.AmountGain;
                UiManager.instance.Agility.text = "Agility: " + Player.instance.Agility;
                if (Player.instance.Agility < 0)
                {
                    Player.instance.Agility = 0;
                    UiManager.instance.Agility.text = "Agility: " + Player.instance.Agility;
                }
                break;
            case EquipItemSO.Gains.Intelligence:
                Player.instance.Intelligence -= Player.instance.EquippedRing2.AmountGain;
                UiManager.instance.Intelligence.text = "Intelligence: " + Player.instance.Intelligence;
                if (Player.instance.Intelligence < 0)
                {
                    Player.instance.Intelligence = 0;
                    UiManager.instance.Intelligence.text = "Intelligence: " + Player.instance.Intelligence;
                }
                break;
            case EquipItemSO.Gains.Luck:
                Player.instance.Luck -= Player.instance.EquippedRing2.AmountGain;
                UiManager.instance.Luck.text = "Luck: " + Player.instance.Luck;
                if (Player.instance.Luck < 0)
                {
                    Player.instance.Luck = 0;
                    UiManager.instance.Luck.text = "Luck: " + Player.instance.Luck;
                }
                break;
            default:
                break;
        }
    }
    public void Ring1Decrease()
    {
        switch (Player.instance.EquippedRing1.GainType)
        {
            case EquipItemSO.Gains.none:
                break;
            case EquipItemSO.Gains.Strength:
                Player.instance.Strength -= Player.instance.EquippedRing1.AmountGain;
                UiManager.instance.Strength.text = "Strength: " + Player.instance.Strength;
                if (Player.instance.Strength < 0)
                {
                    Player.instance.Strength = 0;
                    UiManager.instance.Strength.text = "Strength: " + Player.instance.Strength;
                }
                break;
            case EquipItemSO.Gains.Dexterity:
                Player.instance.Dexterity -= Player.instance.EquippedRing1.AmountGain;
                UiManager.instance.Dexterity.text = "Dexterity: " + Player.instance.Dexterity;
                if (Player.instance.Dexterity < 0)
                {
                    Player.instance.Dexterity = 0;
                    UiManager.instance.Dexterity.text = "Dexterity: " + Player.instance.Dexterity;
                }
                break;
            case EquipItemSO.Gains.Agility:
                Player.instance.Agility -= Player.instance.EquippedRing1.AmountGain;
                UiManager.instance.Agility.text = "Agility: " + Player.instance.Agility;
                if (Player.instance.Agility < 0)
                {
                    Player.instance.Agility = 0;
                    UiManager.instance.Agility.text = "Agility: " + Player.instance.Agility;
                }
                break;
            case EquipItemSO.Gains.Intelligence:
                Player.instance.Intelligence -= Player.instance.EquippedRing1.AmountGain;
                UiManager.instance.Intelligence.text = "Intelligence: " + Player.instance.Intelligence;
                if (Player.instance.Intelligence < 0)
                {
                    Player.instance.Intelligence = 0;
                    UiManager.instance.Intelligence.text = "Intelligence: " + Player.instance.Intelligence;
                }
                break;
            case EquipItemSO.Gains.Luck:
                Player.instance.Luck -= Player.instance.EquippedRing1.AmountGain;
                UiManager.instance.Luck.text = "Luck: " + Player.instance.Luck;
                if (Player.instance.Luck < 0)
                {
                    Player.instance.Luck = 0;
                    UiManager.instance.Luck.text = "Luck: " + Player.instance.Luck;
                }
                break;
            default:
                break;
        }
    }
    public void HeadDecrease()
    {
        switch (Player.instance.EquippedHead.GainType)
        {
            case EquipItemSO.Gains.none:
                break;
            case EquipItemSO.Gains.Strength:
                Player.instance.Strength -= Player.instance.EquippedHead.AmountGain;
                UiManager.instance.Strength.text = "Strength: " + Player.instance.Strength;
                if (Player.instance.Strength < 0)
                {
                    Player.instance.Strength = 0;
                    UiManager.instance.Strength.text = "Strength: " + Player.instance.Strength;
                }
                break;
            case EquipItemSO.Gains.Dexterity:
                Player.instance.Dexterity -= Player.instance.EquippedHead.AmountGain;
                UiManager.instance.Dexterity.text = "Dexterity: " + Player.instance.Dexterity;
                if (Player.instance.Dexterity < 0)
                {
                    Player.instance.Dexterity = 0;
                    UiManager.instance.Dexterity.text = "Dexterity: " + Player.instance.Dexterity;
                }
                break;
            case EquipItemSO.Gains.Agility:
                Player.instance.Agility -= Player.instance.EquippedHead.AmountGain;
                UiManager.instance.Agility.text = "Agility: " + Player.instance.Agility;
                if (Player.instance.Agility < 0)
                {
                    Player.instance.Agility = 0;
                    UiManager.instance.Agility.text = "Agility: " + Player.instance.Agility;
                }
                break;
            case EquipItemSO.Gains.Intelligence:
                Player.instance.Intelligence -= Player.instance.EquippedHead.AmountGain;
                UiManager.instance.Intelligence.text = "Intelligence: " + Player.instance.Intelligence;
                if (Player.instance.Intelligence < 0)
                {
                    Player.instance.Intelligence = 0;
                    UiManager.instance.Intelligence.text = "Intelligence: " + Player.instance.Intelligence;
                }
                break;
            case EquipItemSO.Gains.Luck:
                Player.instance.Luck -= Player.instance.EquippedHead.AmountGain;
                UiManager.instance.Luck.text = "Luck: " + Player.instance.Luck;
                if (Player.instance.Luck < 0)
                {
                    Player.instance.Luck = 0;
                    UiManager.instance.Luck.text = "Luck: " + Player.instance.Luck;
                }
                break;
            default:
                break;
        }
    }
    public void BootsDecrease()
    {
        switch (Player.instance.EquippedBoots.GainType)
        {
            case EquipItemSO.Gains.none:
                break;
            case EquipItemSO.Gains.Strength:
                Player.instance.Strength -= Player.instance.EquippedBoots.AmountGain;
                UiManager.instance.Strength.text = "Strength: " + Player.instance.Strength;
                if (Player.instance.Strength < 0)
                {
                    Player.instance.Strength = 0;
                    UiManager.instance.Strength.text = "Strength: " + Player.instance.Strength;
                }
                break;
            case EquipItemSO.Gains.Dexterity:
                Player.instance.Dexterity -= Player.instance.EquippedBoots.AmountGain;
                UiManager.instance.Dexterity.text = "Dexterity: " + Player.instance.Dexterity;
                if (Player.instance.Dexterity < 0)
                {
                    Player.instance.Dexterity = 0;
                    UiManager.instance.Dexterity.text = "Dexterity: " + Player.instance.Dexterity;
                }
                break;
            case EquipItemSO.Gains.Agility:
                Player.instance.Agility -= Player.instance.EquippedBoots.AmountGain;
                UiManager.instance.Agility.text = "Agility: " + Player.instance.Agility;
                if (Player.instance.Agility < 0)
                {
                    Player.instance.Agility = 0;
                    UiManager.instance.Agility.text = "Agility: " + Player.instance.Agility;
                }
                break;
            case EquipItemSO.Gains.Intelligence:
                Player.instance.Intelligence -= Player.instance.EquippedBoots.AmountGain;
                UiManager.instance.Intelligence.text = "Intelligence: " + Player.instance.Intelligence;
                if (Player.instance.Intelligence < 0)
                {
                    Player.instance.Intelligence = 0;
                    UiManager.instance.Intelligence.text = "Intelligence: " + Player.instance.Intelligence;
                }
                break;
            case EquipItemSO.Gains.Luck:
                Player.instance.Luck -= Player.instance.EquippedBoots.AmountGain;
                UiManager.instance.Luck.text = "Luck: " + Player.instance.Luck;
                if (Player.instance.Luck < 0)
                {
                    Player.instance.Luck = 0;
                    UiManager.instance.Luck.text = "Luck: " + Player.instance.Luck;
                }
                break;
            default:
                break;
        }
    }
    public void TorsoDecrease()
    {
        switch (Player.instance.EquippedTorso.GainType)
        {
            case EquipItemSO.Gains.none:
                break;
            case EquipItemSO.Gains.Strength:
                Player.instance.Strength -= Player.instance.EquippedTorso.AmountGain;
                UiManager.instance.Strength.text = "Strength: " + Player.instance.Strength;
                if (Player.instance.Strength < 0)
                {
                    Player.instance.Strength = 0;
                    UiManager.instance.Strength.text = "Strength: " + Player.instance.Strength;
                }
                break;
            case EquipItemSO.Gains.Dexterity:
                Player.instance.Dexterity -= Player.instance.EquippedTorso.AmountGain;
                UiManager.instance.Dexterity.text = "Dexterity: " + Player.instance.Dexterity;
                if (Player.instance.Dexterity < 0)
                {
                    Player.instance.Dexterity = 0;
                    UiManager.instance.Dexterity.text = "Dexterity: " + Player.instance.Dexterity;
                }
                break;
            case EquipItemSO.Gains.Agility:
                Player.instance.Agility -= Player.instance.EquippedTorso.AmountGain;
                UiManager.instance.Agility.text = "Agility: " + Player.instance.Agility;
                if (Player.instance.Agility < 0)
                {
                    Player.instance.Agility = 0;
                    UiManager.instance.Agility.text = "Agility: " + Player.instance.Agility;
                }
                break;
            case EquipItemSO.Gains.Intelligence:
                Player.instance.Intelligence -= Player.instance.EquippedTorso.AmountGain;
                UiManager.instance.Intelligence.text = "Intelligence: " + Player.instance.Intelligence;
                if (Player.instance.Intelligence < 0)
                {
                    Player.instance.Intelligence = 0;
                    UiManager.instance.Intelligence.text = "Intelligence: " + Player.instance.Intelligence;
                }
                break;
            case EquipItemSO.Gains.Luck:
                Player.instance.Luck -= Player.instance.EquippedTorso.AmountGain;
                UiManager.instance.Luck.text = "Luck: " + Player.instance.Luck;
                if (Player.instance.Luck < 0)
                {
                    Player.instance.Luck = 0;
                    UiManager.instance.Luck.text = "Luck: " + Player.instance.Luck;
                }
                break;
            default:
                break;
        }
    }
    public void WeaponDecrease()
    {
        switch (Player.instance.EquippedWeapon.GainType)
        {
            case EquipItemSO.Gains.none:
                break;
            case EquipItemSO.Gains.Strength:
                Player.instance.Strength -= Player.instance.EquippedWeapon.AmountGain;
                UiManager.instance.Strength.text = "Strength: " + Player.instance.Strength;
                if (Player.instance.Strength < 0)
                {
                    Player.instance.Strength = 0;
                    UiManager.instance.Strength.text = "Strength: " + Player.instance.Strength;
                }
                break;
            case EquipItemSO.Gains.Dexterity:
                Player.instance.Dexterity -= Player.instance.EquippedWeapon.AmountGain;
                UiManager.instance.Dexterity.text = "Dexterity: " + Player.instance.Dexterity;
                if (Player.instance.Dexterity < 0)
                {
                    Player.instance.Dexterity = 0;
                    UiManager.instance.Dexterity.text = "Dexterity: " + Player.instance.Dexterity;
                }
                break;
            case EquipItemSO.Gains.Agility:
                Player.instance.Agility -= Player.instance.EquippedWeapon.AmountGain;
                UiManager.instance.Agility.text = "Agility: " + Player.instance.Agility;
                if (Player.instance.Agility < 0)
                {
                    Player.instance.Agility = 0;
                    UiManager.instance.Agility.text = "Agility: " + Player.instance.Agility;
                }
                break;
            case EquipItemSO.Gains.Intelligence:
                Player.instance.Intelligence -= Player.instance.EquippedWeapon.AmountGain;
                UiManager.instance.Intelligence.text = "Intelligence: " + Player.instance.Intelligence;
                if (Player.instance.Intelligence < 0)
                {
                    Player.instance.Intelligence = 0;
                    UiManager.instance.Intelligence.text = "Intelligence: " + Player.instance.Intelligence;
                }
                break;
            case EquipItemSO.Gains.Luck:
                Player.instance.Luck -= Player.instance.EquippedShield.AmountGain;
                UiManager.instance.Luck.text = "Luck: " + Player.instance.Luck;
                if (Player.instance.Luck < 0)
                {
                    Player.instance.Luck = 0;
                    UiManager.instance.Luck.text = "Luck: " + Player.instance.Luck;
                }
                break;
            default:
                break;
        }
    }
    public void ShieldDecrease()
    {
        switch (Player.instance.EquippedShield.GainType)
        {
            case EquipItemSO.Gains.none:
                break;
            case EquipItemSO.Gains.Strength:
                Player.instance.Strength -= Player.instance.EquippedShield.AmountGain;
                UiManager.instance.Strength.text = "Strength: " + Player.instance.Strength;
                if (Player.instance.Strength < 0)
                {
                    Player.instance.Strength = 0;
                    UiManager.instance.Strength.text = "Strength: " + Player.instance.Strength;
                }
                break;
            case EquipItemSO.Gains.Dexterity:
                Player.instance.Dexterity -= Player.instance.EquippedShield.AmountGain;
                UiManager.instance.Dexterity.text = "Dexterity: " + Player.instance.Dexterity;
                if (Player.instance.Dexterity < 0)
                {
                    Player.instance.Dexterity = 0;
                    UiManager.instance.Dexterity.text = "Dexterity: " + Player.instance.Dexterity;
                }
                break;
            case EquipItemSO.Gains.Agility:
                Player.instance.Agility -= Player.instance.EquippedShield.AmountGain;
                UiManager.instance.Agility.text = "Agility: " + Player.instance.Agility;
                if (Player.instance.Agility < 0)
                {
                    Player.instance.Agility = 0;
                    UiManager.instance.Agility.text = "Agility: " + Player.instance.Agility;
                }
                break;
            case EquipItemSO.Gains.Intelligence:
                Player.instance.Intelligence -= Player.instance.EquippedShield.AmountGain;
                UiManager.instance.Intelligence.text = "Intelligence: " + Player.instance.Intelligence;
                if (Player.instance.Intelligence < 0)
                {
                    Player.instance.Intelligence = 0;
                    UiManager.instance.Intelligence.text = "Intelligence: " + Player.instance.Intelligence;
                }
                break;
            case EquipItemSO.Gains.Luck:
                Player.instance.Luck -= Player.instance.EquippedShield.AmountGain;
                UiManager.instance.Luck.text = "Luck: " + Player.instance.Luck;
                if (Player.instance.Luck < 0)
                {
                    Player.instance.Luck = 0;
                    UiManager.instance.Luck.text = "Luck: " + Player.instance.Luck;
                }
                break;
            default:
                break;
        }
    }
    public void ExchangeAttributesUponItemExchange()
    {
        switch (UiManager.instance.EquipItem.GainType)
        {
            case EquipItemSO.Gains.none:
                break;
            case EquipItemSO.Gains.Strength:
                Player.instance.Strength = UiManager.instance.EquipItem.AmountGain;
                UiManager.instance.Strength.text = "Strength: " + Player.instance.Strength;
                break;
            case EquipItemSO.Gains.Dexterity:
                Player.instance.Dexterity = UiManager.instance.EquipItem.AmountGain;
                UiManager.instance.Dexterity.text = "Dexterity: " + Player.instance.Dexterity;
                break;
            case EquipItemSO.Gains.Agility:
                Player.instance.Agility = UiManager.instance.EquipItem.AmountGain;
                UiManager.instance.Agility.text = "Agility: " + Player.instance.Agility;
                break;
            case EquipItemSO.Gains.Intelligence:
                Player.instance.Intelligence = UiManager.instance.EquipItem.AmountGain;
                UiManager.instance.Intelligence.text = "Intelligence: " + Player.instance.Intelligence;
                break;
            case EquipItemSO.Gains.Luck:
                Player.instance.Luck = UiManager.instance.EquipItem.AmountGain;
                UiManager.instance.Luck.text = "Luck: " + Player.instance.Luck;
                break;
            default:
                break;
        }
    }
    public void IncreaseAttributesUponEquip()
    {
        switch (UiManager.instance.EquipItem.GainType)
        {
            case EquipItemSO.Gains.none:
                break;
            case EquipItemSO.Gains.Strength:
                Player.instance.Strength += UiManager.instance.EquipItem.AmountGain;
                UiManager.instance.Strength.text = "Strength: " + Player.instance.Strength;
                break;
            case EquipItemSO.Gains.Dexterity:
                Player.instance.Dexterity += UiManager.instance.EquipItem.AmountGain;
                UiManager.instance.Dexterity.text = "Dexterity: " + Player.instance.Dexterity;
                break;
            case EquipItemSO.Gains.Agility:
                Player.instance.Agility += UiManager.instance.EquipItem.AmountGain;
                UiManager.instance.Agility.text = "Agility: " + Player.instance.Agility;
                break;
            case EquipItemSO.Gains.Intelligence:
                Player.instance.Intelligence += UiManager.instance.EquipItem.AmountGain;
                UiManager.instance.Intelligence.text = "Intelligence: " + Player.instance.Intelligence;
                break;
            case EquipItemSO.Gains.Luck:
                Player.instance.Luck += UiManager.instance.EquipItem.AmountGain;
                UiManager.instance.Luck.text = "Luck: " + Player.instance.Luck;
                break;
            default:
                break;
        }
    }

    //////////////////////    CONSUMABLE ITEM     ///////////////////////////
    IEnumerator HoldBonusValueOverTime()
    {
        _itemHoldBonus = UiManager.instance.ConsumableItem;
        _inventoryIcon = UiManager.instance.InventoryIcon;
        UiManager.instance.ConsumableItem = null;
        UiManager.instance.InventoryIcon = null;
        if (_inventoryIcon.Stack == 0)
        {
            _inventoryIcon.StackText.gameObject.SetActive(false);
            _inventoryIcon.ImageSprite.sprite = InventoryControl.instance.EmptySprite;
            _inventoryIcon.Stack = 0;
            _inventoryIcon.ConsumableItem = null;
        }
        switch (_itemHoldBonus.GainType)
        {
            case ConsumableItemSO.Gains.none:
                break;
            case ConsumableItemSO.Gains.Strength:
                Player.instance.Strength += _itemHoldBonus.AmountGain;
                UiManager.instance.Strength.text = "Strength: " + Player.instance.Strength.ToString();
                yield return new WaitForSeconds(_itemHoldBonus.BonusGainTime);
                Player.instance.Strength -= _itemHoldBonus.AmountGain;
                UiManager.instance.Strength.text = "Strength: " + Player.instance.Strength.ToString();
                break;
            case ConsumableItemSO.Gains.Dexterity:
                Player.instance.Dexterity += _itemHoldBonus.AmountGain;
                UiManager.instance.Dexterity.text = "Dexterity: " + Player.instance.Dexterity.ToString();
                yield return new WaitForSeconds(_itemHoldBonus.BonusGainTime);
                Player.instance.Dexterity -= _itemHoldBonus.AmountGain;
                UiManager.instance.Dexterity.text = "Dexterity: " + Player.instance.Dexterity.ToString();
                break;
            case ConsumableItemSO.Gains.Agility:
                Player.instance.Agility += _itemHoldBonus.AmountGain;
                UiManager.instance.Agility.text = "Agility: " + Player.instance.Agility.ToString();
                yield return new WaitForSeconds(_itemHoldBonus.BonusGainTime);
                Player.instance.Agility -= _itemHoldBonus.AmountGain;
                UiManager.instance.Agility.text = "Agility: " + Player.instance.Agility.ToString();
                break;
            case ConsumableItemSO.Gains.Intelligence:
                Player.instance.Intelligence += _itemHoldBonus.AmountGain;
                UiManager.instance.Intelligence.text = "Intelligence: " + Player.instance.Intelligence.ToString();
                yield return new WaitForSeconds(_itemHoldBonus.BonusGainTime);
                Player.instance.Intelligence -= _itemHoldBonus.AmountGain;
                UiManager.instance.Intelligence.text = "Intelligence: " + Player.instance.Intelligence.ToString();
                break;
            case ConsumableItemSO.Gains.Luck:
                Player.instance.Luck += _itemHoldBonus.AmountGain;
                UiManager.instance.Luck.text = "Luck: " + Player.instance.Luck.ToString();
                yield return new WaitForSeconds(_itemHoldBonus.BonusGainTime);
                Player.instance.Luck -= _itemHoldBonus.AmountGain;
                UiManager.instance.Luck.text = "Luck: " + Player.instance.Luck.ToString();
                break;
            default:
                break;
        }
        //_itemHoldBonus = null;
        //_inventoryIcon = null;
    }
    public void StartHoldBonusValueOverTime()
    {
        StartCoroutine(HoldBonusValueOverTime());
    }

    IEnumerator RampValueOverTime()
    {
        IsRampConsumableActive = true;
        _itemRampValue = UiManager.instance.ConsumableItem;
        _inventoryIcon = UiManager.instance.InventoryIcon;
        UiManager.instance.ConsumableItem = null;
        UiManager.instance.InventoryIcon = null;
        var TimeToRamp = _rampValueUpTime / _itemRampValue.AmountGain;
        if (_inventoryIcon.Stack == 0)
        {
            _inventoryIcon.StackText.gameObject.SetActive(false);
            _inventoryIcon.ImageSprite.sprite = InventoryControl.instance.EmptySprite;
            _inventoryIcon.Stack = 0;
            _inventoryIcon.ConsumableItem = null;
        }
        switch (_itemRampValue.GainType)
        {
            case ConsumableItemSO.Gains.none:
                break;
            case ConsumableItemSO.Gains.Strength:
                 _currentPlayerAttributeValue = Player.instance.Strength;
                break;
            case ConsumableItemSO.Gains.Dexterity:
                _currentPlayerAttributeValue = Player.instance.Dexterity;
                break;
            case ConsumableItemSO.Gains.Agility:
                _currentPlayerAttributeValue = Player.instance.Agility;
                break;
            case ConsumableItemSO.Gains.Intelligence:
                _currentPlayerAttributeValue = Player.instance.Intelligence;
                break;
            case ConsumableItemSO.Gains.Luck:
                _currentPlayerAttributeValue = Player.instance.Luck;
                break;
            default:
                break;
        }
        while (IsRampConsumableActive)
        {
            switch (_itemRampValue.GainType)
            {
                case ConsumableItemSO.Gains.none:
                    break;
                case ConsumableItemSO.Gains.Strength:
                    Player.instance.Strength += 1;
                    UiManager.instance.Strength.text = "Strength: " + Player.instance.Strength.ToString();
                    yield return new WaitForSeconds(TimeToRamp);
                    if(Player.instance.Strength == (_itemRampValue.AmountGain + _currentPlayerAttributeValue))
                    {
                        yield return new WaitForSeconds(_itemRampValue.BonusGainTime);
                        Player.instance.Strength -= _itemRampValue.AmountGain;
                        UiManager.instance.Strength.text = "Strength: " + Player.instance.Strength.ToString();
                        IsRampConsumableActive = false;
                    }
                    break;
                case ConsumableItemSO.Gains.Dexterity:
                    Player.instance.Dexterity += 1;
                    UiManager.instance.Dexterity.text = "Dexterity: " + Player.instance.Dexterity.ToString();
                    yield return new WaitForSeconds(TimeToRamp);
                    if (Player.instance.Dexterity == (_itemRampValue.AmountGain + _currentPlayerAttributeValue))
                    {
                        yield return new WaitForSeconds(_itemRampValue.BonusGainTime);
                        Player.instance.Dexterity -= _itemRampValue.AmountGain;
                        UiManager.instance.Dexterity.text = "Dexterity: " + Player.instance.Dexterity.ToString();
                        IsRampConsumableActive = false;
                    }
                    break;
                case ConsumableItemSO.Gains.Agility:
                    Player.instance.Agility += 1;
                    UiManager.instance.Agility.text = "Agility: " + Player.instance.Agility.ToString();
                    yield return new WaitForSeconds(TimeToRamp);
                    if (Player.instance.Agility == (_itemRampValue.AmountGain + _currentPlayerAttributeValue))
                    {
                        yield return new WaitForSeconds(_itemRampValue.BonusGainTime);
                        Player.instance.Agility -= _itemRampValue.AmountGain;
                        UiManager.instance.Agility.text = "Agility: " + Player.instance.Agility.ToString();
                        IsRampConsumableActive = false;
                    }
                    break;
                case ConsumableItemSO.Gains.Intelligence:
                    Player.instance.Intelligence += 1;
                    UiManager.instance.Intelligence.text = "Intelligence: " + Player.instance.Intelligence.ToString();
                    yield return new WaitForSeconds(TimeToRamp);
                    if (Player.instance.Intelligence == (_itemRampValue.AmountGain + _currentPlayerAttributeValue))
                    {
                        yield return new WaitForSeconds(_itemRampValue.BonusGainTime);
                        Player.instance.Intelligence -= _itemRampValue.AmountGain;
                        UiManager.instance.Intelligence.text = "Intelligence: " + Player.instance.Intelligence.ToString();
                        IsRampConsumableActive = false;
                    }
                    break;
                case ConsumableItemSO.Gains.Luck:
                    Player.instance.Luck += 1;
                    UiManager.instance.Luck.text = "Luck: " + Player.instance.Luck.ToString();
                    yield return new WaitForSeconds(TimeToRamp);
                    if (Player.instance.Luck == (_itemRampValue.AmountGain + _currentPlayerAttributeValue))
                    {
                        yield return new WaitForSeconds(_itemRampValue.BonusGainTime);
                        Player.instance.Luck -= _itemRampValue.AmountGain;
                        UiManager.instance.Luck.text = "Luck: " + Player.instance.Luck.ToString();
                        IsRampConsumableActive = false;
                    }
                    break;
                default:
                    break;
            }
        }
        _itemRampValue = null;
        _inventoryIcon = null;
    }

    public void StartRampValueOverTime()
    {
        StartCoroutine(RampValueOverTime());
    }

    IEnumerator ChangeValueOverTime()
    {
        IsChangeValueOverTimeActive = true;
        _itemTickMannerValue = UiManager.instance.ConsumableItem;
        _inventoryIcon = UiManager.instance.InventoryIcon;
        UiManager.instance.ConsumableItem = null;
        UiManager.instance.InventoryIcon = null;
        var Timer =Mathf.Abs(_changeValueOverTime / _itemTickMannerValue.AmountGain);
        if (_inventoryIcon.Stack == 0)
        {
            _inventoryIcon.StackText.gameObject.SetActive(false);
            _inventoryIcon.ImageSprite.sprite = InventoryControl.instance.EmptySprite;
            _inventoryIcon.Stack = 0;
            _inventoryIcon.ConsumableItem = null;
        }
        while (IsChangeValueOverTimeActive)
        {
            switch (_itemTickMannerValue.GainType)
            {
                case ConsumableItemSO.Gains.none:
                    break;
                case ConsumableItemSO.Gains.Strength:
                    break;
                case ConsumableItemSO.Gains.Dexterity:
                    break;
                case ConsumableItemSO.Gains.Agility:
                    break;
                case ConsumableItemSO.Gains.Intelligence:
                    break;
                case ConsumableItemSO.Gains.Health:
                    UiManager.instance.HealthBar.value += _itemTickMannerValue.AmountGain / Mathf.Abs(_itemTickMannerValue.AmountGain);
                    Player.instance.CurrentHealth += _itemTickMannerValue.AmountGain / Mathf.Abs(_itemTickMannerValue.AmountGain);
                    yield return new WaitForSeconds(Timer);
                    if (Player.instance.CurrentHealth == Mathf.Abs(_itemTickMannerValue.AmountGain))
                    {
                        UiManager.instance.HealthBar.value += Mathf.Abs(_itemTickMannerValue.AmountGain);
                        Player.instance.CurrentHealth = Player.instance.MaxHealth;
                        IsChangeValueOverTimeActive = false;
                    }
                    break;
                case ConsumableItemSO.Gains.Mana:
                    UiManager.instance.ManaBar.value += _itemTickMannerValue.AmountGain / Mathf.Abs(_itemTickMannerValue.AmountGain);
                    Player.instance.CurrentMana += _itemTickMannerValue.AmountGain / Mathf.Abs(_itemTickMannerValue.AmountGain);
                    yield return new WaitForSeconds(Timer);
                    if (Player.instance.CurrentMana == Mathf.Abs(_itemTickMannerValue.AmountGain))
                    {
                        UiManager.instance.ManaBar.value += Mathf.Abs(_itemTickMannerValue.AmountGain);
                        Player.instance.CurrentMana = Player.instance.MaxMana;
                        IsChangeValueOverTimeActive = false;
                    }
                    break;
                case ConsumableItemSO.Gains.Luck:
                    break;
                default:
                    break;
            }
        }
        _itemTickMannerValue = null;
        _inventoryIcon = null;
    }
    public void StartChangeValueOverTime()
    {
        StartCoroutine(ChangeValueOverTime());
    }
}
