using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour
{
    public GameObject[] candles;
    public bool candle1, candle3, candle5 = false; public bool candle2, candle4 = true;
    public GameObject greenKey;
    public void CandleGame(string name)
    {
        if (name == "Candle[1]")
        {
            candle1 = Flip(candle1);
            candle2 = Flip(candle2);
        }
        if (name == "Candle[2]")
        {
            candle1 = Flip(candle1);
            candle2 = Flip(candle2);
            candle3 = Flip(candle3);
        }
        if (name == "Candle[3]")
        {
            candle2 = Flip(candle2);
            candle3 = Flip(candle3);
            candle4 = Flip(candle4);
        }
        if (name == "Candle[4]")
        {
            candle3 = Flip(candle3);
            candle4 = Flip(candle4);
            candle5 = Flip(candle5);
        }
        if (name == "Candle[5]")
        {
            candle4 = Flip(candle4);
            candle5 = Flip(candle5);
        }
        if (candle1 == true && candle2 == true && candle3 == true && candle4 == true && candle5 == true)
        {
            Instantiate(greenKey, candles[3].transform.position, candles[3].transform.rotation);
        }
    }
    bool Flip(bool toc)
    {
        if (toc == false)
        {
            toc = true;
            return toc;
        }
        if (toc == true)
        {
            toc = false;
            return toc;
        }
        return toc;
    }
}
