using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShelfManager : MonoBehaviour
{

    [SerializeField] private MovieView selectedMovie;
    [SerializeReference] private MovieView hoveredMovie; // Display small movie title in UI?
    [HideInInspector] public UnityEvent<MovieView> OnMovieSelected;

    [Header("Grid Settings")]
    public List<GameObject> shelfSlots;

    public List<MovieView> movies;

    [Header("Sounds")]
    [SerializeField] private AudioClip clickSFX;
    [Range(0f, 1f)]
    [SerializeField] private float clickVolume;

    bool isCrossing = false;
    private float swapDistanceThreshold = 1f; // Threshold for snapping to grid position


    private static ShelfManager instance;
    public static ShelfManager Instance
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

        movies = new List<MovieView>();
    }

    private static void SetupInstance()
    {
        instance = FindFirstObjectByType<ShelfManager>();
        if (instance == null)
        {
            GameObject gameObj = new GameObject();
            gameObj.name = "ShelfManager";
            instance = gameObj.AddComponent<ShelfManager>();
            DontDestroyOnLoad(gameObj);
        }
    }

    void Start()
    {
        foreach (GameObject slot in shelfSlots)
        {
            MovieView movie = slot.GetComponentInChildren<MovieView>();
            if (movie != null)
                movies.Add(movie);
        }

        int movieCount = 0;

        foreach (MovieView movie in movies)
        {
            movie.PointerEnterEvent.AddListener(MoviePointerEnter);
            movie.PointerExitEvent.AddListener(MoviePointerExit);
            movie.BeginDragEvent.AddListener(BeginDrag);
            movie.EndDragEvent.AddListener(EndDrag);
            movie.SelectEvent.AddListener(HandleMovieClicked);
            movie.name = movieCount.ToString();
            movieCount++;
        }
    }


    private void HandleMovieClicked(MovieView movie)
    {
        OnMovieSelected?.Invoke(movie);
    }

    private void BeginDrag(MovieView movie)
    {
        //SoundFXManager.Instance.PlaySoundFXClip(clickSFX, transform, clickVolume);
        selectedMovie = movie;
    }

    void EndDrag(MovieView movie)
    {
        //SoundFXManager.Instance.PlaySoundFXClip(clickSFX, transform, clickVolume);
        selectedMovie = null;
    }

    void MoviePointerEnter(MovieView movie)
    {
        hoveredMovie = movie;
    }

    void MoviePointerExit(MovieView movie)
    {
        hoveredMovie = null;
    }


    void Update()
    {
        if (selectedMovie == null || selectedMovie.gameObject == null)
            return;

        if (isCrossing)
            return;

        MovieView nearestMovie = FindNearestMovie();
        GameObject nearestSlot = FindNearestSlot();

        if (nearestMovie != null)
        {
            SwapMovies(nearestMovie);
        }
        else if (nearestSlot != selectedMovie.transform.parent.gameObject)
        {
            selectedMovie.transform.SetParent(nearestSlot.transform);
        }
    }

    private GameObject FindNearestSlot()
    {
        GameObject nearestSlot = selectedMovie.transform.parent.gameObject;
        float nearestDistance = swapDistanceThreshold;

        foreach (GameObject slot in shelfSlots)
        {
            if (slot == null || slot.gameObject == null)
                continue;

            float distance = Vector3.Distance(selectedMovie.transform.position, slot.transform.position);

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestSlot = slot;
            }
        }

        return nearestSlot;
    }

    MovieView FindNearestMovie()
    {
        MovieView nearestMovie = null;
        float nearestDistance = swapDistanceThreshold;

        foreach (MovieView movie in movies)
        {
            if (movie == null || movie == selectedMovie || movie.gameObject == null)
                continue;

            float distance = Vector3.Distance(selectedMovie.transform.position, movie.transform.position);

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestMovie = movie;
            }
        }

        return nearestMovie;
    }

    void SwapMovies(MovieView neighbourMovie)
    {
        isCrossing = true;

        Transform selectedParent = selectedMovie.transform.parent;
        Transform neighborParent = neighbourMovie.transform.parent;

        int selectedIndex = selectedMovie.transform.GetSiblingIndex();
        int neighborIndex = neighbourMovie.transform.GetSiblingIndex();

        // Swap the sibling indices to swap positions in the grid
        selectedMovie.transform.SetSiblingIndex(neighborIndex);
        neighbourMovie.transform.SetSiblingIndex(selectedIndex);

        selectedMovie.transform.SetParent(neighborParent);
        neighbourMovie.transform.SetParent(selectedParent);

        // Reset local positions
        RectTransform selectedRect = selectedMovie.GetComponent<RectTransform>();
        RectTransform neighbourRect = neighbourMovie.GetComponent<RectTransform>();

        if (selectedRect != null)
            selectedRect.localPosition = Vector3.zero;

        if (neighbourRect != null)
            neighbourRect.localPosition = Vector3.zero;

        isCrossing = false;
    }

}