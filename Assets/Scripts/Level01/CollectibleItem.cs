using UnityEngine;
using System.Collections;

public class CollectibleItem : MonoBehaviour {
    [SerializeField]
    private string itemName;    //type the name of this item in the inspector


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Item collected: " + itemName);
        //Managers.Inventory.AddItem(itemName);   //use class name, no need to instantiate //Call this method to add to inventory
        Destroy(this.gameObject);   //Destroy the gameobject this script is attached to
    }
}
