using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnWorld : MonoBehaviour
{
    public InventoryItem inventoryItem;
    public InventoryBag inventoryBag;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            AddItemToBag();
            Destroy(gameObject);
        }
    }
    void AddItemToBag() {
        if (inventoryBag.itemList.Contains(inventoryItem)) {//背包内已存在此物品
            inventoryItem.itemCount++;//更新物品数据
        }
        else {//背包内不存在此物品
            for (int i = 0; i < inventoryBag.itemList.Count; i++) {
                if (inventoryBag.itemList[i] == null) {//顺序找到背包内第一个空余位置
                    inventoryBag.itemList[i] = inventoryItem;//更新背包数据
                    break;
                }
                //背包满啦！
            }
        }
        InventoryManager.UpdateGUI();
    }
}
