using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera main;
    private bool tic = false;
    public GameObject[] candles;
    public bool candle1, candle3, candle5 = false; public bool candle2, candle4 = true;
    public GameObject greenKey;
    void Update()
    {
        if (Input.mousePosition.x <= 100)
        {
            if (main.transform.rotation.y >= -0.1304f)
            {
                main.transform.Rotate(0, -1 * Time.fixedDeltaTime, 0);
            }
        }
        if (Input.mousePosition.x >= 1700)
        {
            if (main.transform.rotation.y <= 0.1304f)
            {
                main.transform.Rotate(0, 1 * Time.fixedDeltaTime, 0);
            }
        }
        Ray ray = main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Transform objecthit = hit.transform;

            if (objecthit.tag == "Item")
            {
                objecthit.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                tic = true;
            }
            if (objecthit.tag == "BG" && tic == true)
            {
                GameObject[] cleanup;
                cleanup = GameObject.FindGameObjectsWithTag("Item");
                for (int i = 0; i < cleanup.Length; i++) // Problem with turning the color back to what it was
                {
                    cleanup[i].GetComponent<Renderer>().material.SetColor(/*cleanup[i].GetComponent<Renderer>().name, cleanup[i].GetComponent<Renderer>().material.color */ "_Color", Color.white);
                }
            }
            if (objecthit.tag == "Candle" && Input.GetMouseButtonDown(0))
            {
                if (objecthit.name == "Candle[1]")
                {
                    candle1 = Flip(candle1);
                    candle2 = Flip(candle2);
                }
                if (objecthit.name == "Candle[2]")
                {
                    candle1 = Flip(candle1);
                    candle2 = Flip(candle2);
                    candle3 = Flip(candle3);
                }
                if (objecthit.name == "Candle[3]")
                {
                    candle2 = Flip(candle2);
                    candle3 = Flip(candle3);
                    candle4 = Flip(candle4);
                }
                if (objecthit.name == "Candle[4]")
                {
                    candle3 = Flip(candle3);
                    candle4 = Flip(candle4);
                    candle5 = Flip(candle5);
                }
                if (objecthit.name == "Candle[5]")
                {
                    candle4 = Flip(candle4);
                    candle5 = Flip(candle5);
                }
                if (candle1 == true && candle2 == true && candle3 == true && candle4 == true && candle5 == true)
                {
                    Instantiate(greenKey, candles[3].transform.position, candles[3].transform.rotation);
                }
            }
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