using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasicUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void onGUI()
    {
        int posX = 10;
        int posY = 10;
        int width = 100;
        int height = 30;
        int buffer = 10;

        List<string> itemList = Managers.Inventory.GetItemList();

        //Display an image if the inventory is empty
        if (itemList.Count == 0)
        {
            GUI.Box(new Rect(posX, posY, width, height), "No Items");
        }

        foreach (string item in itemList)
        {
            int count = Managers.Inventory.GetItemCount(item);
            Texture2D image = Resources.Load<Texture2D>("Icons/" + item);
            GUI.Box(new Rect(posX, posY, width, height), new GUIContent("(" + count + ")", image));
            posX += width + buffer;
        }

        string equipped = Managers.Inventory.equippedItem;

        //Display the currently equipped item
        if(equipped != null)
        {
            posX = Screen.width - (width + buffer);
            Texture2D image = Resources.Load("Icons/" + equipped) as Texture2D;
            GUI.Box(new Rect(posX, posY, width, height), new GUIContent("Equipped", image));
        }

        posX = 10;
        posY += height + buffer;

        foreach(string item in itemList)    //Loop through all items to make buttons
        {
            if (GUI.Button (new Rect(posX, posY, width, height), "Equip " + item))  //Run the contained code if the button is clicked.
            {
                Managers.Inventory.EquipItem(item);
            }

            if (item == "health")
            {
                if (GUI.Button(new Rect(posX, posY + height + buffer, width, height), "Use Health"))    //Run the contained code if the button is clicked
                {
                    Managers.Inventory.ConsumeItem("health");
                }
            }
            posX += width + buffer;
        }
    }
}