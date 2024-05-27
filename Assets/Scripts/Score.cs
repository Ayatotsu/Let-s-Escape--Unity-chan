using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [Header("Class Reference")]
    public GameManager gameManager;

    [Header("AudioElements")]
    public GameObject ScoreObject;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();


    }

    private void OnTriggerEnter(Collider actor)
    {
        if (actor.gameObject.CompareTag("Player"))
        {
            gameManager.totalScore += 100;
            Destroy(this.gameObject);
        }
    }
    
}
