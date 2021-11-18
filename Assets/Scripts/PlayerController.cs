using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private PickUp pickUp;
    public float speed;
    public float basicSpeed;
    public float sprintSpeed;
    private float horizontalInput;
    private float verticalInput;
    public float jumpStrength;
    public bool grounded;
    public int maxjumps;

    // Start is called before the first frame update
    void Start()
    {
        pickUp = FindObjectOfType<PickUp>();
        playerRb = gameObject.GetComponent<Rigidbody>(); //activating rigidbody on player
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        //movement plus sprint speed script
        if (Input.GetKey(KeyCode.LeftShift))
        {speed = sprintSpeed * pickUp.bonusSpeed;}//Multiplied by PickUp bonus speed.
        else
        {speed = basicSpeed * pickUp.bonusSpeed; }//Multiplied by PickUp bonus speed.


        //basic movement
            transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
            transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);

        //jump
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            playerRb.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
            maxjumps++;
            if (maxjumps == 2)
            {
                grounded = false;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        maxjumps = 0;
        grounded = true;
    }
}
