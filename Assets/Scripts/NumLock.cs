using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumLock : MonoBehaviour
{
    public int num1, num2, num3, num4;
    public Text number;
    public string whatLock;

    public void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void ResetLock()
    {
        this.gameObject.SetActive(true);
        number.text = "  " + num1 + "  " + num2 + "   " + num3 + "  " + num4;

    }
    public void HideLock()
    {
        this.gameObject.SetActive(false);
    }
    public void LockChange(string name)
    {
        if (name == "num1")
        {
            if (num1 != 10)
            {
                num1++;
            }
            if (num1 == 10)
            {
                num1 = 0;
            }
        }
        if (name == "num2")
        {
            if (num2 != 10)
            {
                num2++;
            }
            if (num2 == 10)
            {
                num2 = 0;
            }
        }
        if (name == "num3")
        {
            if (num3 != 10)
            {
                num3++;
            }
            if (num3 == 10)
            {
                num3 = 0;
            }
        }
        if (name == "num4")
        {
            if (num4 != 10)
            {
                num4++;
            }
            if (num4 == 10)
            {
                num4 = 0;
            }
        }
        number.text = "  " + num1 + "  " + num2 + "   " + num3 + "  " + num4;
        CheckLock();
    }
    public void CheckLock()
    {
        if (whatLock == "Safe")
        {
            if (num1 == 4 && num2 == 3 && num3 == 8 && num4 == 1)
            {
                GameObject.Find("Gamemanager").GetComponent<GameManager>().inventory.AddItem(new Item("Heart Key", 1, "Sprite/UIHeartKey"));
                GameObject.FindGameObjectWithTag("Safe").SetActive(false);
                GameObject.FindGameObjectWithTag("SafeOpen").GetComponent<MeshRenderer>().enabled = true;
            }
        }
        if (whatLock == "Cabnit")
        {
            if (num1 == 9 && num2 == 3 && num3 == 9 && num4 == 5)
            {
                GameObject.Find("Gamemanager").GetComponent<GameManager>().inventory.AddItem(new Item("Lighter", 1, "Sprite/UILighter"));
                GameObject.FindGameObjectWithTag("Cabnitpadlock").SetActive(false);
                GameObject.FindGameObjectWithTag("Cabnitkey").GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
}
