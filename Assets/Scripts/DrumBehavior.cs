using UnityEngine;
using System.Collections;

public class DrumBehavior : MonoBehaviour
{
	public AudioSource audioSource;
	public AudioClip tom;
	public AudioClip snare;

	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnTriggerEnter(Collider col)
	{
		if (gameObject.tag == "tom") {
			audioSource.Play ();
			audioSource.clip = tom;

		} else if (col.tag == "snare") {
			audioSource.Play ();
			audioSource.clip = snare;
		}
	}
}
