using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepScript : MonoBehaviour
{

    public bool inGrass;
    public bool inWater;
    public bool inWood;
    public bool inDirt;

    private PlayerController playerController;

    private AudioSource audioSource;
    public AudioClip waterClip;
    public AudioClip grassClip;
    public AudioClip woodClip;
    //public AudioClip dirtClip;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.isMoving == true && inGrass == true)
        {
            audioSource.clip = grassClip;
            if (!audioSource.isPlaying)
            {
                audioSource.Play(0);
            }
        }
        else if (playerController.isMoving == true && inWater == true)
        {
            audioSource.clip = waterClip;
            if (!audioSource.isPlaying)
            {
                audioSource.Play(0);
            }
        }
        else if (playerController.isMoving == true && inWood == true)
        {
            audioSource.clip = woodClip;
            if (!audioSource.isPlaying)
            {
                audioSource.Play(0);
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Grass"))
        {
            inGrass = true;
            inWater = false;
            inWood = false;
            //inDirt = false;
        }
        else if (collision.gameObject.CompareTag("water"))
        {
            inWater = true;
            inGrass = false;
            inWood = false;
            //inDirt = false;

        }
        else if (collision.gameObject.CompareTag("Wood"))
        {
            inWood = true;
            inGrass = false;
            inWater = false;
            //inDirt = false;
        }
    }
}
