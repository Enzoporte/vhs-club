using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenuSystem : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject optionsPanel;
    public GameObject pauseButton;
    public AudioSource audioSource;

    public AudioClip moneda;

    void Update()
    {
        PauseMenuByKey();
    }

    public void PauseMenuByKey()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            pauseButton.SetActive(false);
        }
    }

    public void PlayClickSound()
    {
        audioSource.PlayOneShot(moneda);
    }

    public void PauseGame()
    {
        PlayClickSound();
        Time.timeScale = 0;
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void OpenOptionsPanel()
    {
        PlayClickSound();
        Time.timeScale = 0;
        pauseMenu.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void BackToMenu()
    {
        PlayClickSound();
        Time.timeScale = 0; 
        pauseMenu.SetActive(true);
        optionsPanel.SetActive(false);
    }

    public void ResumeGame()
    {
        PlayClickSound();
        Time.timeScale = 1;
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void QuitToMainMenu()
    {
        PlayClickSound();
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Saving Game");
    }
}
