using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuVHSSystem : MonoBehaviour
{
    [SerializeField] private GameObject activeUI;
    [SerializeField] private GameObject menuUI;

    [SerializeField] AudioClip clickSFX;
    [Range(0f, 1f)]
    [SerializeField] float clickVolume = 0.5f;


    public void ToggleMenuUI()
    {
        SoundFXManager.Instance.PlaySoundFXClip(clickSFX, transform, clickVolume);
        menuUI?.SetActive(!menuUI.activeSelf);
        activeUI?.SetActive(!activeUI.activeSelf);
    }

}
