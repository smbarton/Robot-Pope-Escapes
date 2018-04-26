using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SettingsGameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RestartLevel()
    {
        
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
