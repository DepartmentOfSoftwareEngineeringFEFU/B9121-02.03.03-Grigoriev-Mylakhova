using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AssemblyUIButtonManager : MonoBehaviour
{
    [Header("UI ������")]
    [SerializeField] GameObject buttonAssemblyGO;  
    [SerializeField] Button buttonAssembly;         

    GameObject currentSelected;

    void Awake()
    {
        buttonAssemblyGO.SetActive(false);
        buttonAssembly.onClick.AddListener(OnClickAssembly);
    }

    
    public void RegisterSelected(GameObject obj)
    {
        currentSelected = obj;
        var info = obj.GetComponent<AssemblyInfo>();
        buttonAssemblyGO.SetActive(info != null && info.hasAssembly);
    }

    
    public void RegisterDeselected(GameObject obj)
    {
        if (obj == currentSelected)
        {
            currentSelected = null;
            buttonAssemblyGO.SetActive(false);
        }
    }

    // AssemblyUIButtonManager.cs
    public void ShowForObject(GameObject obj)   
    {
        RegisterSelected(obj);   
    }


    void OnClickAssembly()
    {
        if (currentSelected == null) return;

        var info = currentSelected.GetComponent<AssemblyInfo>();
        if (info != null && !string.IsNullOrEmpty(info.instructionSceneName))
        {
            SceneManager.LoadScene(info.instructionSceneName, LoadSceneMode.Single);
        }
        else
        {
            Debug.LogWarning("Instruction scene not defined for selected object.");
        }
    }
}
