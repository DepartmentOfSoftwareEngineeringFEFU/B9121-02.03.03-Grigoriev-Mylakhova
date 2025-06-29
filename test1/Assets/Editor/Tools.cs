#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [MenuItem("Tools/Open Build Settings")]
    private static void OpenBuildSettings()
    {
        EditorWindow.GetWindow(System.Type.GetType("UnityEditor.BuildPlayerWindow,UnityEditor"));
    }
}
#endif