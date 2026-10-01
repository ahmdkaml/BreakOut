using UnityEngine;

public class BrickGridGenerator : MonoBehaviour
{
    [SerializeField] private GameObject brickPrefab;
    [SerializeField] private int rows = 3;
    [SerializeField] private int columns = 10;
    [SerializeField] private float horizontalSpacing = 1.6f;
    [SerializeField] private float verticalSpacing = 0.65f;
    [SerializeField] private Vector2 startPosition = new Vector2(-7.2f, 3.5f);

    // Generate bricks in a grid pattern based on the specified rows, columns, and spacing
    [ContextMenu("Generate Bricks")]
    private void GenerateBricks()
    {
        if (brickPrefab == null)
        {
            Debug.LogError("Brick Prefab is not assigned!");
            return;
        }
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                Vector2 position = new Vector2(
                    startPosition.x + column * horizontalSpacing,
                    startPosition.y - row * verticalSpacing
                );
                Instantiate(brickPrefab, position, Quaternion.identity, transform);

            }
        }

    }
}
