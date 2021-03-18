using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemOnDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public InventoryBag inventoryBag;

    private Transform originalParent;
    private int firstIndex, secondIndex;
    public void OnBeginDrag(PointerEventData eventData) {
        firstIndex = GetIndex(transform.parent);
        originalParent = transform.parent;
        transform.SetParent(transform.parent.parent);
        transform.position = eventData.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData) {
        transform.position = eventData.position;
        //Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
    }
    public void OnEndDrag(PointerEventData eventData) {
        GameObject currentObject = eventData.pointerCurrentRaycast.gameObject;
        if (currentObject == null) {
            transform.SetParent(originalParent);
            transform.position = originalParent.transform.position;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            return;
        }
        if (currentObject.name == "Image" || currentObject.name == "Count") {
            secondIndex = GetIndex(currentObject.transform.parent.parent);
            transform.SetParent(currentObject.transform.parent.parent);
            transform.position = currentObject.transform.parent.parent.position;
            currentObject.transform.parent.SetParent(originalParent);
            currentObject.transform.parent.position = originalParent.position;
        }
        else if(currentObject.name == "Slot(Clone)") {
            secondIndex = GetIndex(currentObject.transform);
            transform.SetParent(currentObject.transform);
            transform.position = currentObject.transform.position;
        }
        else {
            transform.SetParent(originalParent);
            transform.position = originalParent.transform.position;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            return;
        }
        Debug.Log("firstIndex: " + firstIndex + " " + "secondIndex: " + secondIndex);
        //Swap(inventoryBag.itemList[firstIndex], inventoryBag.itemList[secondIndex]);
        InventoryItem tmp = inventoryBag.itemList[firstIndex];
        inventoryBag.itemList[firstIndex] = inventoryBag.itemList[secondIndex];
        inventoryBag.itemList[secondIndex] = tmp;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    private int GetIndex(Transform currentSlot) {
        Transform grid = currentSlot.parent;
        for(int i=0;i< grid.childCount; i++) {
            if (grid.GetChild(i) == currentSlot) {
                return i;
            }
        }
        return -1;
    }
    //private void Swap<T>(T x, T y) {
    //    T tmp = x;
    //    x = y;
    //    y = tmp;
    //}
}
