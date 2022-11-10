using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class UnEquip : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite EmptySprite;
    public enum EquipType
    {
        none,
        Head,
        Torso,
        Weapon,
        Shield,
        Boots,
        Ring1,
        Ring2
    }

    public EquipType equiptype;
    public UnityEvent RightClick;
    public UnityEvent LeftClick;
    public void OnPointerClick(PointerEventData eventData)
    {
        /// LEFT CLICK ///
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if(UiManager.instance.ConsumableItem == null)
            {
                switch (equiptype)
                {
                    case EquipType.none:
                        break;
                    case EquipType.Head: ///////////////////// HEAD EQUIP //////////////////////////
                        if (UiManager.instance.EquipItem == null)
                        {
                            if (UiManager.instance.IsHeadEquipped)
                            {
                                UiManager.instance.EquipItem = Player.instance.EquippedHead;
                                UiManager.instance.ImageFolowingMouse.sprite = UiManager.instance.EquipItem.ImageSprite;
                                UiManager.instance.IsItemInTheAir = true;
                                UiManager.instance.ImageFolowingMouse.gameObject.SetActive(true);
                                UiManager.instance.IsHeadEquipped = false;
                                UiManager.instance.Head.sprite = EmptySprite;
                                PlayerAttributesManager.instance.HeadDecrease();
                                Player.instance.EquippedHead = null;
                            }
                        }
                        else
                        {
                            switch (UiManager.instance.EquipItem.itemType)
                            {
                                case EquipItemSO.ItemType.Head:
                                    if (UiManager.instance.IsHeadEquipped) // if the head is alredy equipped, change it with the item on your cursor
                                    {
                                        if (UiManager.instance.EquipItem.GainType == Player.instance.EquippedHead.GainType)
                                        {
                                            PlayerAttributesManager.instance.ExchangeAttributesUponItemExchange();
                                        }
                                        else
                                        {
                                            PlayerAttributesManager.instance.HeadDecrease();
                                            PlayerAttributesManager.instance.IncreaseAttributesUponEquip();
                                        }
                                        UiManager.instance.InventoryIcon.EquipItem = Player.instance.EquippedHead; //Sets all of the info from Equpped Item (SO) to the Inventoryicon SO that was clicked on
                                        UiManager.instance.InventoryIcon.ImageSprite.sprite = UiManager.instance.EquipItem.ImageSprite; //Sets the Sprite of the Equipped item to the Sprite of the Item inside Inventory
                                        Player.instance.EquippedHead = UiManager.instance.EquipItem; //Sets the info from the clicked item that is stored inside "item" to the Player 
                                        UiManager.instance.EquipItem = null; //clear Scriptable object from variable
                                        UiManager.instance.ImageFolowingMouse.gameObject.SetActive(false);
                                        UiManager.instance.IsItemInTheAir = false;
                                        UiManager.instance.Head.sprite = Player.instance.EquippedHead.ImageSprite;// sets the sprite of the Head from the player info EquippedHead
                                    }
                                    else //if the slot is empty
                                    {
                                        PlayerAttributesManager.instance.IncreaseAttributesUponEquip();
                                        GameManager.instance.NumberOfItemsInInvetory -= 1;
                                        Player.instance.EquippedHead = UiManager.instance.EquipItem;
                                        UiManager.instance.EquipItem = null;
                                        UiManager.instance.ImageFolowingMouse.gameObject.SetActive(false);
                                        UiManager.instance.IsItemInTheAir = false;
                                        UiManager.instance.InventoryIcon.EquipItem = null;
                                        UiManager.instance.InventoryIcon.ImageSprite.sprite = InventoryControl.instance.EmptySprite;
                                        UiManager.instance.Head.sprite = Player.instance.EquippedHead.ImageSprite;
                                        UiManager.instance.IsHeadEquipped = true;
                                    }
                                    break;
                                case EquipItemSO.ItemType.Torso:
                                    break;
                                case EquipItemSO.ItemType.Weapon:
                                    break;
                                case EquipItemSO.ItemType.Shield:
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    case EquipType.Torso: ///////////////////// TORSO EQUIP //////////////////////////
                        if (UiManager.instance.EquipItem == null)
                        {
                            if (UiManager.instance.IsTorsoEquipped)
                            {
                                UiManager.instance.EquipItem = Player.instance.EquippedTorso;
                                UiManager.instance.ImageFolowingMouse.sprite = UiManager.instance.EquipItem.ImageSprite;
                                UiManager.instance.IsItemInTheAir = true;
                                UiManager.instance.ImageFolowingMouse.gameObject.SetActive(true);
                                UiManager.instance.IsTorsoEquipped = false;
                                UiManager.instance.Torso.sprite = EmptySprite;
                                PlayerAttributesManager.instance.TorsoDecrease();
                                Player.instance.EquippedTorso = null;
                            }
                        }
                        else
                        {
                            switch (UiManager.instance.EquipItem.itemType)
                            {
                                case EquipItemSO.ItemType.Head:
                                    break;
                                case EquipItemSO.ItemType.Torso:
                                    if (UiManager.instance.IsTorsoEquipped)
                                    {
                                        if (UiManager.instance.EquipItem.GainType == Player.instance.EquippedTorso.GainType)
                                        {
                                            PlayerAttributesManager.instance.ExchangeAttributesUponItemExchange();
                                        }
                                        else
                                        {
                                            PlayerAttributesManager.instance.TorsoDecrease();
                                            PlayerAttributesManager.instance.IncreaseAttributesUponEquip();
                                        }
                                        UiManager.instance.InventoryIcon.EquipItem = Player.instance.EquippedTorso; //uzimam koji head je trenutno equippan
                                        UiManager.instance.InventoryIcon.ImageSprite.sprite = UiManager.instance.EquipItem.ImageSprite; //uzimam sliku koja je na equippu i stavljam na slot unutar inventorja
                                        Player.instance.EquippedTorso = UiManager.instance.EquipItem; //set equipped to selected item from inventory
                                        UiManager.instance.EquipItem = null;
                                        UiManager.instance.ImageFolowingMouse.gameObject.SetActive(false);
                                        UiManager.instance.IsItemInTheAir = false;
                                        UiManager.instance.Torso.sprite = Player.instance.EquippedTorso.ImageSprite;
                                    }
                                    else
                                    {
                                        PlayerAttributesManager.instance.IncreaseAttributesUponEquip();
                                        GameManager.instance.NumberOfItemsInInvetory -= 1;
                                        Player.instance.EquippedTorso = UiManager.instance.EquipItem;
                                        UiManager.instance.EquipItem = null;
                                        UiManager.instance.ImageFolowingMouse.gameObject.SetActive(false);
                                        UiManager.instance.IsItemInTheAir = false;
                                        UiManager.instance.InventoryIcon.EquipItem = null;
                                        UiManager.instance.InventoryIcon.ImageSprite.sprite = InventoryControl.instance.EmptySprite;
                                        UiManager.instance.Torso.sprite = Player.instance.EquippedTorso.ImageSprite;
                                        UiManager.instance.IsTorsoEquipped = true;
                                    }
                                    break;
                                case EquipItemSO.ItemType.Weapon:
                                    break;
                                case EquipItemSO.ItemType.Shield:
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    case EquipType.Weapon:///////////////////// WEAPON EQUIP //////////////////////////
                        if (UiManager.instance.EquipItem == null)
                        {
                            if (UiManager.instance.IsWeaponEquipped)
                            {
                                UiManager.instance.EquipItem = Player.instance.EquippedWeapon;
                                UiManager.instance.ImageFolowingMouse.sprite = UiManager.instance.EquipItem.ImageSprite;
                                UiManager.instance.IsItemInTheAir = true;
                                UiManager.instance.ImageFolowingMouse.gameObject.SetActive(true);
                                UiManager.instance.IsWeaponEquipped = false;
                                UiManager.instance.Weapon.sprite = EmptySprite;
                                PlayerAttributesManager.instance.WeaponDecrease();
                                Player.instance.EquippedWeapon = null;
                            }
                        }
                        else
                        {
                            switch (UiManager.instance.EquipItem.itemType)
                            {
                                case EquipItemSO.ItemType.Head:
                                    break;
                                case EquipItemSO.ItemType.Torso:
                                    break;
                                case EquipItemSO.ItemType.Weapon:
                                    if (UiManager.instance.IsWeaponEquipped)
                                    {
                                        if (UiManager.instance.EquipItem.GainType == Player.instance.EquippedWeapon.GainType)
                                        {
                                            PlayerAttributesManager.instance.ExchangeAttributesUponItemExchange();
                                        }
                                        else
                                        {
                                            PlayerAttributesManager.instance.WeaponDecrease();
                                            PlayerAttributesManager.instance.IncreaseAttributesUponEquip();
                                        }
                                        UiManager.instance.InventoryIcon.EquipItem = Player.instance.EquippedWeapon;
                                        UiManager.instance.InventoryIcon.ImageSprite.sprite = Player.instance.EquippedWeapon.ImageSprite;
                                        Player.instance.EquippedWeapon = UiManager.instance.EquipItem;
                                        UiManager.instance.EquipItem = null;
                                        UiManager.instance.ImageFolowingMouse.gameObject.SetActive(false);
                                        UiManager.instance.IsItemInTheAir = false;
                                        UiManager.instance.Weapon.sprite = Player.instance.EquippedWeapon.ImageSprite;
                                    }
                                    else
                                    {
                                        PlayerAttributesManager.instance.IncreaseAttributesUponEquip();
                                        GameManager.instance.NumberOfItemsInInvetory -= 1;
                                        Player.instance.EquippedWeapon = UiManager.instance.EquipItem;
                                        UiManager.instance.EquipItem = null;
                                        UiManager.instance.ImageFolowingMouse.gameObject.SetActive(false);
                                        UiManager.instance.IsItemInTheAir = false;
                                        UiManager.instance.InventoryIcon.EquipItem = null;
                                        UiManager.instance.InventoryIcon.ImageSprite.sprite = InventoryControl.instance.EmptySprite;
                                        UiManager.instance.Weapon.sprite = Player.instance.EquippedWeapon.ImageSprite;
                                        UiManager.instance.IsWeaponEquipped = true;
                                    }
                                    break;
                                case EquipItemSO.ItemType.Shield:
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    case EquipType.Shield:///////////////////// SHIELD EQUIP //////////////////////////
                        if (UiManager.instance.EquipItem == null)
                        {
                            if (UiManager.instance.IsShieldEquipped)
                            {
                                UiManager.instance.EquipItem = Player.instance.EquippedShield;
                                UiManager.instance.ImageFolowingMouse.sprite = UiManager.instance.EquipItem.ImageSprite;
                                UiManager.instance.IsItemInTheAir = true;
                                UiManager.instance.ImageFolowingMouse.gameObject.SetActive(true);
                                UiManager.instance.IsShieldEquipped = false;
                                UiManager.instance.Shield.sprite = EmptySprite;
                                PlayerAttributesManager.instance.ShieldDecrease();
                                Player.instance.EquippedShield = null;
                            }
                        }
                        else
                        {
                            switch (UiManager.instance.EquipItem.itemType)
                            {
                                case EquipItemSO.ItemType.Head:
                                    break;
                                case EquipItemSO.ItemType.Torso:
                                    break;
                                case EquipItemSO.ItemType.Weapon:
                                    break;
                                case EquipItemSO.ItemType.Shield:
                                    if (UiManager.instance.IsShieldEquipped)
                                    {
                                        if (UiManager.instance.EquipItem.GainType == Player.instance.EquippedShield.GainType)
                                        {
                                            PlayerAttributesManager.instance.ExchangeAttributesUponItemExchange();
                                        }
                                        else
                                        {
                                            PlayerAttributesManager.instance.ShieldDecrease();
                                            PlayerAttributesManager.instance.IncreaseAttributesUponEquip();
                                        }
                                        UiManager.instance.InventoryIcon.EquipItem = Player.instance.EquippedShield; //uzimam koji head je trenutno equippan
                                        UiManager.instance.InventoryIcon.ImageSprite.sprite = Player.instance.EquippedShield.ImageSprite; //uzimam sliku koja je na equippu i stavljam na slot unutar inventorja
                                        Player.instance.EquippedShield = UiManager.instance.EquipItem; //set equipped to selected item from inventory
                                        UiManager.instance.EquipItem = null;
                                        UiManager.instance.ImageFolowingMouse.gameObject.SetActive(false);
                                        UiManager.instance.IsItemInTheAir = false;
                                        UiManager.instance.Shield.sprite = Player.instance.EquippedShield.ImageSprite;
                                    }
                                    else
                                    {
                                        PlayerAttributesManager.instance.IncreaseAttributesUponEquip();
                                        GameManager.instance.NumberOfItemsInInvetory -= 1;
                                        Player.instance.EquippedShield = UiManager.instance.EquipItem;
                                        UiManager.instance.EquipItem = null;
                                        UiManager.instance.ImageFolowingMouse.gameObject.SetActive(false);
                                        UiManager.instance.IsItemInTheAir = false;
                                        UiManager.instance.InventoryIcon.EquipItem = null;
                                        UiManager.instance.InventoryIcon.ImageSprite.sprite = InventoryControl.instance.EmptySprite;
                                        UiManager.instance.Shield.sprite = Player.instance.EquippedShield.ImageSprite;
                                        UiManager.instance.IsShieldEquipped = true;
                                    }
                                    break;
                            }
                        }
                        break;
                    case EquipType.Boots:///////////////////// BOOTS EQUIP //////////////////////////
                        if (UiManager.instance.EquipItem == null)
                        {
                            if (UiManager.instance.IsBootsEquipped)
                            {
                                UiManager.instance.EquipItem = Player.instance.EquippedBoots;
                                UiManager.instance.ImageFolowingMouse.sprite = UiManager.instance.EquipItem.ImageSprite;
                                UiManager.instance.IsItemInTheAir = true;
                                UiManager.instance.ImageFolowingMouse.gameObject.SetActive(true);
                                UiManager.instance.IsBootsEquipped = false;
                                UiManager.instance.Boots.sprite = EmptySprite;
                                PlayerAttributesManager.instance.BootsDecrease();
                                Player.instance.EquippedBoots = null;
                            }
                        }
                        else
                        {
                            switch (UiManager.instance.EquipItem.itemType)
                            {
                                case EquipItemSO.ItemType.Head:
                                    break;
                                case EquipItemSO.ItemType.Torso:
                                    break;
                                case EquipItemSO.ItemType.Weapon:
                                    break;
                                case EquipItemSO.ItemType.Shield:
                                    break;
                                case EquipItemSO.ItemType.Boots:
                                    if (UiManager.instance.IsBootsEquipped)
                                    {
                                        if (UiManager.instance.EquipItem.GainType == Player.instance.EquippedBoots.GainType)
                                        {
                                            PlayerAttributesManager.instance.ExchangeAttributesUponItemExchange();
                                        }
                                        else
                                        {
                                            PlayerAttributesManager.instance.BootsDecrease();
                                            PlayerAttributesManager.instance.IncreaseAttributesUponEquip();
                                        }
                                        UiManager.instance.InventoryIcon.EquipItem = Player.instance.EquippedBoots; //uzimam koji boots je trenutno equippan
                                        UiManager.instance.InventoryIcon.ImageSprite.sprite = Player.instance.EquippedBoots.ImageSprite; //uzimam sliku koja je na equippu i stavljam na slot unutar inventorja
                                        Player.instance.EquippedBoots = UiManager.instance.EquipItem; //set equipped to selected item from inventory
                                        UiManager.instance.EquipItem = null;
                                        UiManager.instance.ImageFolowingMouse.gameObject.SetActive(false);
                                        UiManager.instance.IsItemInTheAir = false;
                                        UiManager.instance.Boots.sprite = Player.instance.EquippedBoots.ImageSprite;
                                    }
                                    else
                                    {
                                        PlayerAttributesManager.instance.IncreaseAttributesUponEquip();
                                        GameManager.instance.NumberOfItemsInInvetory -= 1;
                                        Player.instance.EquippedBoots = UiManager.instance.EquipItem;
                                        UiManager.instance.EquipItem = null;
                                        UiManager.instance.ImageFolowingMouse.gameObject.SetActive(false);
                                        UiManager.instance.IsItemInTheAir = false;
                                        UiManager.instance.InventoryIcon.EquipItem = null;
                                        UiManager.instance.InventoryIcon.ImageSprite.sprite = InventoryControl.instance.EmptySprite;
                                        UiManager.instance.Boots.sprite = Player.instance.EquippedBoots.ImageSprite;
                                        UiManager.instance.IsBootsEquipped = true;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    case EquipType.Ring1:///////////////////// RING1 EQUIP //////////////////////////
                        if (UiManager.instance.EquipItem == null)
                        {
                            if (UiManager.instance.IsRing1Equipped)
                            {
                                UiManager.instance.EquipItem = Player.instance.EquippedRing1;
                                UiManager.instance.ImageFolowingMouse.sprite = UiManager.instance.EquipItem.ImageSprite;
                                UiManager.instance.IsItemInTheAir = true;
                                UiManager.instance.ImageFolowingMouse.gameObject.SetActive(true);
                                UiManager.instance.IsRing1Equipped = false;
                                UiManager.instance.Ring1.sprite = EmptySprite;
                                PlayerAttributesManager.instance.Ring1Decrease();
                                Player.instance.EquippedRing1 = null;
                            }
                        }
                        else
                        {
                            switch (UiManager.instance.EquipItem.itemType)
                            {
                                case EquipItemSO.ItemType.Head:
                                    break;
                                case EquipItemSO.ItemType.Torso:
                                    break;
                                case EquipItemSO.ItemType.Weapon:
                                    break;
                                case EquipItemSO.ItemType.Shield:
                                    break;
                                case EquipItemSO.ItemType.Boots:
                                    break;
                                case EquipItemSO.ItemType.Ring:
                                    if (UiManager.instance.IsRing1Equipped)
                                    {
                                        if (UiManager.instance.EquipItem.GainType == Player.instance.EquippedRing1.GainType)
                                        {
                                            PlayerAttributesManager.instance.ExchangeAttributesUponItemExchange();
                                        }
                                        else
                                        {
                                            PlayerAttributesManager.instance.BootsDecrease();
                                            PlayerAttributesManager.instance.IncreaseAttributesUponEquip();
                                        }
                                        UiManager.instance.InventoryIcon.EquipItem = Player.instance.EquippedRing1; //uzimam koji boots je trenutno equippan
                                        UiManager.instance.InventoryIcon.ImageSprite.sprite = Player.instance.EquippedRing1.ImageSprite; //uzimam sliku koja je na equippu i stavljam na slot unutar inventorja
                                        Player.instance.EquippedRing1 = UiManager.instance.EquipItem; //set equipped to selected item from inventory
                                        UiManager.instance.EquipItem = null;
                                        UiManager.instance.ImageFolowingMouse.gameObject.SetActive(false);
                                        UiManager.instance.IsItemInTheAir = false;
                                        UiManager.instance.Ring1.sprite = Player.instance.EquippedRing1.ImageSprite;
                                    }
                                    else
                                    {
                                        PlayerAttributesManager.instance.IncreaseAttributesUponEquip();
                                        GameManager.instance.NumberOfItemsInInvetory -= 1;
                                        Player.instance.EquippedRing1 = UiManager.instance.EquipItem;
                                        UiManager.instance.EquipItem = null;
                                        UiManager.instance.ImageFolowingMouse.gameObject.SetActive(false);
                                        UiManager.instance.IsItemInTheAir = false;
                                        UiManager.instance.InventoryIcon.EquipItem = null;
                                        UiManager.instance.InventoryIcon.ImageSprite.sprite = InventoryControl.instance.EmptySprite;
                                        UiManager.instance.Ring1.sprite = Player.instance.EquippedRing1.ImageSprite;
                                        UiManager.instance.IsRing1Equipped = true;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    case EquipType.Ring2:///////////////////// RING2 EQUIP //////////////////////////
                        if (UiManager.instance.EquipItem == null)
                        {
                            if (UiManager.instance.IsRing2Equipped)
                            {
                                UiManager.instance.EquipItem = Player.instance.EquippedRing2;
                                UiManager.instance.ImageFolowingMouse.sprite = UiManager.instance.EquipItem.ImageSprite;
                                UiManager.instance.IsItemInTheAir = true;
                                UiManager.instance.ImageFolowingMouse.gameObject.SetActive(true);
                                UiManager.instance.IsRing2Equipped = false;
                                UiManager.instance.Ring2.sprite = EmptySprite;
                                PlayerAttributesManager.instance.Ring2Decrease();
                                Player.instance.EquippedRing2 = null;
                            }
                        }
                        else
                        {
                            switch (UiManager.instance.EquipItem.itemType)
                            {
                                case EquipItemSO.ItemType.Head:
                                    break;
                                case EquipItemSO.ItemType.Torso:
                                    break;
                                case EquipItemSO.ItemType.Weapon:
                                    break;
                                case EquipItemSO.ItemType.Shield:
                                    break;
                                case EquipItemSO.ItemType.Boots:
                                    break;
                                case EquipItemSO.ItemType.Ring:
                                    if (UiManager.instance.IsRing2Equipped)
                                    {
                                        if (UiManager.instance.EquipItem.GainType == Player.instance.EquippedRing2.GainType)
                                        {
                                            PlayerAttributesManager.instance.ExchangeAttributesUponItemExchange();
                                        }
                                        else
                                        {
                                            PlayerAttributesManager.instance.Ring2Decrease();
                                            PlayerAttributesManager.instance.IncreaseAttributesUponEquip();
                                        }
                                        UiManager.instance.InventoryIcon.EquipItem = Player.instance.EquippedRing2; //uzimam koji boots je trenutno equippan
                                        UiManager.instance.InventoryIcon.ImageSprite.sprite = Player.instance.EquippedRing2.ImageSprite; //uzimam sliku koja je na equippu i stavljam na slot unutar inventorja
                                        Player.instance.EquippedRing2 = UiManager.instance.EquipItem; //set equipped to selected item from inventory
                                        UiManager.instance.EquipItem = null;
                                        UiManager.instance.ImageFolowingMouse.gameObject.SetActive(false);
                                        UiManager.instance.IsItemInTheAir = false;
                                        UiManager.instance.Ring2.sprite = Player.instance.EquippedRing2.ImageSprite;
                                    }
                                    else
                                    {
                                        PlayerAttributesManager.instance.IncreaseAttributesUponEquip();
                                        GameManager.instance.NumberOfItemsInInvetory -= 1;
                                        Player.instance.EquippedRing2 = UiManager.instance.EquipItem;
                                        UiManager.instance.EquipItem = null;
                                        UiManager.instance.ImageFolowingMouse.gameObject.SetActive(false);
                                        UiManager.instance.IsItemInTheAir = false;
                                        UiManager.instance.InventoryIcon.EquipItem = null;
                                        UiManager.instance.InventoryIcon.ImageSprite.sprite = InventoryControl.instance.EmptySprite;
                                        UiManager.instance.Ring2.sprite = Player.instance.EquippedRing2.ImageSprite;
                                        UiManager.instance.IsRing2Equipped = true;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        ////RIGHT CLICK////
        if (UiManager.instance.EquipItem == null)
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                RightClick.Invoke();
                if(UiManager.instance.ConsumableItem == null)
                {
                    switch (equiptype)
                    {
                        case EquipType.none:
                            break;
                        case EquipType.Head:
                            if (Player.instance.EquippedHead != null)
                            {
                                if (GameManager.instance.NumberOfItemsInInvetory < InventoryControl.instance.NumOfCells)
                                {
                                    PlayerAttributesManager.instance.HeadDecrease();
                                    foreach (InventoryIcon icon in InventoryControl.instance.InventoryItems) //checks all the Icon slots inside the inventory, until it finds an icon thats not populated(empty slot)
                                    {
                                        if (icon.EquipItem == null && icon.ConsumableItem == null) //icon.item gets reference to the scriptable object that is created inside InventoryIcon and checks is the slot in inspector empty(null)
                                        {
                                            GameManager.instance.NumberOfItemsInInvetory += 1;
                                            icon.GetComponent<Image>().sprite = Player.instance.EquippedHead.ImageSprite; // if its empty then set the sprite of the picked item to the empty slot, give that slot all the info from Scriptable object, and break from the loop
                                            icon.EquipItem = Player.instance.EquippedHead; // gives the icon inside inventory all the info about the item that is holding (from scriptable object)
                                            UiManager.instance.Head.sprite = EmptySprite;
                                            Player.instance.EquippedHead = null;
                                            UiManager.instance.IsHeadEquipped = false;
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    Debug.Log("Inventory is Full, cant add any more items");
                                }
                            }
                            break;
                        case EquipType.Torso:
                            if (Player.instance.EquippedTorso != null)
                            {
                                if (GameManager.instance.NumberOfItemsInInvetory < InventoryControl.instance.NumOfCells)
                                {
                                    PlayerAttributesManager.instance.TorsoDecrease();

                                    foreach (InventoryIcon icon in InventoryControl.instance.InventoryItems) //checks all the Icon slots inside the inventory, until it finds an icon thats not populated(empty slot)
                                    {
                                        if (icon.EquipItem == null && icon.ConsumableItem == null) //icon.item gets reference to the scriptable object that is created inside InventoryIcon and checks is the slot in inspector empty(null)
                                        {
                                            GameManager.instance.NumberOfItemsInInvetory += 1;
                                            icon.GetComponent<Image>().sprite = Player.instance.EquippedTorso.ImageSprite; // if its empty then set the sprite of the picked item to the empty slot, give that slot all the info from Scriptable object, and break from the loop
                                            icon.EquipItem = Player.instance.EquippedTorso; // gives the icon inside inventory all the info about the item that is holding (from scriptable object)
                                            UiManager.instance.Torso.sprite = EmptySprite;
                                            Player.instance.EquippedTorso = null;
                                            UiManager.instance.IsTorsoEquipped = false;
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    Debug.Log("Inventory is Full, cant add any more items");
                                }
                            }
                            break;
                        case EquipType.Weapon:
                            if (Player.instance.EquippedWeapon)
                            {
                                if (GameManager.instance.NumberOfItemsInInvetory < InventoryControl.instance.NumOfCells)
                                {
                                    PlayerAttributesManager.instance.WeaponDecrease();

                                    foreach (InventoryIcon icon in InventoryControl.instance.InventoryItems) //checks all the Icon slots inside the inventory, until it finds an icon thats not populated(empty slot)
                                    {
                                        if (icon.EquipItem == null && icon.ConsumableItem == null) //icon.item gets reference to the scriptable object that is created inside InventoryIcon and checks is the slot in inspector empty(null)
                                        {
                                            GameManager.instance.NumberOfItemsInInvetory += 1;
                                            icon.GetComponent<Image>().sprite = Player.instance.EquippedWeapon.ImageSprite; // if its empty then set the sprite of the picked item to the empty slot, give that slot all the info from Scriptable object, and break from the loop
                                            icon.EquipItem = Player.instance.EquippedWeapon; // gives the icon inside inventory all the info about the item that is holding (from scriptable object)
                                            UiManager.instance.Weapon.sprite = EmptySprite;
                                            Player.instance.EquippedWeapon = null;
                                            UiManager.instance.IsWeaponEquipped = false;
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    Debug.Log("Inventory is Full, cant add any more items");
                                }
                            }
                            break;
                        case EquipType.Shield:
                            if (Player.instance.EquippedShield)
                            {
                                if (GameManager.instance.NumberOfItemsInInvetory < InventoryControl.instance.NumOfCells)
                                {
                                    PlayerAttributesManager.instance.ShieldDecrease();

                                    foreach (InventoryIcon icon in InventoryControl.instance.InventoryItems) //checks all the Icon slots inside the inventory, until it finds an icon thats not populated(empty slot)
                                    {
                                        if (icon.EquipItem == null && icon.ConsumableItem == null) //icon.item gets reference to the scriptable object that is created inside InventoryIcon and checks is the slot in inspector empty(null)
                                        {
                                            GameManager.instance.NumberOfItemsInInvetory += 1;
                                            icon.GetComponent<Image>().sprite = Player.instance.EquippedShield.ImageSprite; // if its empty then set the sprite of the picked item to the empty slot, give that slot all the info from Scriptable object, and break from the loop
                                            icon.EquipItem = Player.instance.EquippedShield; // gives the icon inside inventory all the info about the item that is holding (from scriptable object)
                                            UiManager.instance.Shield.sprite = EmptySprite;
                                            Player.instance.EquippedShield = null;
                                            UiManager.instance.IsShieldEquipped = false;
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    Debug.Log("Inventory is Full, cant add any more items");
                                }
                            }
                            break;
                        case EquipType.Boots:
                            if (Player.instance.EquippedBoots)
                            {
                                if (GameManager.instance.NumberOfItemsInInvetory < InventoryControl.instance.NumOfCells)
                                {
                                    PlayerAttributesManager.instance.BootsDecrease();

                                    foreach (InventoryIcon icon in InventoryControl.instance.InventoryItems) //checks all the Icon slots inside the inventory, until it finds an icon thats not populated(empty slot)
                                    {
                                        if (icon.EquipItem == null && icon.ConsumableItem == null) //icon.item gets reference to the scriptable object that is created inside InventoryIcon and checks is the slot in inspector empty(null)
                                        {
                                            GameManager.instance.NumberOfItemsInInvetory += 1;
                                            icon.GetComponent<Image>().sprite = Player.instance.EquippedBoots.ImageSprite; // if its empty then set the sprite of the picked item to the empty slot, give that slot all the info from Scriptable object, and break from the loop
                                            icon.EquipItem = Player.instance.EquippedBoots; // gives the icon inside inventory all the info about the item that is holding (from scriptable object)
                                            UiManager.instance.Boots.sprite = EmptySprite;
                                            Player.instance.EquippedBoots = null;
                                            UiManager.instance.IsBootsEquipped = false;
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    Debug.Log("Inventory is Full, cant add any more items");
                                }
                            }
                            break;
                        case EquipType.Ring1:
                            if (Player.instance.EquippedRing1)
                            {
                                if (GameManager.instance.NumberOfItemsInInvetory < InventoryControl.instance.NumOfCells)
                                {
                                    PlayerAttributesManager.instance.Ring1Decrease();

                                    foreach (InventoryIcon icon in InventoryControl.instance.InventoryItems) //checks all the Icon slots inside the inventory, until it finds an icon thats not populated(empty slot)
                                    {
                                        if (icon.EquipItem == null && icon.ConsumableItem == null) //icon.item gets reference to the scriptable object that is created inside InventoryIcon and checks is the slot in inspector empty(null)
                                        {
                                            GameManager.instance.NumberOfItemsInInvetory += 1;
                                            icon.GetComponent<Image>().sprite = Player.instance.EquippedRing1.ImageSprite; // if its empty then set the sprite of the picked item to the empty slot, give that slot all the info from Scriptable object, and break from the loop
                                            icon.EquipItem = Player.instance.EquippedRing1; // gives the icon inside inventory all the info about the item that is holding (from scriptable object)
                                            UiManager.instance.Ring1.sprite = EmptySprite;
                                            Player.instance.EquippedRing1 = null;
                                            UiManager.instance.IsRing1Equipped = false;
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    Debug.Log("Inventory is Full, cant add any more items");
                                }
                            }
                            break;
                        case EquipType.Ring2:
                            if (Player.instance.EquippedRing2)
                            {
                                if (GameManager.instance.NumberOfItemsInInvetory < InventoryControl.instance.NumOfCells)
                                {
                                    PlayerAttributesManager.instance.Ring2Decrease();

                                    foreach (InventoryIcon icon in InventoryControl.instance.InventoryItems) //checks all the Icon slots inside the inventory, until it finds an icon thats not populated(empty slot)
                                    {
                                        if (icon.EquipItem == null && icon.ConsumableItem == null) //icon.item gets reference to the scriptable object that is created inside InventoryIcon and checks is the slot in inspector empty(null)
                                        {
                                            GameManager.instance.NumberOfItemsInInvetory += 1;
                                            icon.GetComponent<Image>().sprite = Player.instance.EquippedRing2.ImageSprite; // if its empty then set the sprite of the picked item to the empty slot, give that slot all the info from Scriptable object, and break from the loop
                                            icon.EquipItem = Player.instance.EquippedRing2; // gives the icon inside inventory all the info about the item that is holding (from scriptable object)
                                            UiManager.instance.Ring2.sprite = EmptySprite;
                                            Player.instance.EquippedRing2 = null;
                                            UiManager.instance.IsRing2Equipped = false;
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    Debug.Log("Inventory is Full, cant add any more items");
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        OpenDurabilityToolTip();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        UiManager.instance.DurabilityInfoScreen.gameObject.SetActive(false);
    }

    public void OpenDurabilityToolTip()
    {
        if (!UiManager.instance.IsItemInTheAir)
        {
            switch (equiptype)
            {
                case EquipType.none:
                    break;
                case EquipType.Head:
                    if (Player.instance.EquippedHead != null)
                    {
                        UiManager.instance.DurabilityInfoScreen.gameObject.SetActive(true);
                        UiManager.instance.DurabilityText.text = "Durability: " + Player.instance.EquippedHead.CurrentDurability.ToString();
                    }
                    break;
                case EquipType.Torso:
                    if (Player.instance.EquippedTorso != null)
                    {
                        UiManager.instance.DurabilityInfoScreen.gameObject.SetActive(true);
                        UiManager.instance.DurabilityText.text = "Durability: " + Player.instance.EquippedTorso.CurrentDurability.ToString();
                    }
                    break;
                case EquipType.Weapon:
                    if (Player.instance.EquippedWeapon != null)
                    {
                        UiManager.instance.DurabilityInfoScreen.gameObject.SetActive(true);
                        UiManager.instance.DurabilityText.text = "Durability: " + Player.instance.EquippedWeapon.CurrentDurability.ToString();
                    }
                    break;
                case EquipType.Shield:
                    if (Player.instance.EquippedShield != null)
                    {
                        UiManager.instance.DurabilityInfoScreen.gameObject.SetActive(true);
                        UiManager.instance.DurabilityText.text = "Durability: " + Player.instance.EquippedShield.CurrentDurability.ToString();
                    }
                    break;
                case EquipType.Boots:
                    if (Player.instance.EquippedBoots != null)
                    {
                        UiManager.instance.DurabilityInfoScreen.gameObject.SetActive(true);
                        UiManager.instance.DurabilityText.text = "Durability: " + Player.instance.EquippedBoots.CurrentDurability.ToString();
                    }
                    break;
                case EquipType.Ring1:
                    if (Player.instance.EquippedRing1 != null)
                    {
                        UiManager.instance.DurabilityInfoScreen.gameObject.SetActive(true);
                        UiManager.instance.DurabilityText.text = "Durability: " + Player.instance.EquippedRing1.CurrentDurability.ToString();
                    }
                    break;
                case EquipType.Ring2:
                    if (Player.instance.EquippedRing2 != null)
                    {
                        UiManager.instance.DurabilityInfoScreen.gameObject.SetActive(true);
                        UiManager.instance.DurabilityText.text = "Durability: " + Player.instance.EquippedRing2.CurrentDurability.ToString();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
