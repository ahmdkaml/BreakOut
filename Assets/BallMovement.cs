using UnityEngine;
using UnityEngine.InputSystem;

public class BallMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private Transform paddle;
    [SerializeField] private Vector2 paddleOffset = new Vector2(0f, 0.4f);
    private bool isLaunched = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLaunched)
        {
            transform.position = paddle.position + (Vector3)paddleOffset;
        }
        if (!isLaunched && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            // todo: Launch the ball with the paddle's current velocity in the x direction and 6 units in the y direction
            rb.linearVelocity = new Vector2(4f, 6f);
            isLaunched = true;
        }
    }
}
