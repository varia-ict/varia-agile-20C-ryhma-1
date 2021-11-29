using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private float timerStart = 0;
    private int effectNumber = 0;
    public float bonusSpeed= 0;
    public AudioClip pickUpSound;
    private PlayerController playerController;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        SpeedEffectTimer();
    }

    //How long the speed effect lasts.
    void SpeedEffectTimer()
    {
        if(timerStart > 2 && effectNumber == 1)
        {
            bonusSpeed = 1;
            timerStart -= Time.deltaTime;
        }else if (timerStart > 0 && effectNumber== 1)
        {
            timerStart -= Time.deltaTime;
            bonusSpeed = -2f;
        } else if (timerStart <= 0)
        {
            effectNumber = 0;
            timerStart = 0;
            bonusSpeed = 0;
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
            gameManager.CollectedItems++;

            switch (effect)
            {
                // Double speed after the speed is reduced :)
                case 1:
                    timerStart = 15;
                    effectNumber = 1;
                    break;
                case 2:
                    //Extra life :)
                    //playerController.health +=50;
                    break;

                case 3:
                    //Added strength to player after that, inability to attack.
                    effectNumber = 3;
                    break;
            }
        }
    }


}
