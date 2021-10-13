using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryItem : MonoBehaviour {
    [SerializeField]
    private Texture2D itemIcon;
    public Texture2D ItemIcon => itemIcon;
    [SerializeField]
    private string itemName;

    public abstract void OnSelect();
    public abstract void OnDeselect();
}