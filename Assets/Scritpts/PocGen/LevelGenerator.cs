using System.Collections.Generic;
//using Unity.Cinemachine;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
   [Header ("References")]
   [Tooltip("References of a Chunk Prefab so it will render in our Game")][SerializeField] GameObject chunkPrefab;
   [Tooltip("References of a ChunkParesnt Where all chunk will be seen")][SerializeField] Transform chunkParent;
   [Tooltip("References of a Camera Controller(cinemachin Camera)")][SerializeField] CameraController cameraController;
   [Tooltip("References of a Score Manager")][SerializeField] ScoreManager scoreManager;

   [Header ("Chunk Setting")]
   [SerializeField] int startingChunkAmount = 12;
   [SerializeField] float chunkLength =10f;

   [Header ("Level Setting")]
   [Tooltip("Normal Speed of Player")][SerializeField] float moveSpeed =08f;
   [Tooltip("Minimum Speed of Player")][SerializeField] float minMoveSpeed = 2f;
   [Tooltip("Maximum Speed of Player")][SerializeField] float maxMoveSpeed = 20f;
   [Tooltip("Maximum gravity on the Game")][SerializeField] float maxGravity = -2f;
   [Tooltip("Minimum gravity on the Game")][SerializeField] float minGravity = -22f;


   List<GameObject> chunks = new List<GameObject>();

   void Start()
   {
       StartingSpawnChunk();
   }

    void Update() 
    {
        MoveChunks();
    }

    public void ChangeChunkMoveSpeed(float speedAmount)
   {
        float newMoveSpeed = moveSpeed + speedAmount;
        newMoveSpeed = Mathf.Clamp(newMoveSpeed, minMoveSpeed, maxMoveSpeed);
       // Debug.Log(speedAmount);

            if(newMoveSpeed != moveSpeed)
            {
                moveSpeed = newMoveSpeed;
                
                float newGaravityZ = Physics.gravity.z - speedAmount;

                newGaravityZ = Mathf.Clamp(newGaravityZ, minGravity, maxGravity);
                Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, newGaravityZ);
        
                cameraController.ChangeCameraFOV(speedAmount);
            }
   }

   void StartingSpawnChunk()
   {  
    for(int i=0; i<startingChunkAmount; i++)
    {
        SpawnChunk();
    }
   }

   void SpawnChunk()
   {
        float spawnPositionZ = CalculateSpawnPositionZ() ;

        Vector3 chunkSpawnPos = new Vector3(transform.position.x,transform.position.y, spawnPositionZ);
        GameObject newChunkGo =Instantiate(chunkPrefab, chunkSpawnPos, Quaternion.identity, chunkParent);

        chunks.Add(newChunkGo);

        Chunk newChunk = newChunkGo.GetComponent<Chunk>();
        newChunk.Init(this,scoreManager);
   }

   float CalculateSpawnPositionZ()
   {
     float spawnPositionZ;

        if(chunks.Count==0)
        {
            spawnPositionZ = transform.position.z;
        }
        else
        {
            spawnPositionZ = chunks[chunks.Count -1].transform.position.z + (chunkLength);
        }

        return spawnPositionZ;
   }

   void MoveChunks()
   {
    for (int i = 0; i < chunks.Count; i++)
    {
        GameObject chunk = chunks[i];
        chunk.transform.Translate(-transform.forward * (moveSpeed * Time.deltaTime));

        if(chunk.transform.position.z <= Camera.main.transform.position.z - chunkLength)
        {
            chunks.Remove(chunk);
            Destroy(chunk);
            SpawnChunk();
        }
    }

   }
  

}
