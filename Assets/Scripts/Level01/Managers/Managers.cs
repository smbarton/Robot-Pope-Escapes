using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Step 1: add a RequireComponent attribute here.
[RequireComponent(typeof(AudioManager))]
[RequireComponent(typeof(InventoryManager))]

public class Managers : MonoBehaviour
{
    //Step 2: add a static property of manager here.
    public static AudioManager Audio { get; private set; }
    public static InventoryManager Inventory { get; private set; }

    private List<IGameManager> _startSequence;

    void Awake()
    {
        //Step 3: use GetComponent to get instance of manager here.

        Audio = GetComponent<AudioManager>();
        Inventory = GetComponent<InventoryManager>();

        _startSequence = new List<IGameManager>();
        
        //Step 4: Add manager property to _startSequence List.

        _startSequence.Add(Audio);
        _startSequence.Add(Inventory);

        StartCoroutine(StartupManagers());
    }

    private IEnumerator StartupManagers()
    {
        NetworkService network = new NetworkService();

        foreach (IGameManager manager in _startSequence)
        {
            //manager.Startup(network);
            manager.Startup(network);
        }

        yield return null;

        int numModules = _startSequence.Count;
        int numReady = 0;

        while (numReady < numModules)
        {
            int lastReady = numReady;
            numReady = 0;

            foreach(IGameManager manager in _startSequence)
            {
                if(manager.status == ManagerStatus.Started)
                {
                    numReady++;
                }
            }

            if (numReady > lastReady)
            {
                Debug.Log("Progress: " + numReady + "/" + numModules);
            }

            yield return null;
        }

        Debug.Log("All managers started up");
    }
}
