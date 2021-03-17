using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem",menuName = "Inventory/New Item")]
public class InventoryItem : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;
    public int itemCount = 1;
    [TextArea]
    public string itemInfo;
    public bool equipable;
}
