using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenTransition : MonoBehaviour {

    private float timeLeft = 40;

    public Image mainImage;

    public Sprite explanation;

    private bool _isSecondImage;

    //public GameObject panel;

    // Use this for initialization
    void Start () {

        _isSecondImage = false;

    }
	
	// Update is called once per frame
	void Update () {

        if (_isSecondImage == false)
        {
            if (Input.GetKeyDown("return"))
            {
                mainImage.sprite = explanation;
                _isSecondImage = true;
            }
        }
        else
        {
            if (Input.GetKeyDown("return"))
                SceneManager.LoadScene(1);  //Opens to the dungeon level
        }

     }
}
