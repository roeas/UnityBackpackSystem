using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public InventoryItem slotItem;
    public Image slotImage;
    public Text slotNum;

    private void OnEnable() {
        InventoryManager.UpdateItemInfo("");
    }
    public void OnItemClicked() {
        InventoryManager.UpdateItemInfo(slotItem.itemInfo);
    }
}
