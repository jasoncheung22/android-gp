using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    // Use this for initialization
    public TimerManager time;
    public PlayerHealth playerHealth;
    public Animator anim;
    public Image black;
    [SerializeField] private string loadlevel;

    void Update()
    {
        if (time.IsTimeEnd&&playerHealth.currentHealth > 0)
        {
            //anim.SetTrigger("NextLevel");
            //SceneManager.LoadScene(loadlevel);
            StartCoroutine(Fading());
        }
    }
    IEnumerator Fading()
    {
        anim.SetTrigger("NextLevel");
        yield return new WaitUntil(()=>black.color.a == 1);
        SceneManager.LoadScene(loadlevel);
    }

}
