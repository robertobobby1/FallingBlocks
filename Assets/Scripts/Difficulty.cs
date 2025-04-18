using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Difficulty
{
    private static float secondsToMaxDifficulty = 60;
    public static float getDifficultyPercentage() 
    {
        return Mathf.Clamp01(Time.time / secondsToMaxDifficulty);
    }
}
