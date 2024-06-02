using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Event : MonoBehaviour
{
    public void RetryLevel()
    {
        SceneManager.LoadScene("Runner");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
