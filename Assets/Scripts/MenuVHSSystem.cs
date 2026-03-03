using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuVHSSystem : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject mainMenu;

    public AudioSource audioSource;

    public AudioClip moneda;

    public void PlayClickSound()
    {
        audioSource.PlayOneShot(moneda);
    }

    public void OpenOptionsPanel()
    {
        PlayClickSound();
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void OpenMainMenuPanel()
    {
        PlayClickSound();
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void QuitGame()
    {
        PlayClickSound();
        Debug.Log("Saliendo del juego");
        Application.Quit();
    }

    public void PlayGame()
    {
        PlayClickSound();
        SceneManager.LoadScene("1raEscena");
    }
}
