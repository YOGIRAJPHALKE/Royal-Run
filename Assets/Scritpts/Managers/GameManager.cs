using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] PlayerController playerController;
    [SerializeField] float startTime = 5f;
    
    bool gameOver = false;
    float timeLeft;


    void Start()
    {
        timeLeft = startTime;
    }

    void Update()
    {
        DecreaseTime();
    }

    void GameOver()
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
            GameOver();
        }
    }
}
