using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private static SceneController instance;
    public static SceneController Instance
    {
        get
        {
            if (instance == null)
            {
                SetupInstance();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
    }

    private static void SetupInstance()
    {
        instance = FindFirstObjectByType<SceneController>();
        if (instance == null)
        {
            GameObject gameObj = new GameObject();
<<<<<<< Updated upstream
            gameObj.name = "SceneController";
=======
            gameObj.name = "ShelfManager";
>>>>>>> Stashed changes
            instance = gameObj.AddComponent<SceneController>();
            DontDestroyOnLoad(gameObj);
        }
    }
<<<<<<< Updated upstream
    
    public void LoadGameplayScene()
=======

    public void LoadGameScene()
>>>>>>> Stashed changes
    {
        SceneManager.LoadScene(1);
    }

<<<<<<< Updated upstream
    public void LoadMainMenu()
=======
    public void LoadMenuScene()
>>>>>>> Stashed changes
    {
        SceneManager.LoadScene(0);
    }

<<<<<<< Updated upstream
    public void Quit()
=======
    public void QuitGame()
>>>>>>> Stashed changes
    {
        Application.Quit();
    }
}
