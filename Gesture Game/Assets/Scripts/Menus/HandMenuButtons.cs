using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandMenuButtons : MonoBehaviour
{
    // Code to change scenes using SceneManager
    public void Menu()
    {
        Debug.Log("Menu");
        SceneManager.LoadScene(0);
    }

    public void PlayGame()
    {
        Debug.Log("Play");
        SceneManager.LoadScene(1);
    }

    public void Tutorial()
    {
        Debug.Log("Tutorial");
        SceneManager.LoadScene(2);
    }

    public void Reset()
    {
        Debug.Log("Menu");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
