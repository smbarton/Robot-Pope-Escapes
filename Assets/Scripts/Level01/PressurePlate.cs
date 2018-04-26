using UnityEngine;
using System.Collections;

public class PressurePlate : DeviceTrigger {
    
    //OnTriggerExit() is called when an object leaves the trigger volume.
    void OnTriggerExit(Collider other)
    {
        Destroy(this.gameObject);   //Destroy the gameobject this script is attached to
    }
}
