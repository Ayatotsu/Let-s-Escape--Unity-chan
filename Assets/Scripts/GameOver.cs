using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [Header("Class Reference")]
    public GameManager gameManager;

    [Header("Panels")]
    public GameObject objCanvas;
    public GameObject inGamePanel;
    public GameObject gameOverPanel;

    [Header("GameElements")]
    public GameObject mc;

    [Header("Obstacle Type")]
    public bool isObstacle; //this is always true and it is an obstacle attached to enemies
    public bool winning;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        objCanvas = GameObject.Find("Canvas").gameObject;
        inGamePanel = objCanvas.transform.Find("InGamePanel").gameObject;
        gameOverPanel = objCanvas.transform.Find("GameOverPanel").gameObject;
        mc = GameObject.Find("unitychan").gameObject;

    }

    private void OnCollisionEnter(Collision actor)
    {
        if (isObstacle == true && actor.gameObject.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            gameManager.txtMessage.text = "Game Over!";
            inGamePanel.gameObject.SetActive(false);
            gameOverPanel.gameObject.SetActive(true);
            mc.gameObject.SetActive(false);
            Time.timeScale = 0f;
        }
        else if (winning == true && actor.gameObject.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            gameManager.txtMessage.text = "Level Completed!";
            inGamePanel.gameObject.SetActive(false);
            gameOverPanel.gameObject.SetActive(true);
            mc.gameObject.SetActive(false);
            Time.timeScale = 0f;
        }
        if (gameManager.totalScore <= gameManager.highScore)
        {
            PlayerPrefs.SetInt("p_lastScore", gameManager.totalScore);
            PlayerPrefs.Save();
        }
        if (gameManager.totalScore > gameManager.highScore)
        {
            PlayerPrefs.SetInt("p_highScore", gameManager.totalScore);
            PlayerPrefs.Save();
        }
    }


}
