using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSampleScene : MonoBehaviour
{
    
    public void OpenSampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}