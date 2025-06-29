using UnityEngine;
using UnityEngine.SceneManagement;

public class AuthManager : MonoBehaviour
{
    
    public void LoadLoginScene()
    {
        SceneManager.LoadScene("AuthLogin");
    }

    
    public void LoadRegisterScene()
    {
        SceneManager.LoadScene("AuthRegister");
    }

    
    public void LoadAdminScene()
    {
        SceneManager.LoadScene("AdminLogin");  
    }
}