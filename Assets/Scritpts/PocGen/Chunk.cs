using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    List <int> availableLanes = new List<int>{0,1,2};
    [SerializeField] GameObject fencePrefab;
    [SerializeField] GameObject coinePrefab;
    [SerializeField] GameObject applePrefab;
    [SerializeField] float[] lanes = {-2.5f, 0f, 2.5f};
    [SerializeField] float appleSpawnChance = 0.3f;
    [SerializeField] float coineSpawnChance = 0.5f;
    [SerializeField] float coineSeparationLength = 2f;

    

    void Start()
    {
        spawnPrefab();
        SpawnApple();
        Spawncoine();
    }

    void spawnPrefab()
    {   
        int fencesToSpawn =Random.Range(0,lanes.Length);
        for(int i=0; i<fencesToSpawn; i++)
        {
            if(availableLanes.Count <=0)break;

            int selectedLane = SelectLane();

           // int randomPrefabIndex = Random.Range(0,lanse.Length);
            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate (fencePrefab,spawnPosition,Quaternion.identity, this.transform);
        
        }
    }

    void SpawnApple()
    {
        if(Random.value > appleSpawnChance || availableLanes.Count <= 0) return;

        int selectedLane = SelectLane();

        Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
        Instantiate (applePrefab,spawnPosition,Quaternion.identity, this.transform);    
    }

    void Spawncoine()
    {
        if(Random.value > coineSpawnChance || availableLanes.Count <=0) return;

        int selectedLane = SelectLane();

        int maxCoinesToSpawn = 6;
        int coineToSpawn = Random.Range(1,maxCoinesToSpawn);

        float topOfChunkZPos =transform.position.z + (coineSeparationLength * 2f);

        for(int i = 0; i<coineToSpawn; i++)
        {
            float spawnPositionZ = topOfChunkZPos - (i * coineSeparationLength);
            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, spawnPositionZ);
            Instantiate (coinePrefab,spawnPosition,Quaternion.identity, this.transform);    
        }
    }
    
    int SelectLane()
    {
        int randomLaneIndex = Random.Range(0,availableLanes.Count);
        int selectedLane = availableLanes[randomLaneIndex];
        availableLanes.RemoveAt(randomLaneIndex);
        return selectedLane;

    }
}
