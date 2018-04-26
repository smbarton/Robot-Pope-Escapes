using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class LoadRocketLevel : MonoBehaviour {

    private bool _isEnabled;

	// Use this for initialization
	void Start () {


        Messenger.AddListener(PuzzleEvent.ALL_GREEN_LASERS, OnLasersGreen);
        gameObject.SetActive(false);

    }

    private void OnLasersGreen()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            SceneManager.LoadScene(2);
        }
    }
}
