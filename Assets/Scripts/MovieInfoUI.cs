using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MovieInfoUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] Image movieImage;
    [SerializeField] TMP_Text titleText;
    [SerializeField] TMP_Text descriptionText;
    [SerializeField] TMP_Text genreText;
    [SerializeField] TMP_Text ageText;
    [SerializeField] TMP_Text lengthText;
    [SerializeField] Button closeBtn;


    public void SetupMovieInfo(MovieSO data)
    {
        movieImage.sprite = data.Image;
        titleText.text = data.Title;
        descriptionText.text = data.Description;
        genreText.text = "Género: " + data.Genre;
        ageText.text = "Edad: +" + data.Age;
        lengthText.text = "Duración: " + data.Length + " min.";
    }



}
