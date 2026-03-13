using UnityEngine;

public class Coin : Pikup
{
    protected override void OnPickup()
    {
        Debug.Log("Add 100 Points");
    }
}
