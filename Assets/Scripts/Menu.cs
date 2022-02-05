using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public GameObject menu;
    public GameObject credits;
    private void Start()
    {
        menu.SetActive(true);
        credits.SetActive(false);
    }
    public void Play()
    {
        SceneManager.LoadScene("World");
    }
    public void Credits()
    {
        menu.SetActive(false);
        credits.SetActive(true);
    }
    public void MainMenu()
    {
        menu.SetActive(true);
        credits.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
