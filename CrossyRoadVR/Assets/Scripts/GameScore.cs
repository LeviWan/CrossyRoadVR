using UnityEngine;
using System.Collections;

public class GameScore : MonoBehaviour {

    public int highestScore=0;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateHighestScore(int newScore)
    {
        if (newScore>highestScore)
        {
            highestScore = newScore;
        }
    }

}
