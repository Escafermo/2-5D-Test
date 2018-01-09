using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    private GameObject player;
    //private Vector3 offset;
    //private Quaternion thisRotation;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        //offset = new Vector3(8, 2, 0);
    }


    void LateUpdate()
    {
        transform.LookAt(player.transform);


        //print("RHoriz: " + Input.GetAxis("RHoriz"));
        //print("RVert: " + Input.GetAxis("RVert"));

        //transform.position = player.transform.position + offset;

        //thisRotation.x = Input.GetAxis("RVert");
        //print(thisRotation);
    }
}
