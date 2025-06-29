using UnityEngine;

public class ARSceneLoader : MonoBehaviour
{
    private void Start()
    {
        
        if (!string.IsNullOrEmpty(ProjectLoader.SelectedProject))
        {
            
            if (ProjectSaver.Instance != null)
            {
                ProjectSaver.Instance.LoadProject(ProjectLoader.SelectedProject); 
            }
            else
            {
                Debug.LogError("ProjectSaver instance is null. Make sure the ProjectSaver is present in the scene.");
            }
        }
        else
        {
            Debug.LogWarning("Selected project is empty or null.");
        }
    }
}
