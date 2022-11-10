using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class InventoryIcon : MonoBehaviour,IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public EquipItemSO EquipItem;
    public ConsumableItemSO ConsumableItem;
    public Button Button;
    public Text StackText;
    public int Stack;

    public Image ImageSprite;
    public UnityEvent MiddleClick;
    public UnityEvent RightClick;

    public void OnLeftClick() //"In Air"
    {
        if (Input.GetKey(KeyCode.P))
        {
           if(EquipItem != null && ConsumableItem == null)
            {
                GameManager.instance.NumberOfItemsInInvetory -= 1;
                Instantiate(EquipItem.ItemPrefab, new Vector2(Player.instance.transform.position.x + UiManager.instance.ItemDropOffset, Player.instance.transform.position.y), Quaternion.identity);
                ImageSprite.sprite = InventoryControl.instance.EmptySprite;
                EquipItem = null;
           }
           else if(ConsumableItem != null && EquipItem == null)
            {
                GameManager.instance.NumberOfItemsInInvetory -= 1;
                StackText.color = Color.green;
                for (int i = 0; i < Stack; i++)
                {
                    Instantiate(ConsumableItem.ItemPrefab, new Vector2(Player.instance.transform.position.x + UiManager.instance.ItemDropOffset - i, Player.instance.transform.position.y), Quaternion.identity);
                }
                Stack = 0;
                ImageSprite.sprite = InventoryControl.instance.EmptySprite;
                StackText.gameObject.SetActive(false);
                ConsumableItem = null;
            }
        } 
        else
        {
            if(UiManager.instance.IsItemInTheAir)
            {
                if(ConsumableItem == null && EquipItem == null)
                {
                    if(UiManager.instance.ConsumableItem != null)
                    {
                        ConsumableItem = UiManager.instance.ConsumableItem;
                        ImageSprite.sprite = UiManager.instance.ConsumableItem.ImageSprite;
                        Stack = UiManager.instance.InventoryIcon.Stack;
                        StackText.text = Stack.ToString();
                        StackText.gameObject.SetActive(true);
                        UiManager.instance.StackTekstFolowingMouse.gameObject.SetActive(false);
                        if(UiManager.instance.InventoryIcon.Stack == GameManager.instance.StackLimit && !UiManager.instance.ConsumableItem.LimitlessItem)
                        {
                            StackText.color = Color.red;
                        }
                        else
                        {
                            StackText.color = Color.green;
                        }
                        if(UiManager.instance.InventoryIcon != this)
                        {
                            UiManager.instance.InventoryIcon.Stack = 0;
                        }
                        UiManager.instance.ConsumableItem = null;
                        UiManager.instance.InventoryIcon = null;
                        UiManager.instance.IsItemInTheAir = false;
                        UiManager.instance.ImageFolowingMouse.gameObject.SetActive(false);
                    }
                    else
                    {
                        if(UiManager.instance.EquipItem != null)
                        {
                            EquipItem = UiManager.instance.EquipItem;
                            ImageSprite.sprite = UiManager.instance.EquipItem.ImageSprite;
                            UiManager.instance.EquipItem = null;
                            UiManager.instance.InventoryIcon = null;
                            UiManager.instance.IsItemInTheAir = false;
                            UiManager.instance.ImageFolowingMouse.gameObject.SetActive(false);
                        }
                    } 
                }
                else
                {
                    if(UiManager.instance.ConsumableItem != null)
                    {
                        if(ConsumableItem != null)
                        {
                            if (!ConsumableItem.LimitlessItem)
                            {
                                if (UiManager.instance.ConsumableItem.GainType == ConsumableItem.GainType)
                                {
                                    if (Stack < GameManager.instance.StackLimit)
                                    {
                                        int AddToStack = GameManager.instance.StackLimit - Stack;
                                        if (UiManager.instance.InventoryIcon.Stack == AddToStack)
                                        {
                                            Stack = GameManager.instance.StackLimit;
                                            StackText.text = Stack.ToString();
                                            StackText.color = Color.red;
                                            UiManager.instance.StackTekstFolowingMouse.gameObject.SetActive(false);
                                            UiManager.instance.ImageFolowingMouse.gameObject.SetActive(false);
                                            UiManager.instance.IsItemInTheAir = false;
                                            UiManager.instance.InventoryIcon.Stack = 0;
                                            UiManager.instance.ConsumableItem = null;
                                            UiManager.instance.InventoryIcon = null;
                                        }
                                        else if (UiManager.instance.InventoryIcon.Stack < AddToStack)
                                        {
                                            Stack += UiManager.instance.InventoryIcon.Stack;
                                            StackText.text = Stack.ToString();
                                            UiManager.instance.StackTekstFolowingMouse.gameObject.SetActive(false);
                                            UiManager.instance.ImageFolowingMouse.gameObject.SetActive(false);
                                            UiManager.instance.InventoryIcon.Stack = 0;
                                            UiManager.instance.IsItemInTheAir = false;
                                            UiManager.instance.ConsumableItem = null;
                                            UiManager.instance.InventoryIcon = null;
                                        }
                                        else
                                        {
                                            Stack = GameManager.instance.StackLimit;
                                            StackText.text = Stack.ToString();
                                            StackText.color = Color.red;
                                            if (UiManager.instance.InventoryIcon.Stack == GameManager.instance.StackLimit)
                                            {
                                                UiManager.instance.StackTekstFolowingMouse.color = Color.green;
                                            }
                                            UiManager.instance.InventoryIcon.Stack -= AddToStack;
                                            UiManager.instance.StackTekstFolowingMouse.text = UiManager.instance.InventoryIcon.Stack.ToString();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (UiManager.instance.ConsumableItem.GainType == ConsumableItem.GainType)
                                {
                                    Stack += UiManager.instance.InventoryIcon.Stack;
                                    StackText.text = Stack.ToString();
                                    UiManager.instance.StackTekstFolowingMouse.gameObject.SetActive(false);
                                    UiManager.instance.ImageFolowingMouse.gameObject.SetActive(false);
                                    UiManager.instance.InventoryIcon.Stack = 0;
                                    UiManager.instance.IsItemInTheAir = false;
                                    UiManager.instance.ConsumableItem = null;
                                    UiManager.instance.InventoryIcon = null;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (ConsumableItem != null && EquipItem == null) //if the item have Scriptable object info on him and the stack item is bigger then 0
                {
                    UiManager.instance.StackTekstFolowingMouse.text = Stack.ToString();
                    UiManager.instance.StackTekstFolowingMouse.gameObject.SetActive(true);
                    if (Stack == GameManager.instance.StackLimit && !ConsumableItem.LimitlessItem)
                    {
                        UiManager.instance.StackTekstFolowingMouse.color = Color.red;
                    }
                    else
                    {
                        UiManager.instance.StackTekstFolowingMouse.color = Color.green;
                    }
                    ImageSprite.sprite = InventoryControl.instance.EmptySprite;
                    StackText.gameObject.SetActive(false);
                    UiManager.instance.ConsumableItem = ConsumableItem; //give the Sriptable object info to UiManager
                    UiManager.instance.ImageFolowingMouse.gameObject.SetActive(true);
                    UiManager.instance.ImageFolowingMouse.sprite = ConsumableItem.ImageSprite; //give the sprite from ScriptableObject to the UiManager
                    UiManager.instance.IsItemInTheAir = true;
                    UiManager.instance.InventoryIcon = this; //sets the value of the Inventory variable to this specific script of the specific gameobject that is clicked
                    ConsumableItem = null;
                    
                }
                if (EquipItem != null && ConsumableItem == null)
                {
                    UiManager.instance.EquipItem = EquipItem; //give the Sriptable object info to UiManager
                    ImageSprite.sprite = InventoryControl.instance.EmptySprite;
                    UiManager.instance.ImageFolowingMouse.gameObject.SetActive(true);
                    UiManager.instance.ImageFolowingMouse.sprite = EquipItem.ImageSprite; //give the sprite from ScriptableObject to the UiManager
                    UiManager.instance.IsItemInTheAir = true;
                    UiManager.instance.InventoryIcon = this; //sets the value of the Inventory variable to this specific script of the specific gameobject that is clicked
                    EquipItem = null;
                } 
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData) //////////////////  Middle Mouse Button For Consuming Consumable ///////////////////
    {
        if (eventData.button == PointerEventData.InputButton.Middle)
        {
            MiddleClick.Invoke();
            if(ConsumableItem != null && EquipItem == null)
            {
                if (ConsumableItem.HoldBonusValueOverTime)
                {
                    if (Stack == GameManager.instance.StackLimit)
                    {
                        StackText.color = Color.green;
                    }
                    Stack -= 1;
                    StackText.text = Stack.ToString();
                    UiManager.instance.ConsumableItem = ConsumableItem;
                    UiManager.instance.InventoryIcon = this;
                    PlayerAttributesManager.instance.StartHoldBonusValueOverTime();
                }
                else if (ConsumableItem.RampValueOverTime)
                {
                    if (!PlayerAttributesManager.instance.IsRampConsumableActive)
                    {
                        if (Stack == GameManager.instance.StackLimit)
                        {
                            StackText.color = Color.green;
                        }
                        Stack -= 1;
                        StackText.text = Stack.ToString();
                        UiManager.instance.ConsumableItem = ConsumableItem;
                        UiManager.instance.InventoryIcon = this;
                        PlayerAttributesManager.instance.StartRampValueOverTime();
                    }
                }
                else if (ConsumableItem.ChangeValueOverTime)
                {
                    if (!PlayerAttributesManager.instance.IsChangeValueOverTimeActive)
                    {
                        if (Stack == GameManager.instance.StackLimit)
                        {
                            StackText.color = Color.green;
                        }
                        Stack -= 1;
                        StackText.text = Stack.ToString();
                        UiManager.instance.ConsumableItem = ConsumableItem;
                        UiManager.instance.InventoryIcon = this;
                        PlayerAttributesManager.instance.StartChangeValueOverTime();
                    }
                }
            }
        }
        else if(eventData.button == PointerEventData.InputButton.Right)
        {
            RightClick.Invoke();
            if(ConsumableItem != null && EquipItem == null)
            {
                UiManager.instance.ConsumableItem = ConsumableItem;
                UiManager.instance.InventoryIcon = this;
                SplitStack.instance.Slider.maxValue = Stack-1;
                SplitStack.instance.gameObject.SetActive(true);
            }
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (EquipItem != null)
        {
            UiManager.instance.MoText.text = "Name:" + EquipItem.ItemsInfoDisplay.ItemName + "\nDescription:"
            + EquipItem.ItemsInfoDisplay.ItemDescription + "\nCost:" + EquipItem.ItemsInfoDisplay.ItemMoneyValue.ToString() + "\nGain:" + EquipItem.ItemsInfoDisplay.GainText;
            UiManager.instance.MoData.gameObject.SetActive(true);
        }
        else if (ConsumableItem != null)
        {
            UiManager.instance.MoText.text = "Name:" + ConsumableItem.ItemsInfoDisplay.ItemName + "\nDescription:"
            + ConsumableItem.ItemsInfoDisplay.ItemDescription + "\nCost:" + ConsumableItem.ItemsInfoDisplay.ItemMoneyValue.ToString() + "\nGain:" + ConsumableItem.ItemsInfoDisplay.GainText;
            UiManager.instance.MoData.gameObject.SetActive(true);
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        UiManager.instance.MoData.gameObject.SetActive(false);
    }

}


