using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    string itemClass = "Item";
    int stackSize = 1;

    public Item(string argClass, int argStackSize)
    {
        itemClass = argClass;
        stackSize = argStackSize;
    }
}
