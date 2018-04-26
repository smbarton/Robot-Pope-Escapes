using UnityEngine;
using System.Collections;
using System;

public class Scroll : MonoBehaviour {

    public float speed = 0.5f;

	// Use this for initialization
	void Start () {

        Messenger.AddListener(GameEvent.SPAWNING_MARS, OnSpawningMars);
        Messenger.AddListener(GameEvent.VICTORY_ACHIEVED, OnVictoryAchieved);
	
	}

    // Update is called once per frame
    void Update () {

        Vector2 offset = new Vector2(0, Time.time * speed);

        GetComponent<Renderer>().material.mainTextureOffset = offset;


	
	}

    public void SetScrollSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    private void OnVictoryAchieved()
    {
        speed = 0f;
    }

    private void OnSpawningMars()
    {
        speed = 0.1f;
    }
}
