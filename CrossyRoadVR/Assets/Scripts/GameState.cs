using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {

    public static GameState instance;
    public bool isGameOver { get; set; }

    void Awake()
    {
        instance = this;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
	
}
