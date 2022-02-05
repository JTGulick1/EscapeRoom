using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{


    public float fadeInSpeed = 0.4f;
    public GameObject blackFadeIn;

    public AudioSource monologueSound;

    public GameObject lossCanvas;
    public float gameTime = 800.0f;


    private void Awake()
    {
        blackFadeIn.SetActive(true);
        StartCoroutine(FadeIn());
        StartCoroutine(Monologue());
    }

    // Update is called once per frame
    void Update()
    {
        if (gameTime > 0)
        {
            gameTime -= Time.deltaTime;
        }
        else if (gameTime <= 0)
        {
            lossCanvas.SetActive(true);
            lossCanvas.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
        }
    }

    IEnumerator FadeIn()
    {
        Image blackFadeImage = blackFadeIn.GetComponent<Image>();
        while (blackFadeImage.color.a > 0)
        {
            blackFadeImage.color = new Color(blackFadeImage.color.r, blackFadeImage.color.g, blackFadeImage.color.b, blackFadeImage.color.a - (Time.deltaTime * fadeInSpeed));
            yield return new WaitForEndOfFrame();
        }
        yield return null;
    }

    IEnumerator Monologue()
    {
        yield return new WaitForSeconds(5);
        monologueSound.Play();
        yield return new WaitForSeconds(35);

        //start game logic stuffs
        monologueSound.Stop();
        GameObject.Find("Television").GetComponent<Television>().timerActive = true;
        GameObject.Find("tv light").SetActive(false);
        GameObject.Find("TV images").GetComponent<Slideshow>().hideEven = false;
        GameObject.Find("TV images").SetActive(false);
        GameObject.Find("camera dot").SetActive(false);
    }
}
