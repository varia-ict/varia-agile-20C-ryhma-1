using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private float timerStart = 0;
    private int effectNumber = 0;
    public float bonusSpeed= 1;
    public AudioClip pickUpSound;

    private void Update()
    {
        EffectTimer();
    }

    //How long the speed effect lasts.
    void EffectTimer()
    {
        if(timerStart > 0 && effectNumber == 1)
        {
            bonusSpeed =2;
            timerStart -= Time.deltaTime;
        }
        else if (timerStart > 0 && effectNumber == 2)
        {
            bonusSpeed =0.5f;
            timerStart -= Time.deltaTime;

        } else if(timerStart <= 0)
        {
            effectNumber = 0;
            timerStart = 0;
            bonusSpeed = 1;
        }
    }

    // Random bonus when player collides with PickUps (Positive or negative bonus).
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mushroom"))
        {
            AudioSource.PlayClipAtPoint(pickUpSound, transform.position);
            Destroy(collision.gameObject);
            int effect = Random.Range(1, 3);

            switch (effect)
            {
                // Double speed :)
                case 1:
                    timerStart = 10;
                    effectNumber = 1;
                    break;
                // Half speed :(
                case 2:
                    timerStart = 10;
                    effectNumber = 2;
                    break;

                case 3:
                    //Deal damage to player. Reducing hp :(
                    effectNumber = 3;
                    break;

                case 4:
                    //Extra strength to the player :)
                    effectNumber = 4;
                    break;
            }
        }
    }
    
}
