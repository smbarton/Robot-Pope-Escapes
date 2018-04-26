using UnityEngine;
using System.Collections;

public class Book : MonoBehaviour {

    public SceneController scene = new SceneController();

    private GameObject _book;

    public AudioSource hallelujahSound;
    public AudioSource swishSound;

    [SerializeField]
    private string itemName;    //type the name of this item in the inspector

    private string _description;

    public string Description
    {
        get { return _description; }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //public void ReactToHit()    //Method called by the shooting script
    //{
    //    inventory.AddItem(_book);
    //    scene.SpawnWoodenPope();
    //    this.gameObject.SetActive(false);
    //    Messenger.Broadcast(GameEvent.BOOK_TAKEN);
    //}

    public void Operate()
    {
        swishSound.Play();

        Debug.Log("Item collected: " + itemName);
        //Managers.Inventory.AddItem(itemName);   //use class name, no need to instantiate //Call this method to add to inventory
        Destroy(this.gameObject);   //Destroy the gameobject this script is attached to
        scene.SpawnWoodenPope();
        Messenger.Broadcast(GameEvent.BOOK_TAKEN);
    }
}
