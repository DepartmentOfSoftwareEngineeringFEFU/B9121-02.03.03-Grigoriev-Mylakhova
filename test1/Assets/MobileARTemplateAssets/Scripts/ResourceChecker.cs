using UnityEngine;

public class ResourceChecker : MonoBehaviour
{
    
    public void CheckPrefabs()
    {
        GameObject komod = Resources.Load<GameObject>("Komod");

        if (komod == null)
        {
            Debug.LogError("Префаб 'Komod' не найден в Resources/");
        }
        else
        {
            Debug.Log("Префаб 'Komod' найден!");
        }

        
        GameObject lamp = Resources.Load<GameObject>("lamp");
        if (lamp == null)
        {
            Debug.LogError("Префаб 'lamp' не найден в Resources/");
        }
        else
        {
            Debug.Log("Префаб 'lamp' найден!");
        }
    }

    
    private void Start()
    {
        CheckPrefabs();
    }
}