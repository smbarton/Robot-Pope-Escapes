using UnityEngine;
using System.Collections;

public class MovingWall : MonoBehaviour
{

    [SerializeField]
    private Vector3 dPos;   //the position to offset to when the door opens

    public AudioSource wallSound;

    private bool _open; //boolean to keep track of the open state door

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Activate()
    {
        if (!_open)
        {
            wallSound.Play();

            Vector3 pos = transform.position + dPos;
            transform.position = pos;
            _open = true;
        }

        Messenger.Broadcast(GameEvent.DOOR_OPENED);
    }
    public void Deactivate()
    {
        if (_open)
        {
            Vector3 pos = transform.position - dPos;
            transform.position = pos;
            _open = false;
        }
    }
}