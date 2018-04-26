using UnityEngine;
using System.Collections;

public class LightBall : MonoBehaviour {

    public Light greenLight;
    public ParticleSystem greenGems;
    public GameObject lights;

    // Use this for initialization
    void Start()
    {

        Messenger.AddListener(PuzzleEvent.ALL_GREEN_LASERS, OnAllGreenLasers);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnAllGreenLasers()
    {
        //greenLight.gameObject.SetActive(true);
        greenGems.gameObject.SetActive(true);
        lights.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(PuzzleEvent.ALL_GREEN_LASERS, OnAllGreenLasers);
    }
}
