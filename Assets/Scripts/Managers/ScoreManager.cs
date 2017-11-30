using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    static public int score;


    Text text;


    void Awake ()
    {
        text = GetComponent <Text> ();
    }


    void Update ()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "LastScene")
        {
            text.text = "Your Final Score:" + score;
        }
        else
        {
            text.text = "Score: " + score;
        }
    }
}
