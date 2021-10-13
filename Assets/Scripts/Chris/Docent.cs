using UnityEngine;

public class Docent : MonoBehaviour
{

    public GameObject wayPoint;
    public float walkSpeed;

    private Vector3 destinationPosition;
    private bool isFreed;
    private Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        destinationPosition = wayPoint.transform.position;
        isFreed = true;
    }

    private void FixedUpdate()
    {
        if (isFreed)
        {
            rigidBody.MovePosition(Vector3.MoveTowards(transform.position, destinationPosition, walkSpeed * Time.fixedDeltaTime));
        }
    }

    public void setTeacherFree(bool isFree)
    {
        isFreed = isFree;
    }
}
