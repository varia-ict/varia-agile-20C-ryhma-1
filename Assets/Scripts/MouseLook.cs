using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour


{
    public float sensitivityVertical = -100f;
    public float sensitivityHorizontal = 100f;
    public GameObject Player;
    public PlayerController playerControllerobject;
    

    // Start is called before the first frame update
    void Start()
    {
    Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (playerControllerobject.alive)
        {
            float mouseY = Input.GetAxis("Mouse Y") * sensitivityVertical * Time.deltaTime;
            transform.Rotate(Vector3.left, mouseY);

            if (transform.eulerAngles.x > 30 && transform.eulerAngles.x < 180)
            {
                transform.eulerAngles = new Vector3(30, transform.eulerAngles.y, transform.eulerAngles.z);
            }


            if (transform.eulerAngles.x < 330 && transform.eulerAngles.x > 181)
            {
                transform.eulerAngles = new Vector3(331, transform.eulerAngles.y, transform.eulerAngles.z);
            }

            if (Input.GetKeyDown(KeyCode.Mouse2))
            {
                transform.eulerAngles = new Vector3(10, 360, 0);
            }



            float mouseX = Input.GetAxis("Mouse X") * sensitivityHorizontal * Time.deltaTime;
            Player.transform.Rotate(Vector3.up, mouseX);
        }

    }




}
