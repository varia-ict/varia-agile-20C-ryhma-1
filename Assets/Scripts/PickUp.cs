using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private float timerStart = 0;
    private float timerStartJump = 0;
    public float bonusSpeed= 0;
    public AudioClip pickUpSound;
    private PlayerController playerController;
    private GameManager gameManager;

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
        }else if (timerStart > 0)
        {
            timerStart -= Time.deltaTime;
            bonusSpeed = -2f;
        }else if (timerStart <= 0)
        {
  
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
        }
        else if (timerStartJump > 0)
        {
            timerStartJump -= Time.deltaTime;
            playerController.jumpStrength = 0;
        }
        else if (timerStart <= 0)
        {
            timerStartJump = 0;
            playerController.jumpStrength = 350;
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
