using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{

    public static GameState instance;
    private SceneLoadManager sceneLoader;
    public bool isGameOver
    {
        get;
        set;
    }

    public void SetHigherScore()
    {
        GameScore gameScore=GameObject.FindObjectOfType<GameScore>();
        Player player = GameObject.FindObjectOfType<Player>();
        int score = Mathf.FloorToInt(player.transform.position.z);
        gameScore.UpdateHighestScore(score);
    }

    void Awake()
    {
        instance = this;
        sceneLoader = GameObject.FindObjectOfType<SceneLoadManager>();
    }

    public void ResetGame()
    {
        sceneLoader.LoadSceneByOffset(0);
        
    }

    public void Back()
    {
        sceneLoader.LoadSceneByOffset(-1);
    }
    public void Quit()
    {
        Application.Quit();
    }

    void Update()
    {
        if (isGameOver)
        {
            SetHigherScore();
        }
    }


}
