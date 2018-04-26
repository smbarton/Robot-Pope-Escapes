using UnityEngine;
using System.Collections;
using System;

public class ColorChangeDevice : MonoBehaviour {

    private Color red, green, blue, yellow, current;
    private int index;

    private Color[] colorArray;

    private bool isGreen;

    public bool AllGreen { get; set; }

    public AudioSource clickSound;


    // Use this for initialization
    void Start () {

        //red = new Color();
        //green = new Color();
        //blue = new Color();
        //yellow = new Color();

        red = Color.red;
        green = Color.green;
        blue = Color.blue;
        yellow = Color.yellow;
        
        current = new Color();

        colorArray = new Color[] { red, blue, green, yellow };

        index = 0;

        Messenger.AddListener(GameEvent.COLOR_GREEN, OnAllColorGreen);

    }

    private void OnAllColorGreen()
    {
        AllGreen = true;
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void Operate()   //Declare a method for Operate
    {
        if (AllGreen == false)
        {
            clickSound.Play();

            if (index < 3)
            {
                index++;

                if (index == 2)
                {
                    isGreen = true;
                }
                else
                {
                    isGreen = false;
                }

                current = colorArray[index];
            }
            else
            {
                index = 0;
                current = colorArray[index];
            }
        }

        else
        {

        }
                
        //The numbers are RGB values that range form 0 to 1
        //Color random = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        GetComponent<Renderer>().material.color = current;   //The color is set in the material attache to the object
    }

    public bool GetIsGreen()
    {
        return isGreen;
    }

    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.COLOR_GREEN, OnAllColorGreen);
    }
}
