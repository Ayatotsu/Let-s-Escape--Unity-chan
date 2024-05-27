using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMLoop : MonoBehaviour
{
    public AudioSource audioSrc;


    public static BGMLoop music;
    void Awake()
    {
        if (music == null)
        {
            music = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
