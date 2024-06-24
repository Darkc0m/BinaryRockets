using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private static int score;

    public static void increaseScore()
    {
        score++;
    }

    public static void resetScore()
    {
        score = 0;
    }

    public static int getScore()
    {
        return score;
    }
}
