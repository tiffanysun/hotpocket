using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	// void Start () {
	void OnTriggerEnter (Collider other)
	{
		Debug.Log (other.gameObject.name);
		Application.LoadLevel ("level1");
}
	}

	// Update is called once per frame
	// void Update () {
	
	//}
// }
