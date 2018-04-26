using UnityEngine;
using System.Collections;

public class DisappearCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            StartCoroutine(Disappear());
            Destroy(this.gameObject);
        }
    }

    private IEnumerator Disappear()   //Topple the enemy, wait 1.5 seconds, then destroy enemy
    {
        yield return new WaitForSeconds(3.0f);

    }
}
