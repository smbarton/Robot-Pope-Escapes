using UnityEngine;
using System.Collections;

public class ColliderVictory : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
            Messenger.Broadcast(GameEvent.VICTORY_ACHIEVED);
    }
}
