using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryControl : MonoBehaviour
{
    public static InventoryControl instance;

    public List<InventoryIcon> InventoryItems;
    public int NumOfRows;
    public int NumOfCells;
    public int NumOfStrenghtConsumInInvetory = 0;
    public int NumOfIntelligenceConsumInInvetory = 0;
    public int NumOfPoisonConsumInInvetory = 0;


    public GameObject EmptySlotPrefab;

    public Sprite EmptySprite;

    private void Awake()
    {
        if (this.gameObject.activeInHierarchy) instance = this;
    }


    public void FillGrid()
    {
        InventoryItems = new List<InventoryIcon>();
        GameObject NewGridObj;
        InventoryIcon InvetoryIconScript;
        for (int i = 0; i < NumOfCells; i++)
        {
            NewGridObj =Instantiate(EmptySlotPrefab, transform);
            InvetoryIconScript = NewGridObj.GetComponent<InventoryIcon>();
            InventoryItems.Add(InvetoryIconScript);
            InvetoryIconScript.ImageSprite = InvetoryIconScript.gameObject.GetComponent<Image>();
        }
    }
}
