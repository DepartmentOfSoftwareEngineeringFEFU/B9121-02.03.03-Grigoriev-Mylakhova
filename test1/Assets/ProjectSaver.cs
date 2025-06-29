using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ProjectSaver : MonoBehaviour
{
    public static ProjectSaver Instance { get; private set; }

    private string savePath;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            savePath = Application.persistentDataPath;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveProject()
    {
        List<ItemData> itemsToSave = new List<ItemData>();

        foreach (var placedItem in FindObjectsByType<PlacedItem>(FindObjectsSortMode.None))
        {
            ItemData data = new ItemData();
            data.itemName = placedItem.gameObject.name;
            itemsToSave.Add(data);
        }

        string json = JsonHelper.ToJson(itemsToSave.ToArray());
        string filePath = Path.Combine(savePath, "saved_project.json");

        File.WriteAllText(filePath, json);
        Debug.Log("Проект сохранён в: " + filePath);
    }

    public void LoadProject(string fileName)
    {
        string filePath = Path.Combine(savePath, fileName);

        if (!File.Exists(filePath))
        {
            Debug.LogError("Файл не найден: " + filePath);
            return;
        }

        string json = File.ReadAllText(filePath);
        Debug.Log("JSON содержимое: " + json);

        ItemData[] loadedItems = JsonHelper.FromJson<ItemData>(json);

        if (loadedItems == null || loadedItems.Length == 0)
        {
            Debug.LogError("Файл пустой или содержит неверные данные");
            return;
        }

        Debug.Log($"Загружено {loadedItems.Length} объектов");

        ARObjectPlacer arObjectPlacer = FindFirstObjectByType<ARObjectPlacer>();

        if (arObjectPlacer != null)
        {
            arObjectPlacer.LoadProject(new List<ItemData>(loadedItems));
        }
        else
        {
            Debug.LogError("ARObjectPlacer не найден в сцене!");
        }
    }
}