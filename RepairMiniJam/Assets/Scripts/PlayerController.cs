using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    //Raw stats for car
    private float speed = 20f;
    private float turnSpeed = 45f;

    //Axis data reference saves as variable
    public float horizontalInput;
    public float verticalInput;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //moves the car  forward based on vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);


        // rotates the car on its y axis based on horizontal input
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);

        // Make car go forwards
    }
}
