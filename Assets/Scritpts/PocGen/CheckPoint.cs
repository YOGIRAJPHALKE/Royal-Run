using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] float checkPointTimeExtension = 5f;
    [SerializeField] float ObstacleDecreaseTimeAmount = 0.2f;
    
    
    const string playerString = "Player";
    GameManager gameManager;
    ObstacleSpawner obstacleSpawner;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        obstacleSpawner = FindFirstObjectByType<ObstacleSpawner>();
    }

    public void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag (playerString))
        {
            gameManager.IncreaseTime(checkPointTimeExtension);
            obstacleSpawner.DecreaseObstacleSpawnTime(ObstacleDecreaseTimeAmount);
        }
        
    }
}
