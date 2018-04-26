using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]    //The surrounding lines are context for placing the RequireComponent() method

public class RelativeMovement : MonoBehaviour
{
    [SerializeField]
    private Transform target;   //The script needs a reference to the object ro move relative to
    private ControllerColliderHit _contact; //needed to store collision data between functions
    
    //private Animator _animator;

    public float rotSpeed = 15.0f;
    public float moveSpeed = 6.0f;

    //For JUMP speed
    public float jumpSpeed = 15.0f;
    public float gravity = -9.8f;
    public float terminalVelocity = -10.0f;
    public float minFall = -1.5f;

    private float _vertSpeed;


    private CharacterController _charController;

    void Start()
    {
        _vertSpeed = minFall;   //Initialize the vertical speed to the minimum falling speed at the start of the existing function
        _charController = GetComponent<CharacterController>();  //Getting access to other components
        
        //_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 movement = Vector3.zero;    //Start with Vector(0,0,0) and add movement components progressively

        float horInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");

        if (horInput != 0 || vertInput != 0)    //Only handle movement while arrow keys are pressed
        {
            movement.x = horInput * moveSpeed;
            movement.z = vertInput * moveSpeed;
            movement = Vector3.ClampMagnitude(movement, moveSpeed); //Limit diagonal movement to the same speed as movement along an axis

            Quaternion tmp = target.rotation;   //Keep the initial rotation to restore after finishing with the target object
            target.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
            movement = target.TransformDirection(movement); //Transform movement direction from Local to Global coordinates
            target.rotation = tmp;

            //transform.rotation = Quaternion.LookRotation(movement); //LookRotation() calculates a quaternion facing in that direction
            Quaternion direction = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Lerp(transform.rotation, direction, rotSpeed * Time.deltaTime);

        }

        //_animator.SetFloat("Speed", movement.sqrMagnitude); //Take the magnitude of movement vector to use as speed

        bool hitGround = false;
        RaycastHit hit;

        if (_vertSpeed < 0 && Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            float check =
            (_charController.height + _charController.radius) / 1.9f;
            hitGround = hit.distance <= check;
        }

        if (hitGround)
        {
            if (Input.GetButtonDown("Jump"))
            {
                _vertSpeed = jumpSpeed;
            }
            else {
                _vertSpeed = -0.1f;
                //_animator.SetBool("Jumping", false);
            }
        }
        else {
            _vertSpeed += gravity * 5 * Time.deltaTime;
            if (_vertSpeed < terminalVelocity)
            {
                _vertSpeed = terminalVelocity;
            }

            if (_contact != null)   //Don't trigger this value right at the beginning of the level
            {
                //_animator.SetBool("Jumping", true);
            }

            if (_charController.isGrounded)
            {
                if (Vector3.Dot(movement, _contact.normal) < 0)
                {
                    movement = _contact.normal * moveSpeed;
                }
                else {
                    movement += _contact.normal * moveSpeed;
                }
            }
        }
        movement.y = _vertSpeed;
        movement *= Time.deltaTime;
        _charController.Move(movement);
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        _contact = hit;
    }
}
