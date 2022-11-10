using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SplitStack : MonoBehaviour
{
    public static SplitStack instance;

    public Button Add, Remove, Ok, Cancel;
    public Text SplitText;
    public int SplitAmount;
    public Slider Slider;
    public float SliderFormerValue;

    private void Start()
    {
        SplitAmount = 0;
        SplitText.text = SplitAmount.ToString();
        Slider.value = 0;
        SliderFormerValue = 0;
        Slider.wholeNumbers = true;
    }
    private void Update()
    {
        if(Slider.value != SliderFormerValue)
        {
            SplitAmount = (int)Slider.value;
            SplitText.text = SplitAmount.ToString();
            SliderFormerValue = Slider.value;
        }
    }

    private void Awake()
    {
        if (this.gameObject.activeInHierarchy) instance = this;
    }

    public void AddAmount()
    {
        SplitAmount += 1;
        Slider.value += 1;
        SliderFormerValue += 1;
        if(SplitAmount == UiManager.instance.InventoryIcon.Stack)
        {
            SplitAmount = UiManager.instance.InventoryIcon.Stack -1;
            Slider.value = UiManager.instance.InventoryIcon.Stack - 1;
            SliderFormerValue -= 1;
        }
        SplitText.text = SplitAmount.ToString();
    }

    public void RemoveAmount()
    {
        SplitAmount -= 1;
        Slider.value -= 1;
        SliderFormerValue -= 1;
        if (SplitAmount <= 0)
        {
            SplitAmount = 0;
            Slider.value = 0;
            SliderFormerValue = 0;
        }
        SplitText.text = SplitAmount.ToString();
    }

    public void ConfirmSplit()
    {
        if(SplitAmount > 0)
        {
            foreach (InventoryIcon icon in InventoryControl.instance.InventoryItems)
            {
                if(icon.ConsumableItem == null && icon.EquipItem == null)
                {
                    icon.ConsumableItem = UiManager.instance.ConsumableItem;
                    icon.Stack = SplitAmount;
                    icon.ImageSprite.sprite = UiManager.instance.ConsumableItem.ImageSprite;
                    icon.StackText.text = SplitAmount.ToString();
                    icon.StackText.color = Color.green;
                    icon.StackText.gameObject.SetActive(true);
                    if(UiManager.instance.InventoryIcon.Stack == GameManager.instance.StackLimit)
                    {
                        UiManager.instance.InventoryIcon.StackText.color = Color.green;
                    }
                    UiManager.instance.InventoryIcon.Stack -= SplitAmount;
                    UiManager.instance.InventoryIcon.StackText.text = UiManager.instance.InventoryIcon.Stack.ToString();
                    break;
                }
            }
            SplitAmount = 0;
            Slider.value = SplitAmount;
            SplitText.text = SplitAmount.ToString();
            UiManager.instance.InventoryIcon = null;
            UiManager.instance.ConsumableItem = null;
            gameObject.SetActive(false);
        }
    }
    public void CancelSplit()
    {
        SplitAmount = 0;
        Slider.value = SplitAmount;
        SplitText.text = SplitAmount.ToString();
        UiManager.instance.ConsumableItem = null;
        UiManager.instance.InventoryIcon = null;
        gameObject.SetActive(false);
    }

}
