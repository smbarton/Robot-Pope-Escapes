using UnityEngine;
using System.Collections;

public class CardboardSwitcher : MonoBehaviour {

    public GameObject[] cardboardObjects;
    public GameObject[] monoObjects;

	// Use this for initialization
	void Start () {

        ActivateVRMode(false);
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Cardboard.SDK.BackButtonPressed)
            Switch();
	
	}

    void ActivateVRMode(bool isVR)
    {
        foreach (GameObject cardboardThing in cardboardObjects)
        {
            cardboardThing.SetActive(!isVR);
        }
        foreach (GameObject monoThing in monoObjects)
        {
            monoThing.SetActive(!isVR);
        }

        Cardboard.SDK.VRModeEnabled = isVR;

        //gameObject.GetComponent<GameController>()
    }

    public void Switch()
    {
        ActivateVRMode(!Cardboard.SDK.VRModeEnabled);
    }

}
