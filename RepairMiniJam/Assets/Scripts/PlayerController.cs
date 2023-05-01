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
       
        
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

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
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("jumping");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    
    }

    private void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheckTransform.position, groundDistance, groundMask);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DeathGuard"))
        {
            GameManager.Instance.LoseGame();
        }

        else if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            isGrounded = true;
            
        }

        if (collision.gameObject.CompareTag("Death"))
        {
            GameManager.Instance.LoseGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("WayPoint"))
        {
            GameManager.Instance.WinGameTest();
        }
    }

}
