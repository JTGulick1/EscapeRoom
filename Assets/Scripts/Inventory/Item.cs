using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    string itemClass = "Item";
    int stackSize = 1;

    Sprite sprite;

    public Item(string argClass, int argStackSize, string argSprite)
    {
        itemClass = argClass;
        stackSize = argStackSize;
        sprite = Resources.Load<Sprite>(argSprite);
    }
}
