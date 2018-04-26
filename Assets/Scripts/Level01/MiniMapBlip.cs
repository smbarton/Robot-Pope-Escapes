using UnityEngine;
using System.Collections;

public class MiniMapBlip : MonoBehaviour {

    public GameObject target;

    public Texture2D blip;

    private Vector3 _playerPosition;
    private Vector3 _screenPosition;


    // Use this for initialization
    void Start ()
    {
        target = GetComponent<GameObject>();
        _playerPosition = target.transform.position;

        blip = GetComponent<Texture2D>();

        _screenPosition = Camera.main.ScreenToWorldPoint(_playerPosition);

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (target != null)
        {
            _playerPosition = target.transform.position;
            _screenPosition = Camera.main.ScreenToWorldPoint(_playerPosition);

        }
        
    }
}
