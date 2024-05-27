using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public static float scoreCount;
    public Text hiScoreText;
    public PlayerController playercont;
    public static int hiScoreCount;
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            hiScoreCount = PlayerPrefs.GetInt("HiScore");
        }
        scoreCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if(scoreCount > hiScoreCount)
        {
            hiScoreCount = (int)scoreCount;
            PlayerPrefs.SetFloat("HiScore", hiScoreCount);
        }
        
        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        hiScoreText.text = "Hi-Score:" + hiScoreCount;
        AddScore();
    }

    public void AddScore()
    {
        scoreCount += /*playercont.forwardSpeed*/ 2 * Time.deltaTime; 
    }


}
