using UnityEngine;
using System.Collections;
using System;

public class ClockLight : MonoBehaviour {


    //public GameObject go;

    public ColorChangeDevice cg1, cg2, cg3, cg4;

    public Light clockLight;

    public AudioSource audioSource;

    private bool turnGreen;

	// Use this for initialization
	void Start () {

        // go = GetComponent<GameObject>();
        //cg1 = GetComponent<ColorChangeDevice>();
        //cg1 = GetComponent<ColorChangeDevice>();

        //cg2 = GetComponent<ColorChangeDevice>();
        //cg3 = GetComponent<ColorChangeDevice>();
        //cg4 = GetComponent<ColorChangeDevice>();


        //clockLight = GetComponent<Light>();

    }

    void Awake()
    {

    }
	
	// Update is called once per frame
	void Update () {

        CheckIfAllGreen();
	
	}

    private void CheckIfAllGreen()
    {
        if (turnGreen == false)
        {
            if (cg1.GetIsGreen() == true && cg2.GetIsGreen() == true && cg3.GetIsGreen() == true && cg4.GetIsGreen() == true)
            {
                // clockLight.color = Color.green;
                turnGreen = true;

                audioSource.Play();

                Messenger.Broadcast(GameEvent.COLOR_GREEN);
            }
            else
            {
                // clockLight.color = Color.red;
                turnGreen = false;
            }
        }
    }

}
