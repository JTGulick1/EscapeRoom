using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour
{
    public GameObject[] candles;
    public bool candle1, candle3, candle5 = false; public bool candle2, candle4 = true;
    public GameObject greenKey;
    public Transform greenKeySpawnLocation;

    public GameObject candle1Fire;
    public GameObject candle2Fire;
    public GameObject candle3Fire;
    public GameObject candle4Fire;
    public GameObject candle5Fire;

    bool keySpawned = false;

    public void CandleGame(string name)
    {
        if (name == "Candle[1]")
        {
            candle1 = Flip(candle1, candle1Fire);
            candle2 = Flip(candle2, candle2Fire);
        }
        if (name == "Candle[2]")
        {
            candle1 = Flip(candle1, candle1Fire);
            candle2 = Flip(candle2, candle2Fire);
            candle3 = Flip(candle3, candle3Fire);
        }
        if (name == "Candle[3]")
        {
            candle2 = Flip(candle2, candle2Fire);
            candle3 = Flip(candle3, candle3Fire);
            candle4 = Flip(candle4, candle4Fire);
        }
        if (name == "Candle[4]")
        {
            candle3 = Flip(candle3, candle3Fire);
            candle4 = Flip(candle4, candle4Fire);
            candle5 = Flip(candle5, candle5Fire);
        }
        if (name == "Candle[5]")
        {
            candle4 = Flip(candle4, candle4Fire);
            candle5 = Flip(candle5, candle5Fire);
        }
        if (candle1 == true && candle2 == true && candle3 == true && candle4 == true && candle5 == true)
        {
            if (!keySpawned)
            {
                Instantiate(greenKey, greenKeySpawnLocation);
                keySpawned = true;
                GameObject.Find("Gamemanager").GetComponent<GameManager>().inventory.RemoveItem(new Item("Lighter", 1, "Sprite/UILighter"));
            }
        }
    }
    bool Flip(bool toc, GameObject argFireObject)
    {
        if (toc == false)
        {
            toc = true;
            argFireObject.SetActive(true);
            argFireObject.transform.GetChild(0).gameObject.SetActive(true);
            return toc;
        }
        else if (toc == true)
        {
            toc = false;
            argFireObject.SetActive(false);
            argFireObject.transform.GetChild(0).gameObject.SetActive(false);
            return toc;
        }
        return toc;
    }
}
