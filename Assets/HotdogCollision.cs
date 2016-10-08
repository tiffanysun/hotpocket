using UnityEngine;
using System.Collections;

// whenever a collider(also a trigger enters bear obj 
public class HotdogCollision : MonoBehaviour {
		
	//triggers collision on other object (rigid body),
	//we want to alert the other object that it hit them. 
	//we need to set bullet to isTrigger and collider on bear 
		void OnTriggerEnter(Collider other)
		{
			//bear is looking for hotdogs that hit it, and then destroys itself.
			if (other.gameObject.tag == "dog") 
			{ 
				float delay = .2f; 
				Debug.Log (this.gameObject.name); //logs the bears name

				//plays the audio clip where the bear is at
				AudioSource.PlayClipAtPoint(this.gameObject.GetComponent<AudioSource>().clip, transform.position);

				//this.gameObject.audio.PlayDelayed(delay-.1f);
				// reversing velocity (rigidbody off the hotdog and getting velocity of that and reverses it

				other.gameObject.GetComponent<Rigidbody>().velocity = -(.3f)*other.gameObject.GetComponent<Rigidbody>().velocity;

				//it will destroy the bear in 3 seconds. 
				Destroy(this.gameObject, delay); 
			}
		}
}

//hotdogToThrow (transform.position, player.transform.position) < 1f) {
	//Application.LoadLevel (Application.loadedLevel);
// }