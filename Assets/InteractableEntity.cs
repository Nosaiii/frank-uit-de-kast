using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableEntity : MonoBehaviour {
    [SerializeField]
    private float interactionDistance = 3.0f;

    [SerializeField]
    private UnityEvent<InteractableEntity> _event;

    public void Interact() {
        _event.Invoke(this);
    }

    public bool InDistance(GameObject player) {
        return Vector3.Distance(player.transform.position, transform.position) <= interactionDistance;
    }
}