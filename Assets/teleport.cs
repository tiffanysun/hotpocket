using UnityEngine;
using System.Collections;

public class teleport : MonoBehaviour 
{
	public bool restart = false; 
	public string levelToLoad = "Level2"; 
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			if (restart) {
				Application.LoadLevel (Application.loadedLevel); 
			} else { 
				Application.LoadLevel (levelToLoad); 
			}
		}
	}
}