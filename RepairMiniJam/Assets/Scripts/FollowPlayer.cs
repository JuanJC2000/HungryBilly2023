using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;
    public float smoothing =5f; // Smoothnes of camera
    private Vector3 offset = new Vector3(0, 3, -10); //Offset between player and center of screen

   // private Vector3 offset;// set new private vector 3 offset to make code easily editable for future offset of camera if need be
    
    void Start()
    {
       

       // offset = transform.position - player.transform.position;
    }

    //using late update for smoothness of camera
    
    void LateUpdate()
    {
        Vector3 targetPos = player.transform.position + player.transform.TransformDirection(offset); //Calculates the position the camera should move too
        //Vector3 targetPos = player.transform.position + new Vector3(offset.x, offset.y, 0);

        Vector3 smoothPos = Vector3.Lerp(transform.position, targetPos, smoothing * Time.deltaTime); // Lerp allows the camera to move towards the player position
        //offset the camera behind the player by adding to the players position
        //Vector3 targetCamPos = player.transform.position + offset;

        //smoothPos.z = transform.position.z;
        transform.position = smoothPos; // Update Camera position

        Vector3 lookAtPos = player.transform.position + player.transform.TransformDirection(new Vector3(0,1,0)); //Calculate the position that the camera should be looking at
        transform.LookAt(lookAtPos); // Make the camera look at the player position
        //transform.LookAt(player.transform.position + player.transform.forward * 10);
        //transform.rotation = Quaternion.Euler(0, 0, player.transform.eulerAngles.z);
        //transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
