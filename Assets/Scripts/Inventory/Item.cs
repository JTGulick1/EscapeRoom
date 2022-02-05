using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string itemClass = "Item";
    int stackSize = 1;

    public Sprite sprite;

    public Item(string argClass, int argStackSize, string argSprite)
    {
        itemClass = argClass;
        stackSize = argStackSize;
        sprite = Resources.Load<Sprite>(argSprite);
    }

    public Item(string argClass, int argStackSize, Sprite argSprite)
    {
        itemClass = argClass;
        stackSize = argStackSize;
        sprite = argSprite;
    }
}
