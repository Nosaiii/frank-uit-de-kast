using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {
    [SerializeField]
    private Image slotContainer;
    public Image SlotContainer => slotContainer;
    [SerializeField]
    private RawImage slotIcon;
    public RawImage SlotIcon => slotIcon;

    private InventoryItem item;
    public InventoryItem Item => item;

    public void SetItem(InventoryItem item) {
        this.item = item;
    }

    public void Select() {

    }
}