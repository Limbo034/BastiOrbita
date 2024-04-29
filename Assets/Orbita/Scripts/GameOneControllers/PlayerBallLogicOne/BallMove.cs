using Scripts.UI.JoystickLogic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    [Header("Control References")]
    [SerializeField] private Joystick joystick;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float radius = 2f;

    private float rotZ;
    private Vector2 moveInput; 
    private Vector2 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }
    private void Update()
    {
        moveInput.x = joystick.Horizontal;
        moveInput.y = joystick.Vertical;

        Vector2 direction = new Vector2(moveInput.x, moveInput.y).normalized;
        Vector2 targetPosition = initialPosition + direction * radius;

        if (direction.magnitude > 0)
        {
            transform.Rotate(Vector3.forward, Time.deltaTime * moveSpeed);
            transform.position = Vector2.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);
        }

        if (Mathf.Abs(direction.x) > 0.3f || Mathf.Abs(direction.y) > 0.3f)
        {
            rotZ = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg;
        }

        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
    }
}
