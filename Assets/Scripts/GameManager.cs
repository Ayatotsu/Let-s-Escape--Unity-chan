using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    [SerializeField] public string levelName;

    [Header("Initial Value")]
    public int totalScore;
    public int lastScore;
    public int highScore;

    [Header("InGame panel")]
    public TMP_Text txtScore;

    [Header("GameOver panel")]
    public TMP_Text currentScore;
    public TMP_Text txtLastScore;
    public TMP_Text txtHighScore;
    public TMP_Text txtMessage;


    void Update()
    {
        
        highScore = PlayerPrefs.GetInt("p_highScore");
        txtScore.text = "Score: " + totalScore.ToString();
        currentScore.text = "Score: " + totalScore.ToString();
        txtHighScore.text = "High Score: " + highScore.ToString();
        lastScore = PlayerPrefs.GetInt("p_lastScore");
        txtLastScore.text = "Last Score: " + lastScore.ToString();
    }

    
}
