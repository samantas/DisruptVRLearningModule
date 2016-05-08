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
		//// TOM
		if (!audioSource.isPlaying && gameObject.tag == "tom") {
			audioSource.PlayOneShot (tom);
		} 

		//// SNARE
		if (!audioSource.isPlaying && gameObject.tag == "snare") {
			audioSource.PlayOneShot (snare);

		} 
	}

	IEnumerator waitAndPlay(float waitTime){
		yield return new WaitForSeconds (waitTime);

	}
		

}
