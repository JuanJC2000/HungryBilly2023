using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerController : MonoBehaviour
{
    //Raw stats for car
    private float speed = 20f;
    private float turnSpeed = 45f;
    public float jumpForce = 500f;
    public Transform groundCheckTransform;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;

    //Conditonals for rigidbody 
    private Rigidbody rb;
    private bool isJumping = false;
    private bool isGrounded = true;

    //Axis data reference saves as variable
    public float horizontalInput;
    public float verticalInput;


    // Start is called before the first frame update
    void Start()
    {
        isJumping = false;
        rb= GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
        //Get Inputs
        horizontalInput = Input.GetAxis("Horizontal"); 
        verticalInput = Input.GetAxis("Vertical");

        //IsGrounded allows us to change between the methods of control we want to give over the player when they do jump. 
        //I wanted to allow the player to only rotate on their axis, and to carry their momentum forward as they jump.
        //This was not working, however the infrastucure for the code is reusable and intend to build on it. For now, we just call both movement types regardless if we are grounded or not.
        if (isGrounded)
        {
            


            //moves the car  forward based on vertical input
            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);


            // rotates the car on its y axis based on horizontal input
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
        }
        else
        {
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        }

        //Adds force to jump, set our conditonals to false
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) 
        {
            Debug.Log("jumping");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    
    }

    //On FixedUpdate to reduce stress 
    private void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheckTransform.position, groundDistance, groundMask);

    }

    //We use onCollision Enter to keep track of our 'Health'. Whenever we collide with something were not supposed, we invoke the function either Lose or Win. Inside GameManager, we set the logic for these functions.
    private void OnCollisionEnter(Collision collision)
    {

        //Invoke LoseGame 
        if (collision.gameObject.CompareTag("DeathGuard"))
        {
            GameManager.Instance.LoseGame();
        }

        //Set conditionals
        else if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            isGrounded = true;
            
        }
        //Invoke LoseGame
        if (collision.gameObject.CompareTag("Death"))
        {
            GameManager.Instance.LoseGame();
        }
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("WayPoint"))
        {
            GameManager.Instance.WinGameTest();
        }
    }
    */
}
