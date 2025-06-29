using System.Collections.Generic;
using UnityEngine;

public class ARObjectPlacer : MonoBehaviour
{
    public void LoadProject(List<ItemData> loadedItems)
    {
        Debug.Log($"Начинаем размещение {loadedItems.Count} объектов...");

        foreach (var item in loadedItems)
        {
            Debug.Log($"Загружаем объект: {item.itemName}");

            GameObject prefab = Resources.Load<GameObject>(item.itemName);

            if (prefab != null)
            {
                Vector3 spawnPosition = Vector3.zero + Random.insideUnitSphere * 0.5f;
                spawnPosition.y = 0;

                GameObject go = Instantiate(prefab, spawnPosition, Quaternion.identity);
                go.name = item.itemName;

                Debug.Log($"Объект {item.itemName} создан на позиции {spawnPosition}");
            }
            else
            {
                Debug.LogError($"Префаб {item.itemName} не найден в Resources/");
            }
        }

        Debug.Log("Все объекты успешно размещены.");
    }
}