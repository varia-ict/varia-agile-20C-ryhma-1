using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivityVertical = -100f;
    public float sensitivityHorizontal = 100f;
    public GameObject Player;
    public PlayerController playerC;
    // Start is called before the first frame update
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerC.alive)
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivityHorizontal * Time.deltaTime;
            Player.transform.Rotate(Vector3.up, mouseX);

            float mouseY = Input.GetAxis("Mouse Y") * sensitivityVertical * Time.deltaTime;
            transform.Rotate(Vector3.up, mouseY);
            //Vector3 lookDirection = (camera.transform.position - transform.position);
            }
        }


    

}
