using UnityEngine;

public static class ScoreManager
{
    public static int Score { get; private set; }
    public static void AddPoint()
    {
        Score++;
    }
}
