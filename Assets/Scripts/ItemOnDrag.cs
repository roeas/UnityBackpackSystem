using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemOnDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public InventoryBag bag;

    private Transform originalParent;
    private int firstIndex, secondIndex;
    public void OnBeginDrag(PointerEventData eventData) {
        firstIndex = GetIndex(transform.parent);
        originalParent = transform.parent;
        //将Item移至Canvas子集以不至于被其他UI遮挡
        transform.SetParent(transform.parent.parent.parent.parent);
        transform.position = eventData.position;
        //令所拖拽的Item本身不会遮挡鼠标射线
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData) {
        transform.position = eventData.position;
        //Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
    }
    public void OnEndDrag(PointerEventData eventData) {
        GameObject crtObject = eventData.pointerCurrentRaycast.gameObject;
        if (crtObject == null) {
            //拖至UI界面之外，Item复位
            transform.SetParent(originalParent);
            transform.position = originalParent.transform.position;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            return;
        }
        if (crtObject.name == "Image" || crtObject.name == "Count") {
            //拖至另一Item上，交换两者
            Transform crtItem = crtObject.transform.parent;
            Transform crtSlot = crtItem.parent;
            secondIndex = GetIndex(crtSlot);

            transform.SetParent(crtSlot);
            transform.position = crtSlot.position;

            crtItem.SetParent(originalParent);
            crtItem.position = originalParent.position;
        }
        else if(crtObject.name == "Slot(Clone)") {
            //拖至空Slot
            secondIndex = GetIndex(crtObject.transform);
            transform.SetParent(crtObject.transform);
            transform.position = crtObject.transform.position;
        }
        else {
            //拖至其他UI上，Item复位
            transform.SetParent(originalParent);
            transform.position = originalParent.transform.position;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            return;
        }
        Debug.Log("firstIndex: " + firstIndex + " " + "secondIndex: " + secondIndex);
        
        //更新itemList
        InventoryItem tmp = bag.itemList[firstIndex];
        bag.itemList[firstIndex] = bag.itemList[secondIndex];
        bag.itemList[secondIndex] = tmp;

        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    private int GetIndex(Transform currentSlot) {
        //返回slot在grid中的顺序
        Transform grid = currentSlot.parent;
        for(int i=0;i< grid.childCount; i++) {
            if (grid.GetChild(i) == currentSlot) {
                return i;
            }
        }
        return 1;
    }
}
