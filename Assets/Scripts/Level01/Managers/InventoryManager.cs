using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour, IGameManager
{
    //private List<string> _items; //inventory as a list

    private Dictionary<string, int> _items; //Dictionary is declared with two types: the key and the value

    public ManagerStatus status { get; private set; }

    public string equippedItem { get; private set; }

    private NetworkService _network;

    public void Startup(NetworkService service)
    {
        Debug.Log("Inventory manager starting...");

        //_items = new List<string>(); //inventory as a list
        _items = new Dictionary<string, int>();

        status = ManagerStatus.Started;

        _network = service;
    }

    private void DisplayItems()
    {
        string itemDisplay = "Items: ";
        foreach (KeyValuePair<string, int> item in _items)
        {
            itemDisplay += item.Key + "(" + item.Value + ")";
        }

        Debug.Log(itemDisplay);
    }

    public void AddItem(string name)
    {
        //_items.Add(name); //inventory as a list

        //Checks for existing entries before entering new data
        if(_items.ContainsKey(name))
        {
            _items[name] += 1;  //passes the string as a name and increments the number key
        }
        else
        {
            _items[name] = 1;
        }

        DisplayItems();
    }

    public List<string> GetItemList()
    {
        List<string> list = new List<string>(_items.Keys);
        return list;
    }

    public int GetItemCount(string name)
    {
        if (_items.ContainsKey(name))
        {
            return _items[name];
        }

        return 0;
    }

    public bool EquipItem(string name)
    {
        if(_items.ContainsKey(name) && equippedItem != name)    //Check that inventory has the item and it isn't already equipped
        {
            equippedItem = name;
            Debug.Log("Equipped " + name);
            return true;
        }

        equippedItem = null;
        Debug.Log("Unequipped");
        return false;
    }

    public bool ConsumeItem(string name)
    {
        if (_items.ContainsKey(name))   //Checks if the item is in the inventory
        {
            _items[name]--;
            if(_items[name] == 0)
            {
                _items.Remove(name);    //Remove the entry if the count goes to 0
            }
        }
        else
        {
            Debug.Log("cannot consume " + name);
            return false;
        }

        DisplayItems();
        return true;
    }
}