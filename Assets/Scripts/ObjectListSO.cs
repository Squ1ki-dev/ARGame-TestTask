using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectListSO", menuName = "")]
public class ObjectListSO : ScriptableObject
{
    public List<ObjectType> objectTypes = new List<ObjectType>();
}
