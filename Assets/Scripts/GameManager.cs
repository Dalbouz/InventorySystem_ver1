using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int StackLimit = 4;

    public int NumberOfItemsInInvetory;

    public Sprite EmptyHeadSprite;
    public Sprite EmptyTorsoSprite;
    public Sprite EmptyWeaponSprite;
    public Sprite EmptyShieldSprite;
    public Sprite EmptyBootsSprite;
    public Sprite EmptyRingSprite;
    public bool IsInputEnabled = true;
    private void Start()
    {
        InventoryControl.instance.FillGrid();
    }
    private void Awake()
    {
          if(gameObject.activeInHierarchy) instance=this;
    }

    private void Update()
    {
        if (UiManager.instance.IsItemInTheAir)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (UiManager.instance.ConsumableItem!=null)
                {
                    UiManager.instance.InventoryIcon.StackText.gameObject.SetActive(true);
                    UiManager.instance.InventoryIcon.ImageSprite.sprite = UiManager.instance.ConsumableItem.ImageSprite;
                    UiManager.instance.InventoryIcon.ConsumableItem = UiManager.instance.ConsumableItem;
                    UiManager.instance.ConsumableItem = null;
                    UiManager.instance.IsItemInTheAir = false;
                    UiManager.instance.ImageFolowingMouse.gameObject.SetActive(false);
                    UiManager.instance.StackTekstFolowingMouse.gameObject.SetActive(false);
                }
                else if(UiManager.instance.EquipItem != null)
                {
                    UiManager.instance.InventoryIcon.ImageSprite.sprite = UiManager.instance.EquipItem.ImageSprite;
                    UiManager.instance.InventoryIcon.EquipItem = UiManager.instance.EquipItem;
                    UiManager.instance.EquipItem = null;
                    UiManager.instance.IsItemInTheAir = false;
                    UiManager.instance.ImageFolowingMouse.gameObject.SetActive(false);
                    UiManager.instance.StackTekstFolowingMouse.gameObject.SetActive(false);
                }
            }
            UiManager.instance.CheckIfDropedItemOrClosedPanel();
        }

        if (Input.GetKeyDown(KeyCode.I)) UiManager.instance.OpenInventoryScreen();
        if (Input.GetKeyDown(KeyCode.E)) UiManager.instance.OpenEquipScreen();
        if (Input.GetKeyDown(KeyCode.C)) UiManager.instance.OpenPlayerStats();
    }

    public void ItemDurability()
    {
        if (Player.instance.EquippedHead != null)
        {

            Player.instance.EquippedHead.CurrentDurability -= 1;
            if (Player.instance.EquippedHead.CurrentDurability == 0)
            {
                UiManager.instance.Head.sprite = EmptyHeadSprite;
                PlayerAttributesManager.instance.HeadDecrease();
                Player.instance.EquippedHead = null;
                UiManager.instance.IsHeadEquipped = false;
            }
        }
        if (Player.instance.EquippedTorso != null)
        {

            Player.instance.EquippedTorso.CurrentDurability -= 1;
            if (Player.instance.EquippedTorso.CurrentDurability == 0)
            {
                UiManager.instance.Torso.sprite = EmptyTorsoSprite;
                PlayerAttributesManager.instance.TorsoDecrease();
                Player.instance.EquippedTorso = null;
                UiManager.instance.IsTorsoEquipped = false;
            }
        }
        if (Player.instance.EquippedWeapon != null)
        {

            Player.instance.EquippedWeapon.CurrentDurability -= 1;
            if (Player.instance.EquippedWeapon.CurrentDurability == 0)
            {
                UiManager.instance.Weapon.sprite = EmptyWeaponSprite;
                PlayerAttributesManager.instance.WeaponDecrease();
                Player.instance.EquippedWeapon = null;
                UiManager.instance.IsWeaponEquipped = false;
            }
        }
        if (Player.instance.EquippedShield != null)
        {

            Player.instance.EquippedShield.CurrentDurability -= 1;
            if (Player.instance.EquippedShield.CurrentDurability == 0)
            {
                UiManager.instance.Shield.sprite = EmptyShieldSprite;
                PlayerAttributesManager.instance.ShieldDecrease();
                Player.instance.EquippedShield = null;
                UiManager.instance.IsShieldEquipped = false;
            }
        }
        if (Player.instance.EquippedBoots != null)
        {

            Player.instance.EquippedBoots.CurrentDurability -= 1;
            if (Player.instance.EquippedBoots.CurrentDurability == 0)
            {
                UiManager.instance.Boots.sprite = EmptyBootsSprite;
                PlayerAttributesManager.instance.BootsDecrease();
                Player.instance.EquippedBoots = null;
                UiManager.instance.IsBootsEquipped = false;
            }
        }
        if (Player.instance.EquippedRing1 != null)
        {

            Player.instance.EquippedRing1.CurrentDurability -= 1;
            if (Player.instance.EquippedRing1.CurrentDurability == 0)
            {
                UiManager.instance.Ring1.sprite = EmptyRingSprite;
                PlayerAttributesManager.instance.Ring1Decrease();
                Player.instance.EquippedRing1 = null;
                UiManager.instance.IsRing1Equipped = false;
            }
        }
        if (Player.instance.EquippedRing2 != null)
        {

            Player.instance.EquippedRing2.CurrentDurability -= 1;
            if (Player.instance.EquippedRing2.CurrentDurability == 0)
            {
                UiManager.instance.Ring2.sprite = EmptyRingSprite;
                PlayerAttributesManager.instance.Ring2Decrease();
                Player.instance.EquippedRing2 = null;
                UiManager.instance.IsRing2Equipped = false;
            }
        }
    }


}
