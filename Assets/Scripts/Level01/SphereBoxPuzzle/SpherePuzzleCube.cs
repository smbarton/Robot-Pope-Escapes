using UnityEngine;
using System.Collections;
using System;

public class SpherePuzzleCube : MonoBehaviour
{

    private Color red, blue, yellow, current;
    private int index;

    private Color[] colorArray;

    public string CurrentColor { get; set; }

    public AudioSource switchClick;

    // Use this for initialization
    void Start()
    {

        red = Color.red;
        blue = Color.blue;
        yellow = Color.yellow;

        current = new Color();

        colorArray = new Color[] { red, blue, yellow };

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Operate()   //Declare a method for Operate
    {
        switchClick.Play();

        if (index < 2)
        {
            index++;
            current = colorArray[index];

            switch (index)
            {
                case 1:
                    CurrentColor = "Blue";
                    break;
                case 2:
                    CurrentColor = "Yellow";
                    break;
            }

        }
        else
        {
            index = 0;
            current = colorArray[index];

            CurrentColor = "Red";
        }
        
        //The numbers are RGB values that range form 0 to 1
        //Color random = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        GetComponent<Renderer>().material.color = current;   //The color is set in the material attache to the object

        Messenger.Broadcast(PuzzleEvent.CUBE_COLOR_CHANGE);
    }

    void OnDestroy()
    {

    }
}
