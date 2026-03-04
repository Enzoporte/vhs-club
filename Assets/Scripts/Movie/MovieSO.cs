using UnityEngine;

[CreateAssetMenu(fileName = "MovieSO", menuName = "Scriptable Objects/MovieSO")]
public class MovieSO : ScriptableObject
{
    [SerializeField] string title;
    [TextArea(15, 20)]
    [SerializeField] string description;
    // Más de un genero de pelis?
    [SerializeField] string genre;
    [SerializeField] int age;
    [SerializeField] int length;
    [SerializeField] Sprite image;


    public string Title => title;
    public string Description => description;
    public string Genre => genre;
    public int Age => age;
    public int Length => length;
    public Sprite Image => image;



}
