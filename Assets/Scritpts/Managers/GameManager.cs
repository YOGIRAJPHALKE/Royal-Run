using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] PlayerController playerController;
    [SerializeField] float startTime = 5f;
    
    float timeLeft;
    bool gameOver = false;

    public bool GameOver
    {
        get{return gameOver;}
    }

    void Start()
    {
        timeLeft = startTime;
    }

    void Update()
    {
        DecreaseTime();
        HandleRestart();
    }

    public void IncreaseTime(float amount)
    {
        timeLeft += amount;
    }

    void PlayerGameOver()
    {
        gameOver = true;
        playerController.enabled = false;
        gameOverText.SetActive(true);
        Time.timeScale = .1f;

    }

    void DecreaseTime()
    {
        if (gameOver) return;
        
        timeLeft -= Time.deltaTime;
        timeText.text = timeLeft.ToString("F1");
        if(timeLeft <= 0f)
        {
            PlayerGameOver();
        }
    }

    void HandleRestart()
{
    if ((timeLeft <= 0f) &&(Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Space)))
    {
        RestartGame();
    }
}

void RestartGame()
{
    Time.timeScale = 1f; //(reset slow motion)
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}
}
