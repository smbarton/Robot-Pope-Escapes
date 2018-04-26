using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class VictoryController : MonoBehaviour
{

    public float timeLeftTilMars = 141f;    //141
    public float timeLeftTilVictory = 24f;

    public MarsMover mars;
    public GameObject gameOverPanel;
    public GameObject victoryCanvas;


    public GameObject victoryMessage;
    public GameObject victoryPanel;
    public GameObject victoryImage;

    public AudioSource explosionSource;
    public AudioClip explosionSound;

    public AudioSource backgroundMusic;


    private bool _marsSpawned;
    private bool _victoryAchieved;

    // Use this for initialization
    void Start()
    {

        Messenger.AddListener(GameEvent.PLAYER_DIED, OnPlayerDeath);
        Messenger.AddListener(GameEvent.VICTORY_ACHIEVED, OnVictory);
        Messenger.AddListener(GameEvent.SPAWNING_MARS, OnSpawningMars);

        mars.gameObject.SetActive(false);
        gameOverPanel.SetActive(false);
        victoryCanvas.SetActive(false);

    _marsSpawned = false;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (_marsSpawned == false)
        {
            if (timeLeftTilMars > 0)
            {
                timeLeftTilMars -= Time.deltaTime;
            }
            else
            {
                Messenger.Broadcast(GameEvent.SPAWNING_MARS);
                _marsSpawned = true;
            }
        }
        else
        {
            if (_victoryAchieved == false)
            {
                if (timeLeftTilVictory > 0)
                {
                    timeLeftTilVictory -= Time.deltaTime;
                }
                else
                {
                    Messenger.Broadcast(GameEvent.VICTORY_ACHIEVED);
                    _victoryAchieved = true;
                }
            }
        }

        if (_victoryAchieved == true)
        {
            if (Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene(3);
            }
        }

    }


    private void OnSpawningMars()
    {
        Debug.Log(GameEvent.SPAWNING_MARS);
        mars.gameObject.SetActive(true);
    }

    private void OnVictory()
    {
        Debug.Log(GameEvent.VICTORY_ACHIEVED);
        StartCoroutine(DisplayVictoryScreen());
    }

    private void OnPlayerDeath()
    {
        Debug.Log(GameEvent.PLAYER_DIED);
        explosionSource.PlayOneShot(explosionSound);
        StartCoroutine(DisplayGameOver());
        //gameOverPanel.SetActive(true);
    }

    IEnumerator DisplayGameOver()
    {
        backgroundMusic.Stop();
        yield return new WaitForSeconds(3);
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    IEnumerator DisplayVictoryScreen()
    {
        gameOverPanel.SetActive(false);
        victoryCanvas.SetActive(true);

        yield return new WaitForSeconds(12);

        victoryMessage.SetActive(false);
        victoryImage.SetActive(true);
        victoryPanel.SetActive(true);

        yield return new WaitForSeconds(35);

        SceneManager.LoadScene(3);
    }

    void OnDestroy()
    {

        Messenger.RemoveListener(GameEvent.PLAYER_DIED, OnPlayerDeath);
        Messenger.RemoveListener(GameEvent.VICTORY_ACHIEVED, OnVictory);
        Messenger.RemoveListener(GameEvent.SPAWNING_MARS, OnSpawningMars);

    }
}
