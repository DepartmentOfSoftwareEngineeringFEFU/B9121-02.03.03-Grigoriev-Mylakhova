using UnityEngine;

public class PlacedItem : MonoBehaviour
{
    public string itemName;

    private void Awake()
    {
        itemName = gameObject.name;
    }
}