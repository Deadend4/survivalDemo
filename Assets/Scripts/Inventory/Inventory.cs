using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InventorySlot
{
    public Item item;
    public int amount;
    public InventorySlot(Item item, int amount = 1)
    {
        this.item = item;
        this.amount = amount;
    }
}
public class Inventory : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private int size = 5;
    [HideInInspector] private List<InventorySlot> items = new List<InventorySlot>();
    [Header("Events")]
    [SerializeField] public UnityEvent OnInventoryChanged;

    public bool AddItems(Item item, int amount = 1)
    {
        foreach (InventorySlot slot in items)
        {
            if (slot.item != null)
            {
                if (slot.item.id == item.id)
                {
                    slot.amount += amount;
                    OnInventoryChanged.Invoke();
                    return true;
                }
            }
            else
            {
                slot.item = item;
                slot.amount = amount;
                OnInventoryChanged.Invoke();
                return true;
            }

        }
        if (items.Count >= size) return false;
        InventorySlot new_slot = new InventorySlot(item, amount);
        items.Add(new_slot);
        OnInventoryChanged.Invoke();
        return true;
    }

    public bool DeleteItems(Item item, int amount = 1)
    {
        foreach (InventorySlot slot in items)
        {
            if (slot.item != null && slot.item.id == item.id)
            {
                if (slot.amount > amount)
                {
                    slot.amount -= amount;
                    OnInventoryChanged.Invoke();
                    return true;
                }
                else if (slot.amount == amount)
                {
                    slot.item = null;
                    OnInventoryChanged.Invoke();
                    return true;
                }
                else
                {
                    OnInventoryChanged.Invoke();
                    return false;
                }
            }
        }
        return false;

    }
    public Item GetItem(int index)
    {
        return index < items.Count ? items[index].item : null;
    }
    public int GetAmount(int index)
    {
        return index < items.Count ? items[index].amount : 0;
    }
    public int GetSize()
    {
        return items.Count;
    }
    public int GetAmountItem(int id)
    {
        foreach (InventorySlot slot in items)
        {
            if (slot.item != null && slot.item.id == id)
            {
                return slot.amount;
            }
        }
        return 0;
    }
    public Item GetItemByID(int id)
    {
        foreach (InventorySlot slot in items)
        {
            if (slot.item != null && slot.item.id == id)
            {
                return slot.item;
            }
        }
        return null;
    }
}
