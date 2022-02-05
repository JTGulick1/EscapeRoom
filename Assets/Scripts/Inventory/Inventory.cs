using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<Item> storage = new List<Item>();

    private void Awake()
    {
        
    }

    public void AddItem(Item argItem)
    {
        storage.Add(argItem);
    }

    public void RemoveItem(Item argItem)
    {
        storage.Remove(argItem);
    }

    public bool ContainsItem(Item argItem)
    {
        return storage.Contains(argItem);
    }
}
