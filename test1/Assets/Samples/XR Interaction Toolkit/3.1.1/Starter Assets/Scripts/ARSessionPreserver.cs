using UnityEngine;

public class ARSessionPreserver : MonoBehaviour
{
    private static ARSessionPreserver instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); 
        }
    }
}
