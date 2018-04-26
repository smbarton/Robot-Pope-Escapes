using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    private bool _open = false;

    public bool SwitchOpen { get; set; }

    public AudioSource doorOpen;

    // Use this for initialization
    void Start () {

        SwitchOpen = false;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Operate()    //Methof called by the shooting script
    {
        if (SwitchOpen == true)
        {
            if (_open == false)
            {
                _open = true;

                StartCoroutine(Open());
            }
            else
            {
                _open = false;

                StartCoroutine(Close());
            }
        }
    }

    private IEnumerator Open()   //Topple the enemy, wait 1.5 seconds, then destroy enemy
    {
        this.transform.Rotate(0, 90, 0);
        this.transform.Translate(-2.5f, 0, -2.5f);

        doorOpen.Play();

        yield return new WaitForSeconds(0.5f);

    }

    private IEnumerator Close()   //Topple the enemy, wait 1.5 seconds, then destroy enemy
    {
        this.transform.Rotate(0, -90, 0);
        this.transform.Translate(2.5f, 0, -2.5f);

        doorOpen.Play();

        yield return new WaitForSeconds(0.5f);

    }

    public void SetOpen(bool open)
    {
        _open = open;
    }
}
