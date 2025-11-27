using System;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class InventorySaver : MonoBehaviour
{
    public InventoryManager inventoryManager;
    string filePath => Application.persistentDataPath + "/inventory.json";
    public void SaveInventory()
    {
        InventoryData inventoryData = new InventoryData();
        foreach (Transform child in inventoryManager.inventoryGrid.transform)
        {
            Image itemImage = child.GetComponent<Image>();
            if (itemImage != null)
            {
                ItemData itemComponent = itemImage.GetComponent<ItemData>();
                if (itemComponent != null)
                {
                    ItemData itemData = new ItemData
                    {
                        itemName = itemComponent.itemName,
                        itemType = itemComponent.itemType,
                        cost = itemComponent.cost,
                        specialValue = itemComponent.specialValue,
                        iconName = itemComponent.icon.name
                    };
                    inventoryData.items.Add(itemData);
                }
            }
        }
        string json = JsonUtility.ToJson(inventoryData, true);
        File.WriteAllText(filePath, json);
    }

    public void LoadInventory()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            InventoryData inventoryData = JsonUtility.FromJson<InventoryData>(json);
            foreach (Transform child in inventoryManager.inventoryGrid.transform) Destroy(child.gameObject);
            foreach (var itemData in inventoryData.items)
            {
                ItemData newItem = inventoryManager.allItems.Find(item => item.itemName == itemData.itemName);
                if (newItem != null)
                {
                    ItemType itemType;
                    if (Enum.TryParse(itemData.itemType.ToString(), out itemType))
                    {
                        GameObject itemObject = Instantiate(inventoryManager.itemPrefab, inventoryManager.inventoryGrid.transform);
                        itemObject.GetComponent<Image>().sprite = newItem.icon;
                        var eventTrigger = itemObject.GetComponent<EventTrigger>();
                        if (eventTrigger != null)
                        {
                            inventoryManager.AddEventTrigger(eventTrigger, () => inventoryManager.ShowItemInfo(newItem), EventTriggerType.PointerEnter);
                            inventoryManager.AddEventTrigger(eventTrigger, inventoryManager.ClearItemInfo, EventTriggerType.PointerExit);
                        }
                    }
                    else
                    {
                        Debug.LogError($"Invalid ItemType: {itemData.itemType}");
                    }
                }
            }
        }
    }
}