    using System.Collections;
    using UnityEngine;



    public class ObstacleSpawner : MonoBehaviour
    {
        [SerializeField] GameObject[] obstaclePrefabs;
        [SerializeField] float obstacleSpawnedTime = 2f;
        [SerializeField] Transform obstacleParent;

        [SerializeField] float spawnWidth = 4f;
        
        void Start()
        {
        StartCoroutine(SpawnedObstaclesRoutine());
        }

        IEnumerator SpawnedObstaclesRoutine()
        {
            while (true)
            {
                GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0,obstaclePrefabs.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnWidth,spawnWidth),transform.position.y,transform.position.z);
                yield return new WaitForSeconds(obstacleSpawnedTime);
                Instantiate ( obstaclePrefab, spawnPosition, Random.rotation,obstacleParent); 
                
            }
            
        }

        
    }
