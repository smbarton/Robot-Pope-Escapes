using UnityEngine;
using System.Collections;
using System;

public class DisplaysWithGlasses : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Messenger.AddListener(GameEvent.USING_GLASSES, OnUsingGlasses);
        Messenger.AddListener(GameEvent.EXITING_ITEM, OnGlassesExit);

	}

    private void OnGlassesExit()
    {
        gameObject.SetActive(false);
    }

    private void OnUsingGlasses()
    {
        gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update () {
	
	}
}
