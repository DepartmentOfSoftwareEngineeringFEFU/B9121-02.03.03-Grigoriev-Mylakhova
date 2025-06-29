using System;
using System.Collections.Generic;
using UnityEngine; // ← это обязательно!

[Serializable]
public class PlacedObjectData
{
    public string prefabName;
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;
}

[Serializable]
public class RoomSaveData
{
    public List<PlacedObjectData> placedObjects = new List<PlacedObjectData>();
}
