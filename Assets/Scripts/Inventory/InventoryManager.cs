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
    }
    public static void CreatItem(InventoryItem itemIn) {
        Slot Newitem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
        Newitem.gameObject.transform.SetParent(instance.slotGrid.transform);
        Newitem.slotItem = itemIn;
        Newitem.slotImage.sprite = itemIn.itemSprite;
        Newitem.slotNum.text = itemIn.itemCount.ToString();
    }
}
