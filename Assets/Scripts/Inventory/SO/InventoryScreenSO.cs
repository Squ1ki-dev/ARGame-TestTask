using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryDisplay")]
public class InventoryScreenSO : ScriptableObject
{
    public int NumOfColumn;
    public int XStartPos;
    public int XSpaceBetweenItems;
}
