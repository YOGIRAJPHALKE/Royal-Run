using UnityEngine;

public class Apple : Pikup
{
    [SerializeField] float adjustChangeMoveSpeedAmount = 3f;
    LevelGenerator levelGenerator;

    public void Init(LevelGenerator levelGenerator) 
    {
        this.levelGenerator = levelGenerator;
    }

   protected override void OnPickup()
    {
        levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeedAmount);
        //Debug.Log("Add speed by 2");
    }
}
