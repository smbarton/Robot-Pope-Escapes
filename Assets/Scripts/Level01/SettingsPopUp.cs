using UnityEngine;
using UnityEngine.UI;   //For Slider
using UnityEngine.EventSystems;
using System.Collections;

public class SettingsPopUp : MonoBehaviour {


    public void Start()
    {

    }

    public void Open()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Close()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void SaveGame()
    {
        SaveLoad.Save();
    }

    public void LoadGame()
    {
        SaveLoad.Load();
    }


}
