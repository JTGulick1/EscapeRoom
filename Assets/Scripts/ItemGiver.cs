using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGiver : MonoBehaviour
{
    public string itemClass;
    public int stackSize;
    public Sprite itemSprite;

    public bool destroyWholeObjectAfterGive = false;

    public Item GetItem()
    {
        StartCoroutine(DestroyAfterGive());
        return new Item(itemClass, stackSize, itemSprite);
    }

    IEnumerator DestroyAfterGive()
    {
        yield return new WaitForEndOfFrame();
        Destroy(destroyWholeObjectAfterGive ? this.gameObject : this);
    }
}
