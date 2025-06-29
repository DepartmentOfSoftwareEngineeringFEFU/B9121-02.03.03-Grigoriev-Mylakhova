using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class InfoPopup : MonoBehaviour
{
    public GameObject infoPanel;
    public TextMeshProUGUI infoText;

    private string currentDescription = "Выберите объект для просмотра информации";
    
    
    public GameObject selectedObject;

    public void ShowInfo()
    {
        if (infoPanel != null && selectedObject != null)
        {
            ObjectInfo objectInfo = selectedObject.GetComponent<ObjectInfo>();
            if (objectInfo != null)
            {
                infoText.text = objectInfo.objectDescription;
            }
            infoPanel.SetActive(true);
        }
    }

    public void HideInfo()
    {
        if (infoPanel != null)
            infoPanel.SetActive(false);
    }

    public void SetDescription(string description)
    {
        currentDescription = description;
        if (infoPanel.activeSelf && infoText != null)
            infoText.text = description;
    }

    private void Update()
    {
        if (infoPanel.activeSelf && Input.GetMouseButtonDown(0) &&
            !EventSystem.current.IsPointerOverGameObject())
        {
            HideInfo();
        }
    }
}