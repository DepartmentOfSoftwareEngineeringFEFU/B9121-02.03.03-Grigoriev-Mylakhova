using UnityEngine;
using UnityEngine.SceneManagement;  
using UnityEngine.UI;              

public class BackButton : MonoBehaviour
{
    
    public void OnBackButtonPressed()
    {
        
        SceneManager.LoadScene("AuthChoice");
    }


    public void OnSecondButtonPressed()
    {
        
        SceneManager.LoadScene("Dashboard");
    }
}
