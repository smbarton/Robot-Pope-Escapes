using UnityEngine;
using System.Collections;

public class RayShooter : MonoBehaviour {

    private Camera _camera; //private variables naming conventions use _underscore

    [SerializeField]
    private AudioSource soundsource;
    [SerializeField]
    private AudioClip hitWallSound;
    [SerializeField]
    private AudioClip hitBookSound;

    public int size = 24;   //to edit the size of the GUI point

	// Use this for initialization
	void Start () {

        _camera = GetComponent<Camera>();   //Access other components attached to the same object

        //Hide the mouse at the center of the screen
        Cursor.lockState = CursorLockMode.Locked;   
        Cursor.visible = false;
	
	}

    //For the cursor pointing in the middle of the screen
    void OnGUI()    //every MonoBehaviour automatically responds to an OnGUI() method //Runs every frame right after the 3D scene is rendered
    {
        //int size = 12;

        GUI.color = Color.red;

        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "+");   //The command GUI.Label() displays text on screen
        
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))    //Respond to the mouse button   //GetMouseButtonDown returns TRUE or FALSE
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);    //The middle of the screen is half the width and height

            Ray ray = _camera.ScreenPointToRay(point);  //Create the ray at that position using ScreenPointToRay()

            RaycastHit hit; //RaycastHit object holds infromation about object hit with raycast

            if (Physics.Raycast(ray, out hit))  //The raycast fills a referenced variable with information; Returns RaycastHit object through out parameter
            {
                GameObject hitObject = hit.transform.gameObject;    //Retrieve the object the ray hit

                

                Debug.Log("Hit " + hit.collider.gameObject.ToString());  //Retrieve coordinates where the ray hit

                if (hitObject.tag == "door") //Check for the ReactiveTarget component on the object
                {
                    Door target = hitObject.GetComponent<Door>();

                    //target.ReactToHit();    //Call a method of the target instead of just emitting the debug message
                    soundsource.PlayOneShot(hitBookSound);

                }
                else if (hitObject.tag == "book")
                {
                    Book target = hitObject.GetComponent<Book>();
                    //target.gameObject.SetActive(false);

                    //target.ReactToHit();
                    soundsource.PlayOneShot(hitBookSound);
                }
                else
                {
                    //StartCoroutine(SphereIndicator(hit.point)); //Launch a coroutine in response to a hit
                    soundsource.PlayOneShot(hitWallSound);
                }
            }
        }
	
	}

    private IEnumerator SphereIndicator(Vector3 pos)    //Coroutines use IEnumerator functions
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1); //the YIELD keyword tells coroutines where to pause

        Destroy(sphere);    //remove this GameObject and clear its memory
    }
}
