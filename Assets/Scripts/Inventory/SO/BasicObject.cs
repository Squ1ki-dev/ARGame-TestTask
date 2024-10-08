using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Basic Object", menuName = "Inventory System/Items/Basic Type")]
public class BasicObject : ItemObject
{
    public void Awake() => type = ItemType.Basic;
}
