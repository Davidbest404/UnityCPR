using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Armor,
    Weapon,
    Consumable,
    Material
}

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    public Sprite icon;
    public ItemType itemType;
    public string itemName;
    public string iconName;
    public int cost;
    public int specialValue; 
}

[System.Serializable]
public class InventoryData
{
    public List<ItemData> items = new List<ItemData>();
}
