using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private FootStepScript footStep;
    public float speed;
    public float basicSpeed = 3;
    public float sprintSpeed = 5;
    private float horizontalInput;
    private float verticalInput;
    private float verticalanimationInput;
    public float jumpStrength = 350;
    public bool grounded;
    public int maxjumps;
    public int jumps;
    public bool isMoving;
    public float health = 100;

    Animator anim;
    private PickUp pickup;

    public bool alive;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody>(); //activating rigidbody on player
        pickup = gameObject.GetComponent<PickUp>();
        footStep = FindObjectOfType<FootStepScript>();
        anim = GetComponent<Animator>();

    }

  
    void Update()
    {
        if (alive)
        {
            //movement plus sprint speed script
            verticalInput = Input.GetAxis("Vertical");
            verticalanimationInput = Input.GetAxis("Vertical");
            horizontalInput = Input.GetAxis("Horizontal");

            if (Input.GetKey(KeyCode.LeftShift))
            { speed = sprintSpeed + pickup.bonusSpeed; }
            else
            { speed = basicSpeed + pickup.bonusSpeed; }


            //basic movement
            transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
            transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
            anim.SetFloat("Speed", verticalanimationInput);
            



            //jump with maxjump increase possible, and ground check boolean
            if (Input.GetKeyDown(KeyCode.Space) && grounded)
            {
                playerRb.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
                jumps++;
                footStep.inGrass = false;
                footStep.inWater = false;
                footStep.inWood = false;
                if (jumps == maxjumps)
                {
                    grounded = false;
                    footStep.inGrass = false;
                    footStep.inWater = false;
                    footStep.inWood = false;
                }
            }
            if(health <= 0)
            {
                alive = false;
            }



        }else if(alive == false)
        {

        }


        if (horizontalInput != 0 || verticalInput != 0)
        {
            isMoving = true;

        }
        else
        {
            isMoving = false;
        }

    }

    //resetting jumps and makes player float on water
    private void OnCollisionEnter(Collision collision)
    {
        jumps = 0;
        grounded = true;

        if (collision.collider.tag == "water")
        {
            playerRb.AddForce(Vector3.up * 1000, ForceMode.Force);
        }
    }
}
