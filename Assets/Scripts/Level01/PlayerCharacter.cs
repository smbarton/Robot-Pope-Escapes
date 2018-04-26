using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour
{
    private int _health;

    void Start()
    {
        _health = 5;    //Initialize Health Value
    }

    public void Hurt(int damage)    //Decrement the player's health
    {
        _health -= damage;
        Debug.Log("Health: " + _health); 
    }
}