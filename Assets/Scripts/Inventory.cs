using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Linq;

public class Inventory : MonoBehaviour {
    [Header("Inventory settings")]
    [SerializeField]
    private InventoryItem[] initialItems;

    [Header("UI settings")]
    [SerializeField]
    private InventorySlot[] inventorySlots;

    private int currentItemIndex;

    private void Awake() {
        foreach (InventoryItem item in initialItems) {
            AddItem(item);
        }
    }

    private void Start() {
        inventorySlots[currentItemIndex].Item?.OnSelect();
    }

    public void OnChangeSelection(InputAction.CallbackContext context) {
        int numeric = (int)context.ReadValue<float>();

        int oldSelectedIndex = currentItemIndex;
        currentItemIndex = Mathf.Clamp(numeric, 0, inventorySlots.Length - 1);
        if (oldSelectedIndex == currentItemIndex) {
            return;
        }

        inventorySlots[oldSelectedIndex].Item?.OnDeselect();
        inventorySlots[currentItemIndex].Item?.OnSelect();

        UpdateUI();
    }

    public bool AddItem(InventoryItem item) {
        InventorySlot slot = inventorySlots.FirstOrDefault(inventorySlot => inventorySlot.Item == null);

        if (slot == null) {
            return false;
        }

        slot.SetItem(item);
        UpdateUI();

        return true;
    }

    private void UpdateUI() {
        foreach (InventorySlot slot in inventorySlots) {
            if (slot.Item != null) {
                slot.SlotIcon.texture = slot.Item.ItemIcon;
                slot.SlotIcon.enabled = true;
            } else {
                slot.SlotIcon.enabled = false;
            }

            bool selected = slot == inventorySlots[currentItemIndex];
            slot.SlotContainer.color = GetImageOpacity(selected, slot.SlotContainer.color);
        }
    }

    private Color GetImageOpacity(bool selected, Color color) {
        float alpha = 0.1f;
        if (selected) {
            alpha = 1.0f;
        }
        color.a = alpha;

        return color;
    }
}