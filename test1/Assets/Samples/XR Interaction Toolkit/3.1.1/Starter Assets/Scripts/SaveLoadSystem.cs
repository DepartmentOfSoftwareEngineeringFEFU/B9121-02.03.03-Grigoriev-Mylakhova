using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    [SerializeField] private Transform objectsParent;
    [SerializeField] private List<GameObject> availablePrefabs;
    [SerializeField] private string saveFileName = "room_save.json";

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
        Debug.Log($"��������� �: {path}");
    }

    public void Load()
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);
        if (!File.Exists(path))
        {
            Debug.LogWarning("���� �� ������.");
            return;
        }

        var json = File.ReadAllText(path);
        var saveData = JsonUtility.FromJson<RoomSaveData>(json);

        
        foreach (Transform child in objectsParent)
            Destroy(child.gameObject);

        foreach (var objData in saveData.placedObjects)
        {
            var prefab = availablePrefabs.Find(p =>
            {
                var info = p.GetComponent<PlaceableObject>();
                return info != null && info.prefabName == objData.prefabName;
            });

            if (prefab == null)
            {
                Debug.LogWarning($"�� ������ ������: {objData.prefabName}");
                continue;
            }

            var go = Instantiate(prefab, objData.position, objData.rotation, objectsParent);
            go.transform.localScale = objData.scale;
        }

        Debug.Log("������ ��������.");
    }
}
