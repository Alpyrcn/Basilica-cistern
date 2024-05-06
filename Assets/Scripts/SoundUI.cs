using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundUI : MonoBehaviour
{

    private bool isPanelOpen = false;

    public Slider _musicslider, _sfxslider;
    public GameObject panel;
    public GameObject youdied;

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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPanelOpen)
            {
                ClosePanel();
            }
            else
            {
                OpenPanel();
            }
        }

        /*if (playerHealth.maxHealth <= 0)
        {
            youdied.SetActive(true);
            isPanelOpen = true;
        }
        */

        
        Cursor.visible = isPanelOpen;
        Cursor.lockState = CursorLockMode.None;
    }

    public void OpenPanel()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
        isPanelOpen = true;
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
        isPanelOpen = false;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitted");
    }
}

