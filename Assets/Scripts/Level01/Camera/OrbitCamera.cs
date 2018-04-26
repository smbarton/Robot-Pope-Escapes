using UnityEngine;
using System.Collections;

public class OrbitCamera : MonoBehaviour
{

    [SerializeField]
    private Transform target;   //Serialized reference to the object to orbit around

    public float rotSpeed = 1.5f;

    public float yCameraSpot = 2.0f;

    private float _rotY;
    private Vector3 _offset;

    private bool _isPaused;

    // Use this for initialization
    void Start()
    {
        _rotY = transform.eulerAngles.y;
        _offset = target.position - transform.position; //Store the starting position offset between the camera and the target

        //Subtracting a vector from another vector creates a vector pointing at the other object


    }

    void Update()
    {

    }

    //Gets called after update
    void LateUpdate()
    {
        if (Time.timeScale == 1)
        {
            Vector3 cameraAdjustment = new Vector3(0f, yCameraSpot, 0f);

            float horInput = Input.GetAxis("Horizontal");

            if (horInput != 0)  //Either totate the camera slowly using the arrow keys
            {
                _rotY += horInput + rotSpeed;
            }
            else    //...or rotate quickly with the mouse
            {
                _rotY += Input.GetAxis("Mouse X") * rotSpeed * 3;
            }

            Quaternion rotation = Quaternion.Euler(0, _rotY, 0);
            transform.position = target.position - (rotation * _offset); //Maintain the starting offset, shifted according to the camera's rotation
            transform.LookAt(target.position + cameraAdjustment);   //No matter where the camera is relative to the target, always face the target
        }
        else
        {

        }
    }
}
