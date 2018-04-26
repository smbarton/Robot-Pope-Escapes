using UnityEngine;
using System.Collections;

public class DoorSwitch : MonoBehaviour {

    public Door door;

    public AudioSource unlockSound;

    private bool _isSwitchedOn;

	// Use this for initialization
	void Start () {

        _isSwitchedOn = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Operate()
    {
        if (_isSwitchedOn == false)
        {
            unlockSound.Play();

            door.SwitchOpen = true;
            _isSwitchedOn = true;
        }

    }
}
