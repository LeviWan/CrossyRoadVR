using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
    public Button button;
    void Awake()
    {
        button.onClick.AddListener(LoadGame);
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
	
}
