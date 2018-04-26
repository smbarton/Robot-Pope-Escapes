using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GivesItem : MonoBehaviour {

    private bool _hasGlasses;


    private bool _alreadyTalkedTo;

    // Use this for initialization
    void Start () {

        _hasGlasses = true;
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Operate()
    {


        if (_hasGlasses == true)
        {
            Debug.Log("Floaty says: Here is glasses.");
            Messenger.Broadcast(GameEvent.GLASSES_TAKEN);
            
            _hasGlasses = false;

        }
        else
        {
            Debug.Log("Floaty says: I have no glasses.");
        }
    }


}
