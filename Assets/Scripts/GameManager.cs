using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Camera main;
    private bool tic = false;
    public Candle candles;
    public Inventory inventory;
    public NumLock numlockSafe;
    public NumLock numlockCabnit;
    public Light UVLight;
    public Material uvWallMaterial;

    void Update()
    {
        if (Input.mousePosition.x <= 100)
        {
            if (main.transform.rotation.y >= -0.1304f)
            {
                main.transform.Rotate(0, -1.5f * Time.fixedDeltaTime, 0);
            }
        }
        if (Input.mousePosition.x >= Screen.width - 100)
        {
            if (main.transform.rotation.y <= 0.1304f)
            {
                main.transform.Rotate(0, 1.5f * Time.fixedDeltaTime, 0);
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
            if (objecthit.GetComponent<Description>() != null && Input.GetMouseButtonDown(1))
            {
                Debug.Log("Description: " + objecthit.GetComponent<Description>().description);
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
            if (objecthit.tag == "Candle" && Input.GetMouseButtonDown(0) && inventory.ContainsItem("Lighter"))
            {
                candles.CandleGame(objecthit.name);
            }
            if (objecthit.tag == "Safe" && Input.GetMouseButtonDown(0))
            {
                numlockSafe.ResetLock();
            }
            if (objecthit.tag == "Cabnitpadlock" && Input.GetMouseButtonDown(0))
            {
                numlockCabnit.ResetLock();
            }
            if (objecthit.tag == "Steak" && Input.GetMouseButtonDown(0) && inventory.ContainsItem("Steak Knife"))
            {
                inventory.RemoveItem(new Item("Stek Knife", 1, "Sprite/UISteakKnife"));
                inventory.AddItem(new Item("Blue Key", 1, "Sprite/UIBlueKey"));
            }
            if (objecthit.tag == "Cabnitkey" && Input.GetMouseButtonDown(0) && inventory.ContainsItem("Blue Key"))
            {
                inventory.RemoveItem(new Item("Blue Key", 1, "Sprite/UIBlueKey"));
                inventory.AddItem(new Item("UV Light", 1, "Sprite/UIUVLight"));
            }
            if (objecthit.tag == "Glass" && Input.GetMouseButtonDown(0) && inventory.ContainsItem("Green Key"))
            {
                inventory.RemoveItem(new Item("Green Key", 1, "Sprite/UIGreenKey"));
                inventory.AddItem(new Item("Steak Knife", 1, "Sprite/UISteakKnife"));
            }
            if (objecthit.tag == "Door" && Input.GetMouseButtonDown(0) && inventory.ContainsItem("Heart Key"))
            {
                inventory.RemoveItem(new Item("Heart Key", 1, "Sprite/UIHeartKey"));
                SceneManager.LoadScene("Main Menu");
            }
        }
        if (inventory.ContainsItem("UV Light"))
        {
            UVLight.gameObject.SetActive(true);
            GameObject.Find("BackWall").GetComponent<MeshRenderer>().material = uvWallMaterial;
        }
    }

}
