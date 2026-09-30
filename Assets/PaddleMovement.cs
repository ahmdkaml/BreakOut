using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleMovement : MonoBehaviour
{
    // camera related variables
    private Camera mainCamera;
    private float cameraCenterX;
    private float cameraHalfWidth;

    // paddle related variables
    private float minX;
    private float maxX;
    [SerializeField] private float speed = 10f;
    private float moveInput;
    [SerializeField] private InputActionReference moveAction;
    private Rigidbody2D rb;

    private Collider2D paddleCollider;

    private float paddleHalfWidth;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        paddleCollider = GetComponent<Collider2D>();
        paddleHalfWidth = paddleCollider.bounds.extents.x;
        mainCamera = Camera.main;
        cameraHalfWidth = mainCamera.orthographicSize * mainCamera.aspect;
        cameraCenterX = mainCamera.transform.position.x;
        minX = cameraCenterX - cameraHalfWidth + paddleHalfWidth;
        maxX = cameraCenterX + cameraHalfWidth - paddleHalfWidth;
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
        float newXPosition = Mathf.Clamp(currentPosition.x + movement, minX, maxX);
        Vector2 targetPosition = new Vector2(newXPosition, currentPosition.y);
        rb.MovePosition(targetPosition);
    }
}
