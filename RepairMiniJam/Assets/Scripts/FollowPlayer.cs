using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;

    private Vector3 offset = new Vector3(0, 5, -7); // set new private vector 3 offset to make code easily editable for future offset of camera if need be
    
    void Start()
    {
        
    }

    //using late update for smoothness of camera
    
    void LateUpdate()
    {
        //offset the camera behind the player by adding to the players position
     
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.position = player.transform.position + offset;
    }
}
