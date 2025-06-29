using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private string currentScene = "";

    void Start()
    {
        
        LoadSceneAdditive("SampleScene");
    }

    public void LoadSceneAdditive(string sceneName)
    {
        if (currentScene != "")
        {
            
            StartCoroutine(UnloadAndLoad(sceneName));
        }
        else
        {
            
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            currentScene = sceneName;
        }
    }

    private IEnumerator UnloadAndLoad(string sceneName)
    {
        yield return SceneManager.UnloadSceneAsync(currentScene);
        yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        currentScene = sceneName;
    }
}
