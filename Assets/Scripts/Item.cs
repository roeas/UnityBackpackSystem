using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public InventoryItem inventoryItem;
    public InventoryBag inventoryBag;
    private GameObject tmpGameObject;
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
        else {
            inventoryBag.itemList.Add(inventoryItem);
            InventoryManager.CreatItem(inventoryItem);
        }
        InventoryManager.RefreshItem();
    }
}
