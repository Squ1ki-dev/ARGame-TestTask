using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Modified Object", menuName = "Inventory System/Items/Modified Type")]
public class Modified : ItemObject
{
    public void Awake() => type = ItemType.Modified;
}

