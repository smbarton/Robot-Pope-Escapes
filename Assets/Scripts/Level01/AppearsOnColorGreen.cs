using UnityEngine;
using System.Collections;
using System;

public class AppearsOnColorGreen : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Messenger.AddListener(GameEvent.COLOR_GREEN, OnColorGreen);

        gameObject.SetActive(false);
	
	}

    private void OnColorGreen()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
