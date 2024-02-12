// Programmed By Arija

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class Score
{
    private static int score;

    public static void Start()
    {
        score = 0;
    }

    public static int GetScore()
    {
        return score;
    }

    public static void IncreaseScore() 
    { 
        score += 1; 
    }

    // I don't know if this works but it probably should be called in the file with the player
    public static void ScorePoints(int points, ScoreDisplay scored)
    {
        score += points;
        scored.UpdateScore(score);
    }
}
