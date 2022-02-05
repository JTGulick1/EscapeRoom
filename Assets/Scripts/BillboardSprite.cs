using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//make a sprite face main camera
public class BillboardSprite : MonoBehaviour
{
    private void Update()
    {
        transform.LookAt(Camera.main.transform.position);
    }
}
