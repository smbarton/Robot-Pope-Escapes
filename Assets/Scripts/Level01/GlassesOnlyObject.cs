using UnityEngine;
using System.Collections;
using System;

public class GlassesOnlyObject : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Messenger.AddListener(GameEvent.USING_GLASSES, OnUsingGlasses);
        Messenger.AddListener(GameEvent.EXITING_ITEM, OnExitGlasses);

        GetComponent<Renderer>().enabled = false;
	
	}



    private void OnUsingGlasses()
    {
        GetComponent<Renderer>().enabled = true;
    }

    private void OnExitGlasses()
    {
        GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.USING_GLASSES, OnUsingGlasses);
        Messenger.RemoveListener(GameEvent.EXITING_ITEM, OnExitGlasses);
    }

}
