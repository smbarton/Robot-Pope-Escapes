using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    //private List<GameObject> _inventory = new List<GameObject>();

    //public List<GameObject> Inventory { get { return _inventory; } set; }

    private bool _hasBook;
    private bool _hasGlasses;


    // Use this for initialization
    void Start () {

        _hasBook = _hasGlasses = false;

        Messenger.AddListener(GameEvent.BOOK_TAKEN, OnBookTaken);
        Messenger.AddListener(GameEvent.GLASSES_TAKEN, OnGlassesTaken);


    }

    // Update is called once per frame
    void Update () {

        if (Input.GetButtonDown("Read"))
        {
            ReadBook();
        }

        if(Input.GetButtonDown("Glasses"))
        {
            WearGlasses();
        }

        if (Input.GetKeyDown("escape"))
        {
            Messenger.Broadcast(GameEvent.EXITING_ITEM);
        }


    }

    //public void AddItem (GameObject item)
    //{
    //    _inventory.Add(item);
    //}

    //public void DisplayInventory()
    //{
    //    foreach (GameObject gameobject in _inventory)
    //        Debug.Log(gameobject.name);
    //}

    private void OnGlassesTaken()
    {
        _hasGlasses = true;
    }

    private void OnBookTaken()
    {
        _hasBook = true;
    }

    public void ReadBook()
    {
        if (_hasBook == true)
        {
            Messenger.Broadcast(GameEvent.READING_BOOK);
        }
        else
        {
            Debug.Log("Nothing to read.");
        }
    }

    public void WearGlasses()
    {
        if (_hasGlasses == true)
        {
            Messenger.Broadcast(GameEvent.USING_GLASSES);
        }
        else
        {
            Debug.Log("Nothing to see.");
        }
    }

    void OnDestroy()
    {

        Messenger.RemoveListener(GameEvent.BOOK_TAKEN, OnBookTaken);
        Messenger.RemoveListener(GameEvent.GLASSES_TAKEN, OnGlassesTaken);

    }
}
