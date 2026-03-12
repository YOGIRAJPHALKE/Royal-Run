using UnityEngine;

public class Pikup : MonoBehaviour
{
    const string playerString = "Player"; 
    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == playerString)
        {
            Debug.Log (other.gameObject.name);
        }
    }
}
