using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [Header("UI References")]
    public GridLayoutGroup inventoryGrid;
    public GameObject itemPrefab;
    public Button openChestButton;

    [Header("Item Info Panel")]
    public Text itemNameText;
    public Text itemTypeText;
    public Text itemCostText;
    public Text itemSpecialValueText;
    public Image itemIconImage;

    [Header("Inventory Settings")]
    public int maxItems = 20;

    [Header("Scriptable Objects")]
    public List<ItemData> allItems;

    Queue<ItemData> itemQueue = new Queue<ItemData>();

    void Start()
    {
        PopulateItemQueue();
        openChestButton.onClick.AddListener(OpenChest);
    }

    void PopulateItemQueue()
    {
        var shuffledItems = new List<ItemData>(allItems);
        shuffledItems.Sort((a, b) => Random.Range(-1, 2));
        foreach (var item in shuffledItems) itemQueue.Enqueue(item);
    }

    void OpenChest()
    {
        if (inventoryGrid.transform.childCount >= maxItems)
        {
            return;
        }
        if (itemQueue.Count == 0) PopulateItemQueue();
        ItemData newItem = itemQueue.Dequeue();
        GameObject itemObject = Instantiate(itemPrefab, inventoryGrid.transform);
        itemObject.GetComponent<Image>().sprite = newItem.icon;
        var eventTrigger = itemObject.GetComponent<EventTrigger>();
        if (eventTrigger != null)
        {
            AddEventTrigger(eventTrigger, () => ShowItemInfo(newItem), EventTriggerType.PointerEnter);
            AddEventTrigger(eventTrigger, ClearItemInfo, EventTriggerType.PointerExit);
        }
    }
    public void AddEventTrigger(EventTrigger trigger, System.Action action, EventTriggerType triggerType)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry { eventID = triggerType };
        entry.callback.AddListener((_) => action.Invoke());
        trigger.triggers.Add(entry);
    }

    public void ShowItemInfo(ItemData item)
    {
        itemNameText.text = item.itemName;
        itemTypeText.text = item.itemType.ToString();
        itemCostText.text = $"Стоимость: {item.cost}";
        itemSpecialValueText.text = item.itemType switch
        {
            ItemType.Armor => $"Защита: {item.specialValue}",
            ItemType.Weapon => $"Урон: {item.specialValue}",
            ItemType.Consumable => $"Здоровье: {item.specialValue}",
            ItemType.Material => $"Прочность: {item.specialValue}",
            _ => "Нет данных"
        };
        itemIconImage.sprite = item.icon;
        itemIconImage.enabled = true;
    }

    public void ClearItemInfo()
    {
        itemNameText.text = "";
        itemTypeText.text = "";
        itemCostText.text = "";
        itemSpecialValueText.text = "";
        itemIconImage.sprite = null;
        itemIconImage.enabled = false;
    }
}

