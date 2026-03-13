using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] List<GameObject> canvasList;
    [SerializeField] GameObject libraryCanvas;

    public void ShowLibrary()
    {
        HideAll();
        libraryCanvas.SetActive(true);
    }

    private void HideAll()
    {
        if (canvasList == null) return;

        foreach (GameObject canvas in canvasList)
        {
            canvas.SetActive(false);    
        }        
    }


}
