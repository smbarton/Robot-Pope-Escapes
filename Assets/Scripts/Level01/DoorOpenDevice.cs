using UnityEngine;
using System.Collections;

public class DoorOpenDevice : MonoBehaviour {

    [SerializeField]
    private Vector3 dPos;   //the position to offset to when the door opens

   //public bool staysOpen;

    private bool _open; //boolean to keep track of the open state door

    public AudioSource slidingDoorSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //public void Activate()
    //{
    //    if (!_open)
    //    {
    //        Vector3 pos = transform.position + dPos;
    //        transform.position = pos;
    //        _open = true;
    //    }
    //}
    //public void Deactivate()
    //{
    //    if (_open)
    //    {
    //        Vector3 pos = transform.position - dPos;
    //        transform.position = pos;
    //        _open = false;
    //    }
    //}

    public void Operate()
    {
        slidingDoorSound.Play();

        if (_open)
        {
            Vector3 pos = transform.position - dPos;
            transform.position = pos;
        }
        else
        {
            Vector3 pos = transform.position + dPos;
            transform.position = pos;
        }

        _open = !_open;
    }
}
