using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] float checkPointTimeExtension = 5f;
    const string playerString = "Player";
    GameManager gameManager;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    public void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag (playerString))
        {
            gameManager.IncreaseTime(checkPointTimeExtension);
        }
        
    }
}
