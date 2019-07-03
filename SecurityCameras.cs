using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCameras : MonoBehaviour {
    public int timer = 0;
    public bool rotateRight = true;
    public bool rotateLeft = false;
    public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //rotate the camera
        RotateCamera();
        //count
        Timer();

        if (timer >= 1000)
        {
            Switch();
        }
	}

    int Timer()
    {
        timer++;
        return timer;
    }

    void Switch()
    {
        if(rotateRight)
        {
            rotateRight = false;
            rotateLeft = true;
            timer = 0;
        }
        else if(rotateLeft)
        {
            rotateLeft = false;
            rotateRight = true;
            timer = 0;
        }
    }

    void RotateCamera()
    {
        if (rotateRight)
        {
            transform.Rotate(transform.up * (Time.deltaTime * 10));
        }
        if (rotateLeft)
        {
            transform.Rotate(transform.up * -(Time.deltaTime * 10));
        }
    }

   /* private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player entered trigger area"); //Output to console that player has entered collider
        if (player) //if player enters collider
        {
            Physics.Raycast
        }
    }*/
}
