using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToDashboard : MonoBehaviour
{
    
    public void BackToDashboard()
    {
        SceneManager.LoadScene("Dashboard");
    }
}