using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Television : MonoBehaviour
{
    public float timerValue = 60;
    float timer;
    public bool timerActive = false;

    public GameObject tvObject;
    public GameObject cameraBlink;
    public GameObject tvLight;
    public AudioSource cameraBeep;

    private void Awake()
    {
        timer = timerValue;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (timerActive)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0 && timerActive)
        {
            timerActive = false;
            StartCoroutine(CheckSequence());
        }
    }

    IEnumerator CheckSequence()
    {
        //check in on the player

        //camera windup
        cameraBeep.Play();
        cameraBlink.SetActive(true);
        yield return new WaitForSeconds(4.626f);

        //enable TV images
        cameraBeep.Stop();
        tvObject.transform.GetChild(0).gameObject.SetActive(true);
        tvLight.SetActive(true);

        //check if player is pointing over TV
        bool pass = false;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Transform objecthit = hit.transform;

            if (objecthit.name == "Television")
            {
                pass = true;
            }
        }

        if (!pass)
        {
            //lose game logic
        }

        yield return new WaitForSeconds(5);

        //turn off tv
        tvObject.transform.GetChild(0).gameObject.SetActive(false);
        tvLight.SetActive(false);
        cameraBlink.SetActive(false);

        //reset the timer
        timer = timerValue;
        timerActive = true;
    }

    
}
