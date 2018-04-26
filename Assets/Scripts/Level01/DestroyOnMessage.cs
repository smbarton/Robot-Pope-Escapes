using UnityEngine;
using System.Collections;
using System;

public class DestroyOnMessage : MonoBehaviour {



	// Use this for initialization
	void Start () {

        Messenger.AddListener(GameEvent.COLOR_GREEN, OnColorGreen);

	}

    private void OnColorGreen()
    {
        Messenger.RemoveListener(GameEvent.COLOR_GREEN, OnColorGreen);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.COLOR_GREEN, OnColorGreen);
    }
}
