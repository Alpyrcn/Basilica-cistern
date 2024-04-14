using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool gameover;
    public GameObject gameoverscreen;
    public GameObject startingText;
    public static bool isGameStarted;
    void Start()
    {
        gameover = false;
        Time.timeScale = 0;
        isGameStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameover)
        {
            Time.timeScale = 0;
            gameoverscreen.SetActive(true);
        }

        if (Input.anyKey)
        {
            isGameStarted = true;
            Time.timeScale = 1;
            Destroy(startingText);
        }
    }
}
