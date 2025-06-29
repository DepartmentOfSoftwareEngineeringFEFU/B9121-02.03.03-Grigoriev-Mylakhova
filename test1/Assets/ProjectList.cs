using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProjectList : MonoBehaviour
{
    public GameObject projectItemPrefab; 
    public Transform contentParent;      

    private List<string> savedProjects = new List<string>();

    private void Start()
    {
        Debug.Log("Загружаем список сохранённых проектов...");
        LoadSavedProjects();
        PopulateProjectList();
    }

    private void LoadSavedProjects()
    {
        savedProjects.Clear();

        string path = Application.persistentDataPath;

        if (!Directory.Exists(path))
        {
            Debug.LogWarning("Папка сохранений не найдена: " + path);
            return;
        }

        DirectoryInfo dir = new DirectoryInfo(path);
        FileInfo[] files = dir.GetFiles("*.json");

        foreach (var file in files)
        {
            savedProjects.Add(file.Name);
            Debug.Log("Найден файл: " + file.Name);
        }
    }

    private void PopulateProjectList()
    {
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }

        foreach (string projectName in savedProjects)
        {
            GameObject itemGO = Instantiate(projectItemPrefab, contentParent);

            TextMeshProUGUI textComponent = itemGO.GetComponentInChildren<TextMeshProUGUI>();
            Button buttonComponent = itemGO.GetComponent<Button>();

            if (textComponent != null)
                textComponent.text = projectName;

            if (buttonComponent != null)
            {
                string capturedName = projectName;
                buttonComponent.onClick.AddListener(() => LoadProject(capturedName));
            }
        }
    }

    public void LoadProject(string projectName)
    {
        Debug.Log($"Выбран проект: {projectName}");
        ProjectLoader.SelectedProject = projectName;
        UnityEngine.SceneManagement.SceneManager.LoadScene("ARScene");
    }
}