using UnityEngine;
using System.Collections;
using System;

public class BookReadingController : MonoBehaviour {

    //private GameObject[] pages;
    //private GameObject[] greenPages;

    public GameObject page;
    public GameObject greenPage;

    private bool _wearingGlasses;


	// Use this for initialization
	void Start () {

        Messenger.AddListener(GameEvent.USING_GLASSES, OnUsingGlasses);
        Messenger.AddListener(GameEvent.EXITING_ITEM, OnExitItem);

        page.SetActive(false);
        greenPage.SetActive(false);

	}

    // Update is called once per frame
    void Update () {
	
	}

    private void OnExitItem()
    {

        _wearingGlasses = false;

        greenPage.SetActive(false);
        page.SetActive(true);
    }

    private void OnUsingGlasses()
    {
        greenPage.SetActive(true);
        page.SetActive(false);

        _wearingGlasses = true;
    }

    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.USING_GLASSES, OnUsingGlasses);
        Messenger.RemoveListener(GameEvent.EXITING_ITEM, OnExitItem);
    }
}
