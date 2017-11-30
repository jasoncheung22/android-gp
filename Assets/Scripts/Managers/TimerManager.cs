using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour {
    public float startTime;
    public PlayerHealth playerhealth;
    Text timeText;
    public bool IsTimeEnd;
    public bool IsL03End = false;
    // Use this for initialization
    void Awake()
    {
        timeText = GetComponent<Text>();
        IsTimeEnd = false;
    }
    // Update is called once per frame
    void Update () {
        Scene scene = SceneManager.GetActiveScene();
        if (!IsTimeEnd)
        {
            startTime -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(startTime / 60F);
            int seconds = Mathf.FloorToInt(startTime - minutes * 60);
            timeText.text = "Time: " + seconds;
            if (seconds == 0 && playerhealth.currentHealth > 0 && scene.name == "L03")
            {
                IsL03End = true;
                IsTimeEnd = true;
            }
            if (seconds == 0 || playerhealth.currentHealth <= 0)
            {
                    IsTimeEnd = true;
                
            }
        }
        else
        {
            timeText.text = "Ended";
        }
    }
}
