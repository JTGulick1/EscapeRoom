using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumLock : MonoBehaviour
{
    public int num1, num2, num3, num4;
    public Text number;

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
            if (num1 != 9)
            {
                num1++;
            }
            if (num1 == 9)
            {
                num1 = 0;
            }
        }
        if (name == "num2")
        {
            if (num2 != 9)
            {
                num2++;
            }
            if (num2 == 9)
            {
                num2 = 0;
            }
        }
        if (name == "num3")
        {
            if (num3 != 9)
            {
                num3++;
            }
            if (num3 == 9)
            {
                num3 = 0;
            }
        }
        if (name == "num4")
        {
            if (num4 != 9)
            {
                num4++;
            }
            if (num4 == 9)
            {
                num4 = 0;
            }
        }
        number.text = "  " + num1 + "  " + num2 + "   " + num3 + "  " + num4;
        if (num1 == 4 && num2 == 3 && num3 == 8 && num4 == 1)
        {
            //Guve Player key and destroy keypad
        }
    }
}
