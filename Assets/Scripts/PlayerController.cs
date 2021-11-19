using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public Rigidbody childRigid;
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
        setKinematic(true);

    }


    void Update()
    {
        if (alive)
        {
            //movement plus sprint speed script
            verticalInput = Input.GetAxis("Vertical");
            verticalanimationInput = Input.GetAxis("Vertical");
            horizontalInput = Input.GetAxis("Horizontal");

            if (Input.GetKey(KeyCode.L))
            { alive = false; }

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



            if (horizontalInput != 0 || verticalInput != 0)
            {
                isMoving = true;

            }
            else
            {
                isMoving = false;
            }

        }
        if (health <= 0)
        {
            alive = false;
        }



        else if (alive == false)
        {
            setKinematic(false);
            anim.enabled = false;
        }



    }
    //Change all child components as "new value" on rigidbody
    void setKinematic(bool newValue)
    {

        //Get an array of components that are of type Rigidbody
        Component[] components = GetComponentsInChildren(typeof(Rigidbody));

        //For each of the components in the array, treat the component as a Rigidbody and set its isKinematic and detectCollisions property
        foreach (Component c in components)
        {
            (c as Rigidbody).isKinematic = newValue;
            (c as Rigidbody).detectCollisions = !newValue;
        }

        //Sets PLAYER rigid body as opposite
        childRigid.isKinematic = !newValue;
        childRigid.detectCollisions = newValue;

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
