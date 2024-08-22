using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Basic,
    Modified,
    Default
}

public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
}