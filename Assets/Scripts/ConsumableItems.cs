using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ConsumableItems : MonoBehaviour
{
    public ConsumableItemSO ConsumableItem;
    private int _iteration;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(Strings.Player))
        {
            AddtoInventory();
        }
    }
    
    public void AddtoInventory()
    {
        switch (ConsumableItem.itemType)
        {
            case ConsumableItemSO.ItemType.Consumable:
                if (GameManager.instance.NumberOfItemsInInvetory == InventoryControl.instance.NumOfCells)
                {
                    Debug.LogError("cell count is equal inventory count, cant add any more items to inventory");
                    StartCoroutine(InventoryFullMessage());
                }
                else
                {
                    if (!ConsumableItem.LimitlessItem)
                    {
                        NumOfConsumablesInInvetory();
                        bool IsFirstLoopDone = false;
                        if (!ConsumableItem.IsItemInInvetory)
                        {
                            AddToFirstFreeSlot();
                        }
                        else
                        {
                            _iteration = 0;
                            foreach(InventoryIcon icon in InventoryControl.instance.InventoryItems)
                            {
                                if (_iteration == InventoryControl.instance.InventoryItems.Count-1)
                                {
                                    IsFirstLoopDone = true;
                                }
                                _iteration++;
                                if (icon.ConsumableItem != null)
                                {
                                    if (icon.Stack < GameManager.instance.StackLimit && icon.ConsumableItem.GainType == ConsumableItem.GainType)
                                    {
                                        icon.Stack += 1;
                                        icon.StackText.text = icon.Stack.ToString();
                                        if (icon.Stack == GameManager.instance.StackLimit)
                                        {
                                            icon.StackText.color = Color.red;
                                        }
                                        Destroy(this.gameObject);
                                        break;
                                    }  
                                }
                            }
                        }
                        if (IsFirstLoopDone)
                        {
                            AddToFirstFreeSlot();
                        }
                    }
                    else
                    {
                        NumOfConsumablesInInvetory();
                        bool IsFirstLoopDone = false;
                        if (!ConsumableItem.IsItemInInvetory)
                        {
                            AddToFirstFreeSlot();
                        }
                        else
                        {
                            _iteration = 0;
                            foreach (InventoryIcon icon in InventoryControl.instance.InventoryItems)
                            {
                                if (_iteration == InventoryControl.instance.InventoryItems.Count - 1)
                                {
                                    IsFirstLoopDone = true;
                                }
                                _iteration++;
                                if (icon.ConsumableItem != null)
                                {
                                    if (icon.ConsumableItem.LimitlessItem && icon.ConsumableItem.GainType == ConsumableItem.GainType)
                                    {
                                        icon.Stack += 1;
                                        icon.StackText.text = icon.Stack.ToString();
                                        Destroy(this.gameObject);
                                        break;
                                    }
                                }
                            }
                        }
                        if (IsFirstLoopDone)
                        {
                            AddToFirstFreeSlot();
                        }
                    }
                }
                break;
            case ConsumableItemSO.ItemType.PowerUp:
                switch (ConsumableItem.PowerUpTypes)
                {
                    case ConsumableItemSO.PowerUpType.none:
                        break;
                    case ConsumableItemSO.PowerUpType.MinorSpeedBoost:
                        MinorSpeedBoost();
                        Destroy(this.gameObject);
                        break;
                    default:
                        break;
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
        Debug.Log("Player picked up a Speed PowerUp, the duration is:" + Player.instance.PowerUpDuration + "Seconds");

    }

    public void AddToFirstFreeSlot()
    {
        foreach (InventoryIcon icon in InventoryControl.instance.InventoryItems)
        {
            if (icon.ConsumableItem == null && icon.EquipItem == null)
            {
                icon.StackText.color = Color.green;
                GameManager.instance.NumberOfItemsInInvetory += 1;
                icon.ImageSprite.sprite = ConsumableItem.ImageSprite;
                icon.ConsumableItem = ConsumableItem;
                icon.StackText.gameObject.SetActive(true);
                icon.Stack += 1;
                icon.StackText.text = icon.Stack.ToString();
                ConsumableItem.IsItemInInvetory = true;
                Destroy(this.gameObject);
                break;
            }
        }
    }
    public void NumOfConsumablesInInvetory()
    {
        switch (ConsumableItem.GainType)
        {
            case ConsumableItemSO.Gains.none:
                break;
            case ConsumableItemSO.Gains.Strength:
                InventoryControl.instance.NumOfStrenghtConsumInInvetory += 1;
                break;
            case ConsumableItemSO.Gains.Dexterity:
                break;
            case ConsumableItemSO.Gains.Agility:
                break;
            case ConsumableItemSO.Gains.Intelligence:
                InventoryControl.instance.NumOfIntelligenceConsumInInvetory += 1;
                break;
            case ConsumableItemSO.Gains.Health:
                InventoryControl.instance.NumOfPoisonConsumInInvetory += 1;
                break;
            case ConsumableItemSO.Gains.Mana:
                break;
            case ConsumableItemSO.Gains.Luck:
                break;
            default:
                break;
        }
    }
}
