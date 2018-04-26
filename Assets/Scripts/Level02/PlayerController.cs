using UnityEngine;
using System.Collections;

[System.Serializable]	//Makes this class visible in the Inspector
public class Boundary
{
    public float xMin, xMax, zMin, zMax;

}

public class PlayerController : MonoBehaviour 
{
	public float speed;
	public float tilt;
    public Boundary boundary;	//reference to the Boundary class to use its variables

	private Rigidbody rb;	//reference to the object's rigidbody component

	void Start()
	{
		rb = GetComponent<Rigidbody>();	//place the item's rigidbody component into the variable
	}

    void Update()
    {
        
    }

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement * speed;


        //Clamps a value between a minimum float and maximum float value.
		rb.position = new Vector3
			(
				Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), -2f, Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
			);

		//In this instance, wanting to tilt the ship on the z-axis
		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);	
	}


}
