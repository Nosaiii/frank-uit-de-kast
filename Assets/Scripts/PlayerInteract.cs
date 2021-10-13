using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    public bool interact = false;

    void OnInteract(InputValue val)
    {
        if (val.isPressed)
        {
            interact = true;
        }
        else if (!val.isPressed)
        {
            interact = false;
        }
    }
}
