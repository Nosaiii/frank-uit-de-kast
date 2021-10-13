using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [HideInInspector]
    public bool interact = false;

    public void OnInteract(InputAction.CallbackContext context)
    {
        interact = context.performed;
    }
}
