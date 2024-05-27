using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
public class Timer : MonoBehaviour
{
    public GameManager gameManager;

    public float timeRemaining = 122;
    public bool timeIsRunning = true;

    [Header("References")]
    public TextMeshProUGUI timeText;

    [Header("Panels")]
    public GameObject objCanvas;
    public GameObject inGamePanel;
    public GameObject gameOverPanel;

    [Header("GameElements")]
    public GameObject mc;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        objCanvas = GameObject.Find("Canvas").gameObject;
        inGamePanel = objCanvas.transform.Find("InGamePanel").gameObject;
        gameOverPanel = objCanvas.transform.Find("GameOverPanel").gameObject;
        mc = GameObject.Find("unitychan").gameObject;

        timeIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining <= 32f) 
        {
            timeText.color = Color.yellow;
        }
        if (timeRemaining <= 12f) 
        {
            timeText.color = Color.red;
        }

        if (timeRemaining <= 1.2f)
        {
            GameOver();
            timeIsRunning = false;
            Time.timeScale = 0f;

        }

        if (timeIsRunning)
        {

            if (timeRemaining <= 122)
            {
                timeRemaining -= Time.deltaTime;
                TimeDisplay(timeRemaining);
            }

        }
    }


    void TimeDisplay(float timeToDisplay)
    {
        timeToDisplay -= 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    public void GameOver()
    {
        if (!timeIsRunning)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            gameManager.txtMessage.text = "Game Over!";
            inGamePanel.gameObject.SetActive(false);
            gameOverPanel.gameObject.SetActive(true);
            mc.gameObject.SetActive(false);
            Time.timeScale = 0f;
        }
    }
}
