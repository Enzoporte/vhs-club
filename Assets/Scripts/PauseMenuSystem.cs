using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenuSystem : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject optionsPanel;
    public GameObject pauseButton;

    [SerializeField] AudioClip clickSFX;
    [Range(0f, 1f)]
    [SerializeField] float clickVolume = 0.5f;

    /* 
    Reemplazar por input system en alguna otra parte, para que cuando
    se aprete esc, saque cualquier ui que haya activo
    */
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }

    }

    public void PlayClickSound()
    {
        SoundFXManager.Instance.PlaySoundFXClip(clickSFX, transform, clickVolume);
    }

    public void PauseGame()
    {
        PlayClickSound();
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void OpenOptionsPanel()
    {
        PlayClickSound();
        pauseMenu.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void ResumeGame()
    {
        PlayClickSound();
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void QuitToMainMenu()
    {
        SceneController.Instance.LoadMenuScene();
    }
}
