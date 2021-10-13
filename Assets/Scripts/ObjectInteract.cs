using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteract : MonoBehaviour
{
    private bool triggerActive = false;
    private PlayerInteract player;

    [SerializeField]
    private Docent docent;

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
        if (triggerActive && player.interact)
        {
            Interaction();
        }
    }

    public void Interaction()
    {
        docent.setTeacherFree(true);
    }
}