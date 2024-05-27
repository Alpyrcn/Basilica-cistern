using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundUI : MonoBehaviour
{

    private bool isPanelOpen = false;

    public Slider _musicslider, _sfxslider;

    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(_musicslider.value);
    }

    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(_sfxslider.value);
    }

    private void Update()
    {
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitted");
    }
}

