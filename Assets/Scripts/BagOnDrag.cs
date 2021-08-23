using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BagOnDrag : MonoBehaviour, IDragHandler
{
    private RectTransform rectTransform;
    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
    }
    public void OnDrag(PointerEventData eventData) {
        rectTransform.anchoredPosition += eventData.delta;
    }
}
