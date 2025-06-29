using UnityEngine;
using UnityEngine.SceneManagement; 

public class GoToMyProjects : MonoBehaviour
{
    public string targetSceneName = "MyProjectsScene"; 

    public void OpenMyProjects()
    {
        
        SceneManager.LoadScene(targetSceneName);
    }
}