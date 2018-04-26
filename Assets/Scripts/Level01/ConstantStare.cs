using UnityEngine;
using System.Collections;

public class ConstantStare : MonoBehaviour {

    public Transform staringTarget;

    public float yStareSpot = 3.0f;

    private GameObject _target;

    // Use this for initialization
    void Start () {

        _target = GameObject.Find("RobotPope_v2");

        staringTarget = _target.transform;

	}
	
	// Update is called once per frame
	void Update () {

        transform.LookAt(staringTarget);
        transform.Rotate(0, -90, yStareSpot);

    }
}
