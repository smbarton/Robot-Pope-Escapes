using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour 
{
    
    //other isreference to the trigger collider that enters this trigger collider
    void OnTriggerEnter(Collider other)
    {

       //Debug.Log(other.name);      //Displays in the console the name of the collider setting off the trigger
        
        if (other.tag == "Boundary")
        {
            return;
        }


        if (other.tag == "Player")
        {
            Destroy(other.gameObject);
            Messenger.Broadcast(GameEvent.PLAYER_DIED);
            Destroy(gameObject);
        }

    }
}
