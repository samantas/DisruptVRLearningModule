using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Carnival;

public class FingertipSampleBehaviour : MonoBehaviour
{
	public GameObject stickPrefab;
	// A stick object with collider to hit moles

	private Controller _carnivalController;
	// Controller to access frame data

	// Use this for initialization
	void Start()
	{
		// Initialize controller
		Debug.Log("FingertipSampleBehaviour: Initializing sensor");
		_carnivalController = new Controller();
		_carnivalController.Init();
		_carnivalController.Start();

		// instantiate sticks
		// if there are no hands in scene, make sticks invisible
		// instead of instantiating so many times...


	}

	// Update is called once per frame
	void Update()
	{
		foreach(GameObject stick in GameObject.FindGameObjectsWithTag("stick"))
		{
			Destroy(stick);
		}

		// Get the current frame
		Frame frame = _carnivalController.Frame();

		// Fingertips are always linked to a certain Hand.
		foreach(Hand hand in frame.Hands)
		{
			// instead of foreach
			// check if hand.Fingertips.count > 0
			//if (hand.Fingertips.Count > 0) {

			//}
			// ..
			foreach(Fingertip tip in hand.Fingertips)
			{
				GameObject stick = Instantiate(stickPrefab) as GameObject;

				stick.transform.parent = Camera.main.transform;
				stick.transform.parent.rotation = Camera.main.transform.rotation;

			
				// 3D loaction of fingertip is relative position to sensor. Here we keep it simple since sensor is mounted
				// quite close to your eyes which is main camera. 
				// For better UX you should actually take the distance into account
				stick.transform.localPosition = tip.Center3D;

			}
		}
	}

	void OnDestroy()
	{
		Debug.Log("FingertipSampleBehaviour: OnDestroy");
		_carnivalController.Stop();
	}

	void OnApplicationPause(bool pauseStatus)
	{
		if(_carnivalController == null)
		{
			return;
		}

		Debug.Log("FingertipSampleBehaviour: OnApplicationPause -> " + pauseStatus);

		if(pauseStatus)
		{
			_carnivalController.Stop();
		}
		else
		{
			_carnivalController.Start();
		}
	}
}
