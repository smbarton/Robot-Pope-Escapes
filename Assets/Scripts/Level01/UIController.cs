using UnityEngine;
using UnityEngine.UI;   //import the UI code framework.
using System.Collections;
using System;

public class UIController : MonoBehaviour {

    //public Text objective1;

    [SerializeField]
    private SettingsPopUp settingsPopup;

    [SerializeField]
    private Image bookIcon;

    [SerializeField]
    private Image glassesIcon;

    public Canvas guiScreen, bookScreen;

    public Text objective;

    public Text readButton, glassesButton;

    public GameObject textBubble;
    public Text textBubbleText;

    //private bool _isGlassesGiven;

    void Start()
    {
        settingsPopup.Close();
        bookIcon.color = Color.black;
        glassesIcon.color = Color.black;

        bookScreen.gameObject.SetActive(false);

        glassesButton.enabled = false;
        readButton.enabled = false;

        textBubble.SetActive(false);

        //_isGlassesGiven = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            bookScreen.gameObject.SetActive(false);
            guiScreen.gameObject.SetActive(true);
        }
    }

    void Awake()
    {
        Messenger.AddListener(GameEvent.BOOK_TAKEN, OnBookTaken);
        Messenger.AddListener(GameEvent.GLASSES_TAKEN, OnGlassesTaken);

        Messenger.AddListener(GameEvent.USING_GLASSES, OnUsingGlasses);
        Messenger.AddListener(GameEvent.READING_BOOK, OnReadingBook);

        Messenger.AddListener(GameEvent.EXITING_ITEM, OnExitItem);

        Messenger.AddListener(GameEvent.COLOR_GREEN, OnColorGreen);

        Messenger.AddListener(GameEvent.DOOR_OPENED, OnDoorOpened);

        Messenger.AddListener(PuzzleEvent.ALL_GREEN_LASERS, OnAllGreenLasers);

        //objective1 = GetComponent<Text>();
    }

    private void OnAllGreenLasers()
    {
        objective.text = "Step on the lasers. Rocket to Mars!";
    }

    private void OnDoorOpened()
    {
        objective.text = "Activate the lasers";
    }

    private void OnColorGreen()
    {
        objective.text = "Walk through the wall";
    }

    private void OnExitItem()
    {
        guiScreen.gameObject.SetActive(true);
        bookScreen.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    private void OnReadingBook()
    {
        guiScreen.gameObject.SetActive(false);
        bookScreen.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnUsingGlasses()
    {
        guiScreen.gameObject.SetActive(false);
        bookScreen.gameObject.SetActive(false);
    }

    private void OnGlassesTaken()
    {
        objective.text = "Use Glasses for secrets";
        glassesButton.enabled = true;

        Debug.Log(GameEvent.GLASSES_TAKEN);
        glassesIcon.color = Color.white;

        //DisplayDialogue();
        //_isGlassesGiven = true;

    }



    private void OnBookTaken()
    {
        objective.text = "Get Glasses from Sparky";
        readButton.enabled = true;

        Debug.Log(GameEvent.BOOK_TAKEN);
        bookIcon.color = Color.white;
        //objective1.text = "Pick up the Book [COMPLETED]";
    }


    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.BOOK_TAKEN, OnBookTaken);
        Messenger.RemoveListener(GameEvent.GLASSES_TAKEN, OnGlassesTaken);

        Messenger.RemoveListener(GameEvent.USING_GLASSES, OnUsingGlasses);
        Messenger.RemoveListener(GameEvent.READING_BOOK, OnReadingBook);

        Messenger.RemoveListener(GameEvent.EXITING_ITEM, OnExitItem);
    }

    //private void DisplayDialogue()
    //{
    //    textBubble.SetActive(true);
    //    Time.timeScale = 0;
    //    StartCoroutine(Wait());
    //    textBubble.SetActive(false);
    //    Time.timeScale = 1;
    //}

    //IEnumerator Wait()
    //{
    //    yield return new WaitForSeconds(5);
    //}

}
