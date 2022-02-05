using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Camera main;
    void FixedUpdate()
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
        /*RaycastHit hit;
        Ray ray = main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objecthit = hit.transform;

            if (objecthit.tag == "Item")
            {
                Debug.Log("yep");
            }
        }*/
    }
}
