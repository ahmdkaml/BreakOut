using UnityEngine;

public class BallLossDetector : MonoBehaviour
{
    [SerializeField] private BallMovement ballMovement;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("Ball lost!");
            ballMovement.ResetToPaddle();
        }

    }
}
