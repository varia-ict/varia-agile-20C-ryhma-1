using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBonus : MonoBehaviour
{
    //private Player player;
    private float timerStart = 0;
    private bool isActive = false;
    private int effectNumber = 0;

    //Find Player script to get his speed.
    void Start()
    {
        //player = FindObjectOfType<Player>();    
    }

    //Increase and Decrease effect starts when the parameters matches.
    private void Update()
    {
        IncreaseSpeed();
        DecreaseSpeed();
    }

    //10 seconds of double speed.
    void IncreaseSpeed()
    {
        if(timerStart > 0 && isActive== true && effectNumber == 1)
        {
            timerStart -= Time.deltaTime;
            //player.speed *=2
        } else if (timerStart < 0 && isActive == true && effectNumber == 2) {
            timerStart = 0;
            isActive = false;
        }

    }

    //10 seconds of half speed.
    void DecreaseSpeed()
    {
        if (timerStart > 0 && isActive == true)
        {
            timerStart -= Time.deltaTime;
            //player.speed /=2
        }
        else if (timerStart < 0 && isActive == true)
        {
            timerStart = 0;
            isActive = false;
        }
    }

    //Random bonus when player collides with PickUps (Positive or negative bonus).
    private void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.CompareTag("Mushroom")) { 

         int effect = Random.Range(1, 2);

            switch (effect)
            {
            case 1:
                    timerStart = 10;
                    isActive =!isActive;
                    effectNumber = 1;
                break;

            case 2:
                    timerStart = 10;
                    isActive = !isActive;
                    effectNumber = 2;
                break;
            }
        }
    }
}
