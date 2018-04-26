using UnityEngine;
using System.Collections;
using System;

public class GameController : MonoBehaviour 
{
    public float timeLeft = 10.00f;

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Scroll scroller;
    public float scrollSpeed;

    IEnumerator waveSpawnCoroutine;
    
    void Start()
    {
        //Messenger.AddListener(GameEvent.VICTORY_ACHIEVED, OnVictoryAchieved); //For Testing
        waveSpawnCoroutine = SpawnWaves();
        StartCoroutine(waveSpawnCoroutine);   //This is how to call coroutines
    }

    void FixedUpdate()
    {
        timeLeft -= Time.deltaTime;

        if(timeLeft < 0)
        {
            //scroller.SetScrollSpeed(0.1f);
            StopCoroutine(waveSpawnCoroutine);
        }
    }

    //Coroutines need to return IEnumerator
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait); //waits for the start wait time before starting the loop

        scroller.SetScrollSpeed(scrollSpeed);
        //creates an infinite loop for spawning hazards
        while(true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(hazard, spawnPosition, spawnRotation);

                //how to return an IEnumerator value
                yield return new WaitForSeconds(spawnWait); //Waits for the spawn wait time before looping again
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    //ForTesting
    //private void OnVictoryAchieved()
    //{
    //    StopCoroutine(waveSpawnCoroutine);
    //}

}
