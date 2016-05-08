﻿using UnityEngine;
using System.Collections;



public class MoleBehaviour : MonoBehaviour
{
	public float _initY;

	public AudioClip impact;
	AudioSource audio;


    void Start()
    {
        // Remember initial position
        _initY = transform.position.y;

		audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Tag mole object according to its position

        // Arrived its initial position?
        if (transform.position.y >= _initY)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.tag = "aboveGround";

			//test this
			//Debug.Log("going underground");
        }

//        // Underneath ground?
//		if (GetComponent<BoxCollider>().bounds.max.y < 0)
//        {
//            gameObject.tag = "underGround";
//        }
    }

    void OnTriggerEnter(Collider col)
    {
		
        if (gameObject.tag == "aboveGround")
        {
			audio.PlayOneShot(impact, 0.7F);
            // Mole falls down when it is hit by collider
            GetComponent<Rigidbody>().useGravity = true;
            gameObject.tag = "movingDown";

			gameObject.tag = "underGround";

        }
    }
}
