using UnityEngine;

public class Apple : Pikup
{
   protected override void OnPickup()
    {
        Debug.Log("Add speed by 2");
    }
}
