using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    List<Item> storage = new List<Item>();
    public Image invSlot1;
    public Image invSlot2;
    bool slot1 = false;
    bool slot2 = false;

    private void Awake()
    {
        
    }

    public void AddItem(Item argItem)
    {
        storage.Add(argItem);
        GrabbedItem(argItem);
    }

    public void RemoveItem(Item argItem)
    {
        if (argItem.sprite == invSlot1.sprite)
        {
            invSlot1.sprite = null;
        }
        else if (argItem.sprite == invSlot2.sprite)
        {
            invSlot2.sprite = null;
        }

        storage.Remove(argItem);
    }

    public bool ContainsItem(Item argItem)
    {
        return storage.Contains(argItem);
    }

    public void GrabbedItem(Item argItem)
    {
        foreach (Item item in storage)
        {
            if (item.itemClass == argItem.itemClass)
            {
                if (slot1 == false)
                {
                    invSlot1.sprite = item.sprite;
                    slot1 = true;
                    return;
                }
                if (slot2 == false)
                {
                    invSlot2.sprite = item.sprite;
                    slot2 = true;
                    return;
                }
            }
        }
    }
}
