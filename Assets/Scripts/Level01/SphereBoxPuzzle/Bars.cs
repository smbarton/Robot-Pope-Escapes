using UnityEngine;
using System.Collections;
using System;

public class Bars : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Messenger.AddListener(PuzzleEvent.ALL_GREEN_LASERS, OnAllGreenLasers);
	
	}

    private void OnAllGreenLasers()
    {
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update () {
	
	}

    private void OnDestroy()
    {
        Messenger.RemoveListener(PuzzleEvent.ALL_GREEN_LASERS, OnAllGreenLasers);
    }
}
