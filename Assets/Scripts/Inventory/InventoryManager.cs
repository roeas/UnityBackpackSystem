using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance;

    public InventoryBag playerBag;
    public GameObject slotGrid;
    public Slot slotPrefab;
    public Text itemInformation;

    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);
        }
        instance = this;
        RefreshItem();
    }
    public static void UpdateItemInfo(string info) {
        instance.itemInformation.text = info;
    }
    public static void CreatItem(InventoryItem itemIn) {
        Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform, false);//将slotPrefab生成为slotGrid的子物体
        newItem.slotItem = itemIn;
        newItem.slotImage.sprite = itemIn.itemSprite;
        newItem.slotNum.text = itemIn.itemCount.ToString();
    }
    public static void RefreshItem() {
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++) {
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
        }
        for(int i = 0; i < instance.playerBag.itemList.Count; i++) {
            CreatItem(instance.playerBag.itemList[i]);
        }
    }
}
