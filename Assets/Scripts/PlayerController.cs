using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region variables
    [Header("Game Objects")]
    public Rigidbody playerRb;
    private FootStepScript footStep;
    public GameObject GameOverScreen;
    private IEnumerator deathcounter;

    [Header("Movement speed related")]
    public float speed;
    public float basicSpeed = 3;
    public float sprintSpeed = 5;
    private float horizontalInput;
    private float verticalInput;
    private float verticalanimationInput;

    [Header("Jump related")]
    public float jumpStrength = 350;
    public int maxjumps;
    public int jumps;

    [Header("Booleans")]
    public bool grounded;
    public bool isMoving;
    Animator anim;
    private PickUp pickup;

    [Header("Health")]
    public float health = 100;
    private float maxHealth = 100;
    public bool alive;
            #endregion

        #region activate and set gameobjects
    void Start()
    {
        pickup = gameObject.GetComponent<PickUp>();
        footStep = FindObjectOfType<FootStepScript>();
        anim = GetComponent<Animator>();
        setKinematic(true);
    }
        #endregion

        #region Movement
    void Update()
    {

        if (alive)
        {
            if(health > maxHealth)
            {
                health = maxHealth;
            }
            //movement plus sprint speed script
            verticalInput = Input.GetAxis("Vertical");
            horizontalInput = Input.GetAxis("Horizontal");

            

            if (Input.GetKey(KeyCode.Delete))
            { alive = false; }

            if (Input.GetKey(KeyCode.LeftShift))
            { speed = sprintSpeed + pickup.bonusSpeed; }
            else
            { speed = basicSpeed + pickup.bonusSpeed; }


            //basic movement
            transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
            if(verticalInput > 0)
            {
                anim.SetBool("run", true);
            }
            else
            {
                anim.SetBool("run", false);
            }

            //making so that moving sideways is not possible while airborne
            transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);




            //jump with maxjump increase possible, and ground check boolean
            if (Input.GetKeyDown(KeyCode.Space) && grounded)
            {
                jump();
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
    #region death related       
        if (health <= 0)
        {
            alive = false;
        }
        


        if (alive == false)
        {
            setKinematic(false);
            anim.enabled = false;
            deathcounter = Death();
            StartCoroutine(deathcounter);
        }


        #endregion
    }
    IEnumerator Death()
    {
        yield return new WaitForSeconds(2);
        GameOverScreen.SetActive(true);
    }
        #endregion

        #region rigidbody modifiers for ragdoll effect
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
        playerRb.isKinematic = !newValue;
        playerRb.detectCollisions = newValue;

    }
        #endregion

        #region jump
    /*
    this region contains jump and collision that resets jumps. 
    */
    private void jump()
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
    private void OnCollisionEnter(Collision collision)
    {
        jumps = 0;
        grounded = true;
        //---------------------------
        //this is what stops char from falling trough floor from jumps
        playerRb.velocity = Vector3.zero;
        playerRb.angularVelocity = Vector3.zero;
        //----------------
        if (collision.collider.tag == "water")
        {
            playerRb.AddForce(Vector3.up * 1000, ForceMode.Force);
        }
    }
        #endregion
}