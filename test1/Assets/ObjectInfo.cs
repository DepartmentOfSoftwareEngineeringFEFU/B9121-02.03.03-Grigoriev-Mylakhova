using UnityEngine;

public class ObjectInfo : MonoBehaviour
{
    [TextArea(3, 10)]
    public string objectDescription = "Описание объекта";

    private InfoPopup infoPopup;

    private void Start()
    {
        
        GameObject manager = GameObject.Find("UIManager");
        if (manager != null)
        {
            infoPopup = manager.GetComponent<InfoPopup>();
        }
        else
        {
            Debug.LogError("UIManager не найден!");
        }
    }

    public void SetSelectedObject()
    {
        if (infoPopup != null)
        {
            infoPopup.selectedObject = gameObject;
            infoPopup.ShowInfo();
        }
    }
}