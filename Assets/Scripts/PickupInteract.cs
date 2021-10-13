using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InventoryItem))]
public class PickupInteract : MonoBehaviour
{
    private bool triggerActive = false;
    private PlayerInteract player;

    [SerializeField]
    private Inventory inventory;
    private InventoryItem inventoryItem;

    private void Awake() {
        inventoryItem = GetComponent<InventoryItem>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = true;
            player = other.gameObject.GetComponent<PlayerInteract>();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = false;
            player = null;
        }
    }

    private void Update()
    {
        // Only calls interact code if player is both in the trigger and is pressing the interact button
        Debug.Log($"{triggerActive} - {(player == null ? false : player.interact)}");
        if (triggerActive && player != null && player.interact)
        {
            Interaction();
        }
    }

    public void Interaction()
    {
        inventory.AddItem(inventoryItem);
        inventoryItem.transform.position = new Vector3(5000, 5000, 5000);
    }
}