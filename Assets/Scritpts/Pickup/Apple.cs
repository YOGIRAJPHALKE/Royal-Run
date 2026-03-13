using UnityEngine;

public class Apple : Pikup
{
    [SerializeField] float adjustChangeMoveSpeedAmount = 3f;
    LevelGenerator levelGenerator;

    private void Start() 
    {
        levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }

   protected override void OnPickup()
    {
        levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeedAmount);
        //Debug.Log("Add speed by 2");
    }
}
