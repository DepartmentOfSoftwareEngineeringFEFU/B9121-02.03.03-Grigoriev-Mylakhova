using UnityEngine;

public class InstructionObjectMover : MonoBehaviour
{
    public float distanceInFront = 0.7f;
    public float yGroundLevel = 0f;

    void Start()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("AssemblyObject");

        if (obj == null)
        {
            Debug.LogWarning("Не найден объект с тегом AssemblyObject");
            return;
        }

        Camera cam = Camera.main;

        
        Vector3 forward = cam.transform.forward;
        forward.y = 0;
        forward.Normalize();

        
        Vector3 spawnPosition = cam.transform.position + forward * distanceInFront;
        spawnPosition.y = yGroundLevel;

       
        Vector3 lookDirection = cam.transform.position - spawnPosition;
        lookDirection.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookDirection);

        
        obj.transform.position = spawnPosition;
        obj.transform.rotation = rotation;
    }
}