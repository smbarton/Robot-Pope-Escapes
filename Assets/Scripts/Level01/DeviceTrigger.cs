using UnityEngine;
using System.Collections;

public class DeviceTrigger : MonoBehaviour {

    [SerializeField]
    protected GameObject[] targets;   //List of target objects that this trigger will activate

    public bool requireKey;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //OnTriggerEnter() is called when another object enters the trigger volume.
    void OnTriggerEnter(Collider other) 
    {
        if (requireKey && Managers.Inventory.equippedItem != "key")
        {
            return;
        }

        foreach (GameObject target in targets)
        {
            target.SendMessage("Activate");
        }
    }

    //OnTriggerExit() is called when an object leaves the trigger volume.
    void OnTriggerExit(Collider other)
    {
        foreach(GameObject target in targets)
        {
            target.SendMessage("Deactivate");
        }
    }
}
