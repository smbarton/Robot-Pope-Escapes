using UnityEngine;
using System.Collections;
using System;

public class PuzzleController : MonoBehaviour {

    public GameObject laser01, laser02;

    public SpherePuzzleCube cube01, cube02, cube03, cube04;

    private string color01, color02, color03, color04;

    public AudioSource soundSource;

    public AudioClip laserSound, greenRoomActivate;

    /*
        Have events for each cubes color change
        Add listener to each cube
        If the cube across is yellow and the cube is blue
            Enable the green laser
    */

	// Use this for initialization
	void Start () {

        Messenger.AddListener(PuzzleEvent.CUBE_COLOR_CHANGE, OnCubeColorChange);

        //laser01 = GetComponent<GameObject>();
	
	}

    private void OnCubeColorChange()
    {
        color01 = cube01.CurrentColor;
        color02 = cube02.CurrentColor;
        color03 = cube03.CurrentColor;
        color04 = cube04.CurrentColor;

        Debug.Log("Cube01: " + color01 + ", Cube02: " + color02 + ", Cube03: " + color03 + ", Cube04: " + color04);

        CreateGreenLaser();
    }
    
    // Update is called once per frame
    void Update()
    {

    }

    private void CreateGreenLaser()
    {
        if ((color01 == "Yellow" && color02 == "Blue") || (color01 == "Blue" && color02 == "Yellow"))
        {
            laser02.SetActive(true);
        }
        else
        {
            laser02.SetActive(false);
        }

        if ((color03 == "Yellow" && color04 == "Blue") || (color03 == "Blue" && color04 == "Yellow"))
        {
            laser01.SetActive(true);
        }
        else
        {
            laser01.SetActive(false);
        }

        if (laser01.activeSelf == true && laser02.activeSelf == true)
        {
            Messenger.Broadcast(PuzzleEvent.ALL_GREEN_LASERS);
            soundSource.PlayOneShot(laserSound);
            soundSource.PlayOneShot(greenRoomActivate);
        }
    }

    void OnDestroy()
    {
        Messenger.RemoveListener(PuzzleEvent.CUBE_COLOR_CHANGE, OnCubeColorChange);
    }

}
