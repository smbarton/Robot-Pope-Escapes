using UnityEngine;
using System.Collections;
using System;

public class CameraMode : MonoBehaviour {

    private bool _isFPS;

    public Camera fpsCamera;
    public Camera thirdCamera;

    public FPSController fpsMovement;
    public MouseView fpsView;

    public RelativeMovement thirdMovement;

    public GameObject[] cardboardObjects;
    public GameObject[] monoObjects;

    // Use this for initialization
    void Start () {

        _isFPS = false;

        //fpsMovement.enabled = _isFPS;

        //fpsCamera = GetComponent<Camera>();
        //thirdCamera = GetComponent<Camera>();

        SetCameraMode(_isFPS);

        Messenger.AddListener(GameEvent.USING_GLASSES, OnGlassesUsed);
        Messenger.AddListener(GameEvent.EXITING_ITEM, OnGlassesExit);

        ActivateVRMode(false);

        //thirdCamera.enabled = false;

    }

    private void OnGlassesExit()
    {
        _isFPS = false;

        SetCameraMode(_isFPS);

        Switch();
    }

    private void OnGlassesUsed()
    {
        _isFPS = true;

        SetCameraMode(_isFPS);

        Switch();
    }

    // Update is called once per frame
    void Update ()
    {
        //if (Input.GetKeyDown("escape"))
        //{
        //    _isFPS = !_isFPS; //we don't want to be FPS anymore

        //    SetCameraMode(_isFPS);

        //}

    }

    private void SetCameraMode(bool isFPS)
    {
        fpsCamera.enabled = _isFPS;
        fpsMovement.enabled = _isFPS;
        fpsView.enabled = _isFPS;

        thirdCamera.enabled = !_isFPS;
        thirdMovement.enabled = !_isFPS;
    }

    void ActivateVRMode(bool isVR)
    {
        foreach (GameObject cardboardThing in cardboardObjects)
        {
            cardboardThing.SetActive(isVR);
        }
        //foreach (GameObject monoThing in monoObjects)
        //{
        //    monoThing.SetActive(!isVR);
        //}

        Cardboard.SDK.VRModeEnabled = isVR;

        //gameObject.GetComponent<GameController>()
    }

    public void Switch()
    {
        ActivateVRMode(!Cardboard.SDK.VRModeEnabled);
    }
}
