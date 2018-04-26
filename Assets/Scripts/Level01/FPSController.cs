using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]

public class FPSController : MonoBehaviour {

    public float speed = 10.0f;
    public float gravity = -9.8f;

    public float pushForce = 3.0f;  //amount of force to apply
    private ControllerColliderHit _contact;

    private CharacterController _charController;

    //define component item to reference
    //get in start
    //use in update

	// Use this for initialization
	void Start () {

        _charController = GetComponent<CharacterController>();  //initialize
	
	}
	
	// Update is called once per frame
	void Update () {

        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed); //clamps the speed

        movement.y = gravity;

        movement *= Time.deltaTime; //frame rate

        //Frame of reference transformation, takes the objects frame of reference 
        //and translates it to the global fram of reference
        movement = transform.TransformDirection(movement);  

        _charController.Move(movement); //move character
        	
	}

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        _contact = hit;

        Rigidbody body = hit.collider.attachedRigidbody;    //Check if the collided object is a Rigidbody to receive physics forcees

        if(body != null && !body.isKinematic)
        {
            body.velocity = hit.moveDirection * pushForce;  //Apply velocity to the physics body
        }
    }
}
