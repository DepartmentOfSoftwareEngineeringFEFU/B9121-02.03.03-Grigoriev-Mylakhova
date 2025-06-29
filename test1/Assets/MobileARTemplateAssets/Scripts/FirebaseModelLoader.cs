using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;       
using UnityEngine.UI;  
using TMPro;         
using System.Text;     
public class FirebaseModelLoader : MonoBehaviour
{
    public string firebaseUrl = "https://home-458c5-default-rtdb.firebaseio.com/models.json"; 

    [SerializeField] private Transform contentTransform;
    [SerializeField] private GameObject modelItemPrefab;
    [SerializeField] private TMP_Text statusText;

    // Поля формы
    [SerializeField] private TMP_InputField inputName;
    [SerializeField] private TMP_InputField inputDescription;
    [SerializeField] private TMP_InputField inputURL;

    void Start()
    {
        // Оставляем пустым, загрузка по кнопке
    }

    public void LoadModelsButton()
    {
        SetStatus("Загрузка моделей...");
        StartCoroutine(LoadModels());
    }

    public void AddModelButton()
    {
        if (string.IsNullOrEmpty(inputName.text) || string.IsNullOrEmpty(inputURL.text))
        {
            SetStatus("Все поля должны быть заполнены!");
            return;
        }

        ModelData newModel = new ModelData
        {
            name = inputName.text,
            description = inputDescription.text,
            url = inputURL.text
        };

        StartCoroutine(AddModelToFirebase(newModel));
    }
    
    IEnumerator AddModelToFirebase(ModelData model)
    {
        string modelId = "model" + Random.Range(1000, 9999); // Простой ID
        string json = JsonUtility.ToJson(model);

        var request = new UnityWebRequest(
            $"https://home-458c5-default-rtdb.firebaseio.com/models/{modelId}.json", 
            "PUT"
        );

        byte[] body = Encoding.UTF8.GetBytes(json);
        request.uploadHandler = new UploadHandlerRaw(body);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            SetStatus("Ошибка добавления модели: " + request.error);
        }
        else
        {
            SetStatus($"Модель '{model.name}' добавлена");
            inputName.text = "";
            inputDescription.text = "";
            inputURL.text = "";
            StartCoroutine(LoadModels()); // Обновить список
        }
    }

    IEnumerator LoadModels()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(firebaseUrl))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                SetStatus("Ошибка загрузки списка: " + www.error);
            }
            else
            {
                Dictionary<string, ModelData> modelsDict = JsonConvert.DeserializeObject<Dictionary<string, ModelData>>(www.downloadHandler.text);

                foreach (Transform child in contentTransform)
                    Destroy(child.gameObject);

                foreach (var kvp in modelsDict)
                {
                    ModelData model = kvp.Value;
                    CreateModelItem(model);
                }

                SetStatus("Модели готовы к загрузке");
            }
        }
    }

    void CreateModelItem(ModelData model)
    {
        GameObject item = Instantiate(modelItemPrefab, contentTransform);
        item.name = model.name;

        TMP_Text textComponent = item.GetComponentInChildren<TMP_Text>();
        if (textComponent != null)
        {
            textComponent.text = $"{model.name}\n{model.description}";
        }

        Button buttonComponent = item.GetComponent<Button>();
        if (buttonComponent != null)
        {
            buttonComponent.onClick.AddListener(() => StartCoroutine(DownloadModel(model)));
        }
    }

    IEnumerator DownloadModel(ModelData model)
    {
        SetStatus($"Загрузка модели {model.name}...");

        using (UnityWebRequest www = UnityWebRequest.Get(model.url))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                SetStatus($"Ошибка загрузки {model.name}: {www.error}");
            }
            else
            {
                byte[] data = www.downloadHandler.data;

                string filePath = Path.Combine(Application.persistentDataPath, $"{model.name}.fbx");
                File.WriteAllBytes(filePath, data);

                SetStatus($"✅ Модель '{model.name}' сохранена:\n{filePath}");
            }
        }
    }

    void SetStatus(string message)
    {
        if (statusText != null)
        {
            statusText.text = message;
        }
        Debug.Log(message);
    }
}

[System.Serializable]
public class ModelData
{
    public string name;
    public string url;
    public string description;
}