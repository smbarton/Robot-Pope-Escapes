using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour {

    private float timeLeft = 10;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        timeLeft -= Time.deltaTime;

        if (timeLeft < 0)
        {
            Debug.Log("Quitting Application");
            Application.Quit();

        }

    }


}
