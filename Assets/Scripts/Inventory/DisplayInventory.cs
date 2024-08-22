using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInventory : MonoBehaviour
{
    [SerializeField] private InventoryObject inventory;
    [SerializeField] private InventoryScreenSO inventoryDisplaySO;
    
    private Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    private void Start() => CreateDisplay();

    private void Update() => UpdateDisplay();

    private void CreateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            var rectTransform = obj.GetComponent<RectTransform>();
            rectTransform.localPosition = GetPosition(i);
            var textComponent = obj.GetComponentInChildren<TMP_Text>();
            textComponent.text = inventory.Container[i].amount.ToString("n0");
            itemsDisplayed.Add(inventory.Container[i], obj);
        }
    }

    private void UpdateDisplay()
    {
        var currentItems = inventory.Container.ToDictionary(slot => slot, slot => slot.amount.ToString("n0"));

        foreach (var slot in currentItems.Keys)
        {
            if (itemsDisplayed.ContainsKey(slot))
                itemsDisplayed[slot].GetComponentInChildren<TMP_Text>().text = currentItems[slot];
            else
            {
                var obj = Instantiate(slot.item.prefab, Vector3.zero, Quaternion.identity, transform);
                var rectTransform = obj.GetComponent<RectTransform>();
                rectTransform.localPosition = GetPosition(inventory.Container.IndexOf(slot));
                var textComponent = obj.GetComponentInChildren<TMP_Text>();
                textComponent.text = currentItems[slot];
                itemsDisplayed.Add(slot, obj);
            }
        }
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(inventoryDisplaySO.XStartPos + (inventoryDisplaySO.XSpaceBetweenItems * (i / inventoryDisplaySO.NumOfColumn)), 0, 0);
    }
}
