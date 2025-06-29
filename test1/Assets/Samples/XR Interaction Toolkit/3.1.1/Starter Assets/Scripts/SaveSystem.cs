using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    [SerializeField] private string saveFileName = "room_save.json";
    [SerializeField] private Transform objectsParent; 

    public void Save()
    {
        var saveData = new RoomSaveData();

        foreach (Transform child in objectsParent)
        {
            var placeable = child.GetComponent<PlaceableObject>();
            if (placeable == null) continue;

            var data = new PlacedObjectData
            {
                prefabName = placeable.prefabName,
                position = child.position,
                rotation = child.rotation,
                scale = child.localScale
            };

            saveData.placedObjects.Add(data);
        }

        var json = JsonUtility.ToJson(saveData, true);
        var path = Path.Combine(Application.persistentDataPath, saveFileName);
        File.WriteAllText(path, json);

        Debug.Log($"������ ��������: {path}");
    }
}
