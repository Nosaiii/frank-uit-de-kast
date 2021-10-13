using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Object references")]
    [SerializeField]
    private Camera[] cameras;

    [Header("Movement settings")]
    [SerializeField]
    private float movementSpeed = 10.0f;

    [Header("Rotation settings")]
    [SerializeField]
    private float rotationSpeed = 30.0f;
    [SerializeField]
    private float maxRotationAngle = 55.0f;

    private Rigidbody m_rigidbody;

    private Vector2 rotationInputVelocity;
    private Vector2 movementInputVelocity;

    private void Awake() {
        m_rigidbody = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update() {
        transform.Rotate(new Vector3(0f, rotationInputVelocity.x, 0f) * rotationSpeed * Time.deltaTime);
        foreach (Camera _camera in cameras) {
            _camera.transform.Rotate(new Vector3(rotationInputVelocity.y, 0f, 0f) * -rotationSpeed * Time.deltaTime, Space.Self);

            Vector3 currentRotation = _camera.transform.rotation.eulerAngles;
            currentRotation.x = currentRotation.x.ClampAngle(-maxRotationAngle, maxRotationAngle);
            _camera.transform.rotation = Quaternion.Euler(currentRotation);
        }
    }

    private void FixedUpdate() {
        Vector3 directionVelocity = new Vector3(movementInputVelocity.x, 0f, movementInputVelocity.y);
        directionVelocity = transform.TransformDirection(directionVelocity);
        m_rigidbody.MovePosition(transform.position + directionVelocity * movementSpeed * Time.fixedDeltaTime);
    }

    public void OnRotate(InputAction.CallbackContext context) {
        rotationInputVelocity = context.ReadValue<Vector2>();
    }

    public void OnMove(InputAction.CallbackContext context) {
        movementInputVelocity = context.ReadValue<Vector2>();
    }
}
