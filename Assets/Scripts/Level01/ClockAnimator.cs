using UnityEngine;
using System;
using System.Collections;

public class ClockAnimator : MonoBehaviour {

    public Transform hours, minutes, seconds;

    private float
        hoursToDegrees = 360f / 12f,
        minutesToDegrees = 360f / 60f,
        secondsToDegrees = 360f / 60f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        DateTime time = DateTime.Now;
        hours.localRotation = Quaternion.Euler(time.Hour * -hoursToDegrees, 0f, 0f);
        minutes.localRotation = Quaternion.Euler(time.Minute * -minutesToDegrees, 0f, 0f);
        seconds.localRotation = Quaternion.Euler(time.Second * -secondsToDegrees, 0f, 0f);
	
	}
}
