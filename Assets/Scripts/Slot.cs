using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public GameObject slotItem;
    public Image slotImage;
    public Text slotCount;
    public string slotInfo;

    private void OnEnable() {
        InventoryManager.UpdateItemInfo("");
    }
    public void OnItemClicked() {//在button中调用
        InventoryManager.UpdateItemInfo(slotInfo);
    }
    public void InitSlot(InventoryItem inventoryItem) {
        if (inventoryItem == null) {
            slotItem.SetActive(false);
            return;
        }
        else {
            slotImage.sprite = inventoryItem.itemSprite;
            slotCount.text = inventoryItem.itemCount.ToString();
            slotInfo = inventoryItem.itemInfo;
        }
    }
}
