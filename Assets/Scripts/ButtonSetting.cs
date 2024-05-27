using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSetting : MonoBehaviour
{

    public void ButtonStart()
    {
        SceneManager.LoadSceneAsync(1);
        Time.timeScale = 1.0f;
        Debug.Log("Game Start!");

    }
    public void ButtonMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
        Debug.Log("Back To Main Menu");
        Time.timeScale = 1.0f;
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game Quit!");
    }
}
