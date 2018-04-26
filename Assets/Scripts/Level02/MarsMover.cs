using UnityEngine;

public class MarsMover : Mover {

    public float timeLeft = 10.00f;

    void FixedUpdate()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        else
        {
            speed = 0;
        }
    }
}
