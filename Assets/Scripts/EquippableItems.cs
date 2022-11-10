using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquippableItems : MonoBehaviour
{
    public EquipItemSO EquipItem;
    //private Vector2 _centar;
    //private float _radius = 5;
    
    private void Start()
    {
        //_centar = transform.position;
        EquipItem.CurrentDurability = EquipItem.MaximumDurability;

    }

    //private void PlayerCheckInRadius()
    //{
    //    Collider2D hitColliders = Physics2D.OverlapCircle(_centar, _radius, 1 << LayerMask.NameToLayer(Strings.Player));
    //    if()
    //}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(Strings.Player))
        {
            AddtoInventory();
        }
    }
    public void AddtoInventory()
    {
            switch (EquipItem.itemType)
            {
                case EquipItemSO.ItemType.Head:
                if (!UiManager.instance.IsHeadEquipped) //if this is false, it will execute, if the head is not yet equipped
                {
                    IncreaseCharacterAttribute();
                    Player.instance.EquippedHead = EquipItem; //player gets all the info from Scriptable object that it picked up, and saved inside EquippedHead
                    UiManager.instance.Head.sprite = EquipItem.ImageSprite; // UI manager sets the sprite of the Head to the sprite from Scriptable object
                    UiManager.instance.IsHeadEquipped = true; //sets true until the items is not removed from the slot
                    Destroy(this.gameObject);
                }
                else
                {
                    SetEquippableItemIntoInventory(); 
                }
                break;
            case EquipItemSO.ItemType.Torso:
                if (!UiManager.instance.IsTorsoEquipped)
                {
                    IncreaseCharacterAttribute();
                    Player.instance.EquippedTorso = EquipItem;
                    UiManager.instance.Torso.sprite = EquipItem.ImageSprite;
                    UiManager.instance.IsTorsoEquipped = true;
                    Destroy(this.gameObject);
                }
                else
                {
                    SetEquippableItemIntoInventory();
                }
                break;
            case EquipItemSO.ItemType.Weapon:
                    if (!UiManager.instance.IsWeaponEquipped)
                    {
                        IncreaseCharacterAttribute();
                        Player.instance.EquippedWeapon = EquipItem;
                        UiManager.instance.Weapon.sprite = EquipItem.ImageSprite;
                        UiManager.instance.IsWeaponEquipped = true;
                        Destroy(this.gameObject);
                    }
                    else
                    {
                        SetEquippableItemIntoInventory();
                    }
                break;
                case EquipItemSO.ItemType.Shield:
                    if (!UiManager.instance.IsShieldEquipped)
                    {
                        IncreaseCharacterAttribute();
                        Player.instance.EquippedShield = EquipItem;
                        UiManager.instance.Shield.sprite = EquipItem.ImageSprite;
                        UiManager.instance.IsShieldEquipped = true;
                        Destroy(this.gameObject);
                    }
                    else
                    {
                        SetEquippableItemIntoInventory();
                    }
                break;
            case EquipItemSO.ItemType.Boots:
                if (!UiManager.instance.IsBootsEquipped)
                {
                    IncreaseCharacterAttribute();
                    Player.instance.EquippedBoots = EquipItem;
                    UiManager.instance.Boots.sprite = EquipItem.ImageSprite;
                    UiManager.instance.IsBootsEquipped = true;
                    Destroy(this.gameObject);
                }
                else
                {
                    SetEquippableItemIntoInventory();
                }
                break;
            case EquipItemSO.ItemType.Ring:
                if (!UiManager.instance.IsRing1Equipped || !UiManager.instance.IsRing2Equipped)
                {
                    if (!UiManager.instance.IsRing1Equipped && UiManager.instance.IsRing2Equipped)
                    {
                        IncreaseCharacterAttribute();
                        Player.instance.EquippedRing1 = EquipItem;
                        UiManager.instance.Ring1.sprite = EquipItem.ImageSprite;
                        UiManager.instance.IsRing1Equipped = true;
                        Destroy(this.gameObject);
                    }
                    else if (!UiManager.instance.IsRing1Equipped)
                    {
                        IncreaseCharacterAttribute();
                        Player.instance.EquippedRing1 = EquipItem;
                        UiManager.instance.Ring1.sprite = EquipItem.ImageSprite;
                        UiManager.instance.IsRing1Equipped = true;
                        Destroy(this.gameObject);
                    }
                    else if (!UiManager.instance.IsRing2Equipped)
                    {
                        IncreaseCharacterAttribute();
                        Player.instance.EquippedRing2 = EquipItem;
                        UiManager.instance.Ring2.sprite = EquipItem.ImageSprite;
                        UiManager.instance.IsRing2Equipped = true;
                        Destroy(this.gameObject);
                    }
                }
                else
                {
                    SetEquippableItemIntoInventory();
                }
                break;
            default:
                    break;
            }
    
    }
  IEnumerator InventoryFullMessage()
    {
        UiManager.instance.InventoryFullMessage.SetActive(true);
        yield return new WaitForSeconds(3);
        UiManager.instance.InventoryFullMessage.SetActive(false);
    }
    public void MinorSpeedBoost()
    {
        Player.instance.SpeedMovement = Player.instance.SpeedBoost;
        Debug.Log("Player picked up a powerUp:" + EquipItem.ItemsInfoDisplay.ItemName + "the duration is:" + Player.instance.PowerUpDuration + "Seconds");
        
    }

    public void SetEquippableItemIntoInventory()
    {
        if (GameManager.instance.NumberOfItemsInInvetory == InventoryControl.instance.NumOfCells)
        {
            Debug.LogError("cell count is equal inventory count, cant add any more items to inventory");
            StartCoroutine(InventoryFullMessage());
        }
        else
        {
            foreach (InventoryIcon icon in InventoryControl.instance.InventoryItems) //checks all the Icon slots inside the inventory, until it finds an icon thats not populated(empty slot)
            {
                if (icon.EquipItem == null && icon.ConsumableItem == null) //icon.item gets reference to the scriptable object that is created inside InventoryIcon and checks is the slot in inspector empty(null)
                {
                    GameManager.instance.NumberOfItemsInInvetory += 1;
                    icon.ImageSprite.sprite = EquipItem.ImageSprite; // if its empty then set the sprite of the picked item to the empty slot, give that slot all the info from Scriptable object, and break from the loop
                    icon.EquipItem = EquipItem; // gives the icon inside inventory all the info about the item that is holding (from scriptable object)
                    break;
                }
            }
            Destroy(this.gameObject);
        }
    }

    public void IncreaseCharacterAttribute() {
        switch (EquipItem.GainType)
        {
            case EquipItemSO.Gains.none:
                break;
            case EquipItemSO.Gains.Strength:
                Player.instance.Strength += EquipItem.AmountGain;
                UiManager.instance.Strength.text = "Strength: " + Player.instance.Strength;
                break;
            case EquipItemSO.Gains.Dexterity:
                Player.instance.Dexterity += EquipItem.AmountGain;
                UiManager.instance.Dexterity.text = "Dexterity: " + Player.instance.Dexterity;
                break;
            case EquipItemSO.Gains.Agility:
                Player.instance.Agility += EquipItem.AmountGain;
                UiManager.instance.Agility.text = "Agility: " + Player.instance.Agility;
                break;
            case EquipItemSO.Gains.Intelligence:
                Player.instance.Intelligence += EquipItem.AmountGain;
                UiManager.instance.Intelligence.text = "Intelligence: " + Player.instance.Intelligence;
                break;
            case EquipItemSO.Gains.Luck:
                Player.instance.Luck += EquipItem.AmountGain;
                UiManager.instance.Luck.text = "Luck: " + Player.instance.Luck;
                break;
            default:
                break;
        }
    }

}

