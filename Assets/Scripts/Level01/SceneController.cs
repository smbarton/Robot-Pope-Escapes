using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

    [SerializeField]
    private GameObject prefab; //Serialized variable for linking to the prefab object

    private GameObject _spawn;  //a private variable to keep track of the enemy instance in the scene

    private Vector3 spawnPosition;

    public float spawnPosX = 0.0f;
    public float spawnPosY = 0.0f;
    public float spawnPosZ = 0.0f;

    // Use this for initialization
    void Start () {

        spawnPosition = new Vector3(spawnPosX, spawnPosY, spawnPosZ);
	
	}
	
	// Update is called once per frame
	void Update ()  //Only spawn a new enemy if there isn't already one in the scene
    {    


	}

    public void SpawnWoodenPope()
    {
        if (_spawn == null)
        {
            _spawn = Instantiate(prefab) as GameObject;    //The method that copies the prefab object
            _spawn.transform.position = spawnPosition;
            float angle = Random.Range(0, 360);
            _spawn.transform.Rotate(0, angle, 0);
        }
    }
}
