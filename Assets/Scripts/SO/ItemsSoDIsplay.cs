using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Item/DisplayInfo")]
public class ItemsSoDIsplay : ScriptableObject
{
    [Header("Basic Item Settings")]
    public string ItemName;
    public string ItemDescription;
    public int ItemMoneyValue;
    [Header("Attribute Gain Settings")]
    public string GainText;
}
