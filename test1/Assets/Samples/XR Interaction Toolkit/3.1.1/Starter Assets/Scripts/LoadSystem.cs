using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadSystem : MonoBehaviour
{
    [SerializeField] private string saveFileName = "room_save.json";
    [SerializeField] private Transform objectsParent;
    [SerializeField] private List<GameObject> availablePrefabs;

    public void Load()
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);
        if (!File.Exists(path))
        {
            Debug.LogWarning("���� ������� �� ������.");
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
                var tag = p.GetComponent<PlaceableObject>();
                return tag != null && tag.prefabName == objData.prefabName;
            });

            if (prefab == null)
            {
                Debug.LogWarning($"�� ������ ������ {objData.prefabName}");
                continue;
            }

            var go = Instantiate(prefab, objData.position, objData.rotation, objectsParent);
            go.transform.localScale = objData.scale;
        }

        Debug.Log("������ ��������.");
    }
}
