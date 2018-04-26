using UnityEngine;
using System.Collections;

public class WanderingAI : MonoBehaviour {

    [SerializeField]
    private GameObject fireballPrefab;

    private GameObject _fireball;

    //Values for the speed of movement and how faraway to react to obstacles
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;

    private bool _scared;    //boolean to track whether the enemy is alive

    public Transform target;

	// Use this for initialization
	void Start ()
    {

        _scared = false;  //initialize the value

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!_scared) //only move if the character is not scared
        {
            transform.Translate(0, 0, speed * Time.deltaTime);  //Move forward continuously every frame, regardless of turning.

            Ray ray = new Ray(transform.position, transform.forward);   //A ray at the same position and pointing the same direction as the character - STIMULUS
            RaycastHit hit;

            if (Physics.SphereCast(ray, .75f, out hit))    //Raycasting with the circumference around the ray - RESPONSE
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerCharacter>())
                {
                    _scared = true;
                    StartCoroutine(Stare(target));

                }
                else if (hit.distance < obstacleRange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
	
	}

    public void SetScared (bool scared)
    {
        _scared = scared;
    }

    private IEnumerator Stare(Transform targ)    //Coroutines use IEnumerator functions
    {

        yield return new WaitForSeconds(5); //the YIELD keyword tells coroutines where to pause

        _scared = false;    //remove this GameObject and clear its memory
    }
}
