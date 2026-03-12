using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
   void OnCollisionEnter(Collision other) 
   {
    Debug.Log("Collided with: " + other.gameObject.name);
   }
}
