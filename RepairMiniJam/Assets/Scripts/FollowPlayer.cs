using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;
    public float smoothing =5f;

    private Vector3 offset;// set new private vector 3 offset to make code easily editable for future offset of camera if need be
    
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    //using late update for smoothness of camera
    
    void LateUpdate()
    {
        //offset the camera behind the player by adding to the players position
        Vector3 targetCamPos = player.transform.position + offset;
        
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        //transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
