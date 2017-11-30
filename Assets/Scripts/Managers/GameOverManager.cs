using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject PauseBtn;
    Animator anim;
    public TimerManager time;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");
            PauseBtn.SetActive(false);
        }
        if (scene.name == "L03" && time.IsL03End)
        {
            SceneManager.LoadScene("LastScene");
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ScoreManager.score = 0;
    }
}
