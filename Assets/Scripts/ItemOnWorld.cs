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
        if (inventoryBag.itemList.Contains(inventoryItem)) {
            inventoryItem.itemCount++;
        }
        else {//背包内不存在此物品
            for (int i = 0; i < inventoryBag.itemList.Count; i++) {
                //顺序找到背包内第一个空余位置
                if (inventoryBag.itemList[i] == null) {
                    inventoryBag.itemList[i] = inventoryItem;
                    break;
                }
                //背包满啦！
            }
        }
        InventoryManager.UpdateGUI();
    }
}
