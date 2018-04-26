using System.Collections;
using UnityEngine;
using System;

public class NetworkService
{
    //API Key:12f055b98d037faf8c3f1d5d8b1f789b
    //Albuquerque city ID: 5454711

    private const string xmlApi =
        "http://api.openweathermap.org/data/2.5/weather?id=5454711&APPID=12f055b98d037faf8c3f1d5d8b1f789b&mode=xml";

    private bool IsResponseValid(WWW www)
    {
        if (www.error != null)
        {
            Debug.Log("bad connection");
            return false;
        }
        else if (string.IsNullOrEmpty(www.text))
        {
            Debug.Log("bad data");
            return false;
        }
        else //all good
        {
            return true;
        }
    }

    private IEnumerator CallAPI(string url, Action<string> callback)
    {
        WWW www = new WWW(url);
        yield return www;

        if(!IsResponseValid(www))
        {
            yield break;
        }

        callback(www.text);
    }

    public IEnumerator GetWeatherXML(Action<string> callback)
    {
        return CallAPI(xmlApi, callback);
    }

}