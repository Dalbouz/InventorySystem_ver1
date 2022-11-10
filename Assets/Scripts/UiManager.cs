using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    public EquipItemSO EquipItem;
    public ConsumableItemSO ConsumableItem;
    public InventoryIcon InventoryIcon;

    public float ItemDropOffset;
    public GameObject InventoryScreen;
    public GameObject EquipScreen;
    public GameObject PlayerStats;
    public GameObject InventoryButton;
    public GameObject EquipButton;
    public GameObject PlayerStatsButton;
    public Image Head;
    public Image Torso;
    public Image Weapon;
    public Image Shield;
    public Image Boots;
    public Image Ring1;
    public Image Ring2;
    public GameObject InventoryFullMessage;
    public Image ImageFolowingMouse;
    public Text MoText;
    public GameObject MoData;
    public Text StackTekstFolowingMouse;
    public Text Strength;
    public Text Dexterity;
    public Text Agility;
    public Text Intelligence;
    public Text Luck;
    public Slider HealthBar;
    public Slider ManaBar;
    public GameObject SplitScreen;
    public GameObject DurabilityInfoScreen;
    public Text DurabilityText;
    private Vector3 _mousePosition;

    public bool IsWeaponEquipped = false;
    public bool IsShieldEquipped = false;
    public bool IsHeadEquipped = false;
    public bool IsTorsoEquipped = false;
    public bool IsBootsEquipped = false;
    public bool IsRing1Equipped = false;
    public bool IsRing2Equipped = false;
    public bool IsItemInTheAir = false;
    public bool IsStrenghtConsumablePickedUp = false;
    
    private bool _isInventoryScreenOpen = false;
    private bool _isEquipScreenOpen = false;
    private bool _isPlayerStatsOpen = false;

    private void Awake()
    {
        if (this.gameObject.activeInHierarchy) instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        DurabilityInfoScreen.SetActive(false);
        SplitScreen.SetActive(false);
        InventoryScreen.SetActive(false);
        EquipScreen.SetActive(false);
        InventoryFullMessage.SetActive(false);
        PlayerStats.SetActive(false);
    }

    private void Update()
    {
        if(DurabilityInfoScreen.activeSelf == true)
        {
            _mousePosition = Input.mousePosition;

            DurabilityInfoScreen.transform.position = new Vector2(_mousePosition.x - 1, _mousePosition.y);
        }
        ImageFolowingMouse.transform.position = Input.mousePosition;
    }

    public void OpenEquipScreen()
    {
        if (!_isEquipScreenOpen)
        {
            EquipButton.SetActive(false);
            EquipScreen.SetActive(true);
            _isEquipScreenOpen = true;
        }
        else
        {
            EquipButton.SetActive(true);
            EquipScreen.SetActive(false);
            _isEquipScreenOpen = false;
        }

    }
    public void OpenInventoryScreen()
    {
        if (!_isInventoryScreenOpen)
        {
            InventoryButton.SetActive(false);
            InventoryScreen.SetActive(true);
            _isInventoryScreenOpen = true;
        }
        else
        {
            InventoryButton.SetActive(true);
            InventoryScreen.SetActive(false);
            _isInventoryScreenOpen = false;
        }
    }
    public void CloseInventoryScreen()
    {
        InventoryScreen.SetActive(false);
        InventoryButton.SetActive(true);
        _isInventoryScreenOpen = false;
    }
    public void CloseEquipScreen()
    {
        EquipScreen.SetActive(false);
        EquipButton.SetActive(true);
        _isEquipScreenOpen = false;
    }
    public void OpenPlayerStats()
    {
        if (!_isPlayerStatsOpen)
        {
            PlayerStatsButton.SetActive(false);
            PlayerStats.SetActive(true);
            _isPlayerStatsOpen = true;
        }
        else
        {
            PlayerStatsButton.SetActive(true);
            PlayerStats.SetActive(false);
            _isPlayerStatsOpen = false;
        }
    }
    public void ClosePlayerStats()
    {
        PlayerStats.SetActive(false);
        PlayerStatsButton.SetActive(true);
        _isPlayerStatsOpen = false;
    }
    public void CheckIfDropedItemOrClosedPanel()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && (InventoryScreen.gameObject.activeSelf == true || EquipScreen.gameObject.activeSelf == true))
        {
            if (ConsumableItem != null)
            {
                StackTekstFolowingMouse.color = Color.green;
                GameManager.instance.NumberOfItemsInInvetory -= 1;
                for (int i = 0; i < InventoryIcon.Stack; i++)
                {
                    Instantiate(ConsumableItem.ItemPrefab, new Vector2(Player.instance.transform.position.x + ItemDropOffset - i, Player.instance.transform.position.y), Quaternion.identity);
                }
                InventoryIcon.Stack = 0;
            }
            else if(EquipItem != null)
            {
                GameManager.instance.NumberOfItemsInInvetory -= 1;
                Instantiate(EquipItem.ItemPrefab, new Vector2(Player.instance.transform.position.x + ItemDropOffset, Player.instance.transform.position.y), Quaternion.identity);
            }   
            IsItemInTheAir = false;
            if (InventoryIcon != null)
            {
                InventoryIcon.ImageSprite.sprite = InventoryControl.instance.EmptySprite;
                InventoryIcon.StackText.gameObject.SetActive(false);
                if (ConsumableItem != null)
                {
                    InventoryIcon.ConsumableItem = null;
                }
                else if (EquipItem != null)
                {
                    InventoryIcon.EquipItem = null;
                }
            }
                ImageFolowingMouse.gameObject.SetActive(false);
                StackTekstFolowingMouse.gameObject.SetActive(false);
                EquipItem = null;
                ConsumableItem = null;
        }
        if (InventoryScreen.gameObject.activeSelf == false && EquipScreen.gameObject.activeSelf == false)
        {
            if(ConsumableItem!=null)
            {
                InventoryIcon.StackText.gameObject.SetActive(true);
                InventoryIcon.ImageSprite.sprite = ConsumableItem.ImageSprite;
                InventoryIcon.ConsumableItem = ConsumableItem;
                ConsumableItem = null;
            }
            else if (EquipItem != null)
            {
                InventoryIcon.StackText.gameObject.SetActive(true);
                InventoryIcon.ImageSprite.sprite = EquipItem.ImageSprite;
                InventoryIcon.EquipItem = EquipItem;
                EquipItem = null;
            }
            IsItemInTheAir = false;
            ImageFolowingMouse.gameObject.SetActive(false);
            StackTekstFolowingMouse.gameObject.SetActive(false);
        }
    }

}
