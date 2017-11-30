using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreArrangement : MonoBehaviour {

    // Use this for initialization
    Text text;


    void Awake()
    {
        text = GetComponent<Text>();
    }


    // Update is called once per frame
    void Update () {
        if (ScoreManager.score <= 100)
            text.text = "You are Human";
        else if (ScoreManager.score > 100 && ScoreManager.score <= 300)
            text.text = "You are Hero";
        else if (ScoreManager.score > 300 && ScoreManager.score <= 400)
            text.text = "You are God";
        else
            text.text = "You are Legendary";
    }
}
