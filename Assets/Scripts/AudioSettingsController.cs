using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettingsController : MonoBehaviour
{
    public AudioMixer mixer; 
    public Slider musicSlider; 
    public Slider sfxSlider;

    void Start()
    {
        float musicValue;
        float sfxValue;

        mixer.GetFloat("MusicVolume", out musicValue);
        mixer.GetFloat("SFXVolume", out sfxValue);

        musicSlider.value = Mathf.Pow(10, musicValue / 20);
        sfxSlider.value = Mathf.Pow(10, sfxValue / 20);
    }

    public void SetMusicVolume(float value) 
    { 
        mixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20); 
    }
    public void SetSFXVolume(float value) 
    { 
        mixer.SetFloat("SFXVolume", Mathf.Log10(value) * 20); 
    }
}
