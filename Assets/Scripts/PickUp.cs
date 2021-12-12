using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUp : MonoBehaviour
{
    private float timerStart = 0;
    public float bonusSpeed= 0;
    public AudioClip pickUpSound;
    private PlayerController playerController;
    private GameManager gameManager;

    public TextMeshProUGUI effect1;

    

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        playerController = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        SpeedEffectTimer();
    }

    //How long the speed effect lasts.
    void SpeedEffectTimer()
    {
        if(timerStart > 2)
        {
            bonusSpeed = 1;
            timerStart -= Time.deltaTime;
            effect1.text = "*Effect: " + (int)timerStart + "s Extra Speed.";
        }
        else if (timerStart > 0)
        {
            timerStart -= Time.deltaTime;
            bonusSpeed = -2f;
            effect1.text = "*Effect: " + (int)timerStart + "s Less Speed.";
        }
        else if (timerStart <= 0)
        {
            effect1.text = "";
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
            gameManager.score += 5;
            int effect = Random.Range(1, 3);
            gameManager.CollectedItems++;

            switch (effect)
            {
                // Double speed after the speed is reduced :)
                case 1:
                    Debug.Log("Extra Speed");
                    timerStart = 15;
                    break;
                case 2:
                    //Extra life :)
                    Debug.Log("Extra Health");
                    playerController.health +=5;
                    gameManager.score -= 1;
                    break;

            }
        }
    }


}
