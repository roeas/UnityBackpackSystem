using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance;

    public InventoryBag playerBag;
    public GameObject slotGrid;
    public GameObject emptySlot;
    public Text itemInformation;
    public List<GameObject> slotList = new List<GameObject>();

    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);
        }
        instance = this;
        UpdateGUI();
    }
    public static void UpdateItemInfo(string info) {
        instance.itemInformation.text = info;
    }
    public static void UpdateGUI() {
        instance.slotList.Clear();
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++) {
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
        }//先清空slotGrid的子物体与slotList[]
        for(int i = 0; i < instance.playerBag.itemList.Count; i++) {
            instance.slotList.Add(Instantiate(instance.emptySlot, instance.slotGrid.transform, false));//将18个emptySlot生成为slotGrid的子物体，然后加入slotList[]
            instance.slotList[i].GetComponent<Slot>().InitSlot(instance.playerBag.itemList[i]);//将每个emptySlot初始化，playerBag.itemList[i]非空则进行赋值，否则设inactive
        }
    }
}
