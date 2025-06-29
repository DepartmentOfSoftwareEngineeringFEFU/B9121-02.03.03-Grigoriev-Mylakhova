using UnityEngine;
public class PersistentARRoot : MonoBehaviour 
{ 
    void Awake() { DontDestroyOnLoad(gameObject); } 
}