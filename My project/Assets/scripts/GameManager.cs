using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{   
    static GameManager instance;
    public Text timeScore;
    public GameObject GameOverUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        Time.timeScale = 1f;
    }
    private void Awake()
    {
        if (instance != null) {
            Destroy(gameObject);
        }
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        timeScore.text = Time.timeSinceLevelLoad.ToString("00");

    }

    public void RestartGame()
    {
         Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }

    public static void GameOver(bool dead)
    {
        if (dead)
        {
            instance.GameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
