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

    public GameObject lossCanvas;

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

    bool MouseOverTV()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform.gameObject.name == "Television" || hit.transform.gameObject.name == "TV images")
            {
                return true;
            }
            else
            {
                Debug.Log("TV mouse check: hit " + hit.transform.gameObject.name);
            }
        }
        return false;
    }

    IEnumerator CheckSequence()
    {
        //check in on the player

        //camera windup
        cameraBeep.Play();
        cameraBlink.SetActive(true);

        //enable TV images
        tvObject.transform.GetChild(0).gameObject.SetActive(true);
        tvLight.SetActive(true);

        //wait for camera beep to end
        yield return new WaitForSeconds(4.626f);

        
        cameraBeep.Stop();

        //check if player is pointing over TV
        if (MouseOverTV() == false)
        {
            //lose game logic
            Debug.Log("player was caught not watching TV!");
            lossCanvas.SetActive(true);
            lossCanvas.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
            timerActive = false;
        }
        else
        {
            Debug.Log("player passed TV check");
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
