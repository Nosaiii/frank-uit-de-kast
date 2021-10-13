using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    public bool interact = false;

    void OnInteract(InputValue val)
    {
        interact = val.isPressed;
    }
}
