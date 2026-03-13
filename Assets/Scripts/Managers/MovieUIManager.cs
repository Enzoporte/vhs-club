using System;
using UnityEngine;

public class MovieUIManager : MonoBehaviour
{
    [Header("UI Reference")]
    public GameObject movieInfoPanel;
    public MovieInfoUI movieInfo;

    [Header("Sounds")]
    [SerializeField] private AudioClip kachingSFX;
    [Range(0f, 1f)]
    [SerializeField] private float kachingVolume;
    [SerializeField] private AudioClip openMovieSFX;
    [Range(0f, 1f)]
    [SerializeField] private float openMovieVolume;


    private static MovieUIManager instance;
    public static MovieUIManager Instance
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

    }

    private static void SetupInstance()
    {
        instance = FindFirstObjectByType<MovieUIManager>();
        if (instance == null)
        {
            GameObject gameObj = new GameObject();
            gameObj.name = "MovieUIManager";
            instance = gameObj.AddComponent<MovieUIManager>();
            DontDestroyOnLoad(gameObj);
        }
    }

    void Start()
    {
        ShelfManager.Instance.OnMovieSelected.AddListener(HandleMovieSelect);
    }

    void HandleMovieSelect(MovieView movie)
    {
        SoundFXManager.Instance.PlaySoundFXClip(openMovieSFX, transform, openMovieVolume);
        Show(movie.MovieData);
    }


    public void Show(MovieSO data)
    {
        movieInfo.SetupMovieInfo(data);
        movieInfoPanel.gameObject.SetActive(true);
    }

    public void Hide()
    {
        movieInfoPanel.gameObject.SetActive(false);
    }

    public void Deliver()
    {
        SoundFXManager.Instance.PlaySoundFXClip(kachingSFX, transform, kachingVolume);
        movieInfoPanel.gameObject.SetActive(false);
    }

    void OnDisable()
    {
        ShelfManager.Instance.OnMovieSelected.RemoveListener(HandleMovieSelect);
    }
}
