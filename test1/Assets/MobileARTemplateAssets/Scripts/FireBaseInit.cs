using System;
using System.Threading.Tasks;
using Firebase;
using Firebase.Extensions;
using UnityEngine;

public class FireBaseInit : MonoBehaviour
{
    
    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(OnDependencyStatusReseived); 
    }

    private void OnDependencyStatusReseived(Task<DependencyStatus> task)
    {
        try
        {
            if (!task.IsCompletedSuccessfully)
                throw new System.Exception(message: "could not resolve all depend", task.Exception);
            var status = task.Result;
            if (status != DependencyStatus.Available)
                throw new System.Exception(message: "could not resolve all firebase depend: {status}");
            print(message: "cool");
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }
}
