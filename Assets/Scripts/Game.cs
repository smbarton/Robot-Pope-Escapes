using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class Game {

    public static Game current;

    public bool clockGreen, bookTaken, glassesTaken, doorUnlocked, lasersGreen, inSpace;

    public Game()
    {
        clockGreen = bookTaken = glassesTaken = doorUnlocked = lasersGreen = inSpace = false;

        Messenger.AddListener(GameEvent.BOOK_TAKEN, OnBookTaken);
        Messenger.AddListener(GameEvent.GLASSES_TAKEN, OnGlassesTaken);
        Messenger.AddListener(GameEvent.COLOR_GREEN, OnClockGreen);
        Messenger.AddListener(GameEvent.DOOR_OPENED, OnDoorOpened);
        Messenger.AddListener(PuzzleEvent.ALL_GREEN_LASERS, OnLasersGreen);
    }

    private void OnLasersGreen()
    {
        current.lasersGreen = true;
    }

    private void OnDoorOpened()
    {
        current.doorUnlocked = true;
    }

    private void OnClockGreen()
    {
        current.clockGreen = true;
    }

    private void OnGlassesTaken()
    {
        current.glassesTaken = true;
    }

    private void OnBookTaken()
    {
        current.bookTaken = true;
    }

    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.BOOK_TAKEN, OnBookTaken);
        Messenger.RemoveListener(GameEvent.GLASSES_TAKEN, OnGlassesTaken);
        Messenger.RemoveListener(GameEvent.COLOR_GREEN, OnClockGreen);
        Messenger.RemoveListener(GameEvent.DOOR_OPENED, OnDoorOpened);
        Messenger.RemoveListener(PuzzleEvent.ALL_GREEN_LASERS, OnLasersGreen);
    }

}
