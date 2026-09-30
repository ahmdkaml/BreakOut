using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Rigidbody2D rb;
    private float moveInput;
    [SerializeField] private InputActionReference moveAction;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        moveAction.action.Enable();
    }
    private void OnDisable()
    {
        moveAction.action.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveInput = moveAction.action.ReadValue<Vector2>().x;
    }
    private void FixedUpdate()
    {
        float movement = moveInput * speed * Time.fixedDeltaTime;
        Vector2 currentPosition = rb.position;
        Vector2 targetPosition = new Vector2(currentPosition.x + movement, currentPosition.y);
        rb.MovePosition(targetPosition);
    }
}
