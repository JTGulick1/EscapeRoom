using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera main;
    private bool tic = false;
    public Candle candles;
    public Inventory storage;
    public NumLock numlock;

    void Update()
    {
        if (Input.mousePosition.x <= 100)
        {
            if (main.transform.rotation.y >= -0.1304f)
            {
                main.transform.Rotate(0, -1 * Time.fixedDeltaTime, 0);
            }
        }
        if (Input.mousePosition.x >= Screen.width - 100)
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
            if (objecthit.GetComponent<ItemGiver>() != null && Input.GetMouseButtonDown(0))
            {
                inventory.AddItem(objecthit.GetComponent<ItemGiver>().GetItem());

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
                candles.CandleGame(objecthit.name);
            }
            if (objecthit.tag == "Safe" && Input.GetMouseButtonDown(0))
            {
                numlock.ResetLock();
            }
        }
    }

}
