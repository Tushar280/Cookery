using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 10f;

    private Rigidbody rb;
    private Vector2 moveInput;
    private PlayerInput playerInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        Vector3 moveDir = new Vector3(moveInput.x, 0f, moveInput.y);

        if (moveDir != Vector3.zero)
        {
            transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void OnMovement(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void MovePlayer()
    {
        Vector3 moveDir = new Vector3(moveInput.x, 0f, moveInput.y);
        rb.linearVelocity = new Vector3(moveDir.x * moveSpeed, rb.linearVelocity.y, moveDir.z * moveSpeed);
    }
}
