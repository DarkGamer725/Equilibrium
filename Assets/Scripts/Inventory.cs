using NUnit.Framework;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<Item> items;

    private void Start()
    {
        items = new List<Item>();
    }

    public Item GetItem(int index)
    {
        if (index < 0 || index >= items.Count)
        {
            return null;
        }
        return items[index];
    }

    public Item GetItem(string name)
    {
        foreach(Item item in items)
        {
            if (item.GetName().Equals(name))
            {
                return item;
            }
        }
        return null;
    }

    public bool AddItem(Item newItem) 
    {
        if (HasItem(newItem))
        {
            return false;
        }
        else
        {
            items.Add(newItem);
            return true;
        }
    }

    public void RemoveItem(int index) 
    {
        if (index < 0 || index >= items.Count)
        {
            items.RemoveAt(index);
        }
    }

    public void RemoveItem(Item item)
    {
        RemoveItem(item.GetName());
    }

    public void RemoveItem(string name)
    {
        foreach (Item item in items)
        {
            if (item.GetName().Equals(name))
            {
                items.Remove(item);
                return;
            }
        }
    }

    public void UseItem(int index)
    {
        Item item = GetItem(index);
        if (item != null)
        {
            item.Use();
        }
    }

    public void UseItem(string name)
    {
        Item item = GetItem(name);
        if (item != null)
        {
            item.Use();
        }
    }

    public bool HasItem(string name)
    {
        return GetItem(name) != null;
    }

    public bool HasItem(Item item)
    {
        return HasItem(item.GetName());
    }

    public string PrintAllItems()
    {
        string returnedString = "";
        foreach (Item item in items)
        {
            returnedString += item.GetName() + " ";
        }
        return returnedString;
    }
}
