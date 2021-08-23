using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance;

    public InventoryBag bag;
    public GameObject grid;
    public GameObject emptySlot;//预制体Slot
    public Text itemInfo;//显示在背包左下角的UI
    public List<GameObject> slotList = new List<GameObject>();

    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);
        }
        instance = this;
        UpdateGUI();
    }
    public static void UpdateItemInfo(string info) {
        instance.itemInfo.text = info;
    }
    public static void UpdateGUI() {
        //先清空Grid的子物体与slotList[]
        instance.slotList.Clear();
        for (int i = 0; i < instance.grid.transform.childCount; i++) {
            Destroy(instance.grid.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < instance.bag.itemList.Count; i++) {
            //将emptySlot生成为grid的子物体，然后加入slotList[]
            instance.slotList.Add(Instantiate(instance.emptySlot, instance.grid.transform, false));
            //用itemList[]刷新slotList[]
            instance.slotList[i].GetComponent<Slot>().InitSlot(instance.bag.itemList[i]);
        }
    }
}
