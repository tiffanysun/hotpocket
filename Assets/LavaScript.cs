using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LavaScript : MonoBehaviour {

	// Use this for initialization
	// void Start () {
	void OnTriggerEnter (Collider other)
	{
		Debug.Log (other.gameObject.name);
		SceneManager.LoadScene("level1");
}
	}

	// Update is called once per frame
	// void Update () {
	
	//}
// }
