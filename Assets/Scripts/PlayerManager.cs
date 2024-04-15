using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour
{
    public static bool gameover;
    public GameObject gameoverscreen;
    public GameObject startingText;
    public static bool isGameStarted;
    public static int numberOfcoins;
    public Text coin;
    void Start()
    {
        gameover = false;
        Time.timeScale = 0;
        isGameStarted = false;
        numberOfcoins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameover)
        {
            Time.timeScale = 0;
            gameoverscreen.SetActive(true);
        }
        coin.text = "" + numberOfcoins;
        if (Input.anyKey)
        {
            isGameStarted = true;
            Time.timeScale = 1;
            Destroy(startingText);
        }
    }
}
