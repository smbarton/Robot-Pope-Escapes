using UnityEngine;
using System.Collections;
using System;

public class AudioManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    private NetworkService _network;

    //Add volume controls here

    
    public void Startup(NetworkService service)
    {
        Debug.Log("Audio manager starting...");

        _network = service;

        //Initialize music sources here

        status = ManagerStatus.Started;
    }
}
