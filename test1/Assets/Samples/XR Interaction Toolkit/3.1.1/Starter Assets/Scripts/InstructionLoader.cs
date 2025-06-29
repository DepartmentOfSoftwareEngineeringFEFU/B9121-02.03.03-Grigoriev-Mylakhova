using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;


public class InstructionLoader : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;       
    [SerializeField] GameObject defaultPrefab;   

    void Start()
    {
        var prefab = AssemblyData.prefabToAssemble ?? defaultPrefab;
        if (prefab == null)
        {
            Debug.LogError("InstructionLoader: prefab missing.");
            return;
        }

        var go = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);

        
        var ctrl = go.GetComponent<ChairAssemblyController>();   // AssemblyController
        //var ctrl = go.GetComponentInChildren<AssemblyStepSwitcher>();
        if (ctrl != null)
            ctrl.ShowInstruction();
        else
            Debug.LogWarning("Prefab has no AssemblyController.");
    }

    
    public void BackToMain()
    {
       /* var arSession = Object.FindFirstObjectByType<UnityEngine.XR.ARFoundation.ARSession>();
        if (arSession != null)
        {
            arSession.enabled = false;
            arSession.Reset();
        }*/

        AssemblyData.prefabToAssemble = null;
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        //UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene", UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
}
