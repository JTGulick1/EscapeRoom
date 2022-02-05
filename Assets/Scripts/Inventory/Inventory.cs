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
        AddItem(new Item("Blue Key", 1, "Sprite/UIBlueKey"));
        AddItem(new Item("Green Key", 1, "Sprite/UIGreenKey"));
        AddItem(new Item("Heart Key", 1, "Sprite/UIHeartKey"));
        AddItem(new Item("Lighter", 1, "Sprite/UILighter"));
        AddItem(new Item("Steak Knife", 1, "Sprite/UISteakKnife"));
        AddItem(new Item("UV Light", 1, "Sprite/UIUVLight"));
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

    public void GrabbedItem(string name)
    {
        foreach (Item item in storage)
        {
            if (item.itemClass == name)
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
