using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    /// <summary>
    /// Camera is set to vector (0,0,0) in editor to allow the raw offset seen here. Do not alter the transform or the camera in the editor or here.
    /// 
    /// </summary>

    public GameObject player;
    public float smoothing =5f; // Smoothnes of camera
    private Vector3 offset = new Vector3(0, 3, -10); //Offset between player and camera to, i.e behind the car

  
    
    void Start()
    {
       // offset = transform.position - player.transform.position;
    }


    //using late update for smoothness of camera
    
    void LateUpdate()
    {
        Vector3 targetPos = player.transform.position + player.transform.TransformDirection(offset); //Calculates the position the camera should move too
        

        Vector3 smoothPos = Vector3.Lerp(transform.position, targetPos, smoothing * Time.deltaTime); // Lerp allows the camera to move towards the player position
        
       

      
        transform.position = smoothPos; // Update Camera position

        Vector3 lookAtPos = player.transform.position + player.transform.TransformDirection(new Vector3(0,1,0)); //Calculate the position that the camera should be looking at
        transform.LookAt(lookAtPos); // Make the camera look at the player position

     
    }
}
