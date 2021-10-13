using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Docent : MonoBehaviour
{

    public GameObject wp;
    public float walkSpeed;

    private Vector3 destPos;
    private bool isFreed;
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        destPos = wp.transform.position;
        isFreed = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        if (isFreed)
        {
            rb.MovePosition(Vector3.MoveTowards(transform.position, destPos, walkSpeed * Time.deltaTime));
        }
    }

    public void setTeacherFree(bool isFree)
    {
        isFreed = isFree;
    }
}
