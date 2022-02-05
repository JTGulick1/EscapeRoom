using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slideshow : MonoBehaviour
{
    public List<Material> slides = new List<Material>();

    public float timeBetweenImages = 0.6f;
    private float timer;

    private int index = 0;

    public bool hideEven = true;

    private void Awake()
    {
        timer = timeBetweenImages;
    }

    public void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            if (index < slides.Count - 1)
            {
                index++;
            }
            else
            {
                index = 0;
            }

            if (index % 2 == 0 && hideEven)
            {
                timer = timeBetweenImages;
            }
            else
            {
                GetComponent<MeshRenderer>().material = slides[index];
                timer = timeBetweenImages;
            }
        }
    }
}
