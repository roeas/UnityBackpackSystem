using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBag", menuName = "Inventory/New Bag")]
public class InventoryBag : ScriptableObject
{
    public List<InventoryItem> itemList = new List<InventoryItem>();
}
