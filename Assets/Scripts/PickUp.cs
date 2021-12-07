using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUp : MonoBehaviour
{
    private float timerStart = 0;
    private float timerStartJump = 0;
    private float time;
    public float bonusSpeed= 0;
    public AudioClip pickUpSound;
    private PlayerController playerController;
    private GameManager gameManager;

    public TextMeshProUGUI effect1;
    public TextMeshProUGUI effect2;

    

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        playerController = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        SpeedEffectTimer();
        JumpTimer();
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


    void JumpTimer()
    {
        if (timerStartJump > 5)
        {
            playerController.jumpStrength = 450;
            timerStartJump -= Time.deltaTime;
            effect2.text = "*Effect: " + (int)timerStartJump + "s Extra Jump.";
        }
        else if (timerStartJump > 0)
        {
            timerStartJump -= Time.deltaTime;
            playerController.jumpStrength = 0;
            effect2.text = "*Effect: " + (int)timerStartJump + "s No Jump.";
        }
        else if (timerStart <= 0)
        {
            timerStartJump = 0;
            playerController.jumpStrength = 350;
            effect2.text = "";

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
            int effect = Random.Range(1, 4);
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

                case 3:
                    //Adding jump strenght to player after that, less jump.
                    Debug.Log("Extra Jump");
                    timerStartJump = 15;
                    break;
            }
        }
    }


}
