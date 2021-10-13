using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    public bool interact = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnInteract(InputValue val)
    {
        if (val.isPressed)
        {
            interact = true;
            Debug.Log(interact);

        }
        else if (!val.isPressed)
        {
            interact = false;
            Debug.Log(interact);
        }
    }
}
