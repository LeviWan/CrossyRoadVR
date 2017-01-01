using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour {

    public float SceneLoadingTime = 0.0f;

    public void LoadNextScene()
    {
        LoadSceneByOffset(1);
    }

    public void LoadSceneByOffset(int sceneOffset)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sceneOffset);
    }
}
