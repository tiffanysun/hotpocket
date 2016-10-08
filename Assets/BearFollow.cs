using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// Bear follow is attached to the bear enemy's game object
/// </summary>
public class BearFollow : MonoBehaviour 
{

	public GameObject player;
	/// <summary>
	/// The bear move rate per second
	/// </summary>
	public float bearMoveRate = 1f;
	public float bearViewDistance = 5f;
	public bool toggleChasingPlayer = false ; 
	public Rigidbody rb;

	/// <summary>
	/// The view ray looking forward to spot players
	/// </summary>
	public Ray viewRay; 

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame



	void Update()
	{
		// the ray to be used to raycast
		viewRay = new Ray (transform.position, transform.forward);
		// the hit to contain the results of the raycast
		RaycastHit hit = new RaycastHit();

		if ( Physics.Raycast( viewRay, out hit ) )
		{
			//we hit something, but what was it...? 
			if (hit.transform.tag == "Player") {
				//now we know it is the player 
				// we want to know if it's within the viewing distance 
				toggleChasingPlayer = true; 
				transform.LookAt (player.transform);
			} else {
				toggleChasingPlayer = false; 
			}
		}
		else
		{
			toggleChasingPlayer = false; 
		}

		if (toggleChasingPlayer) 
		{
			Vector3 direction = player.transform.position - transform.position;

			// this levels out the bear and prevents it from sinking in the ground. 
			direction = new Vector3 (direction.x, transform.position.y, direction.z);  
			transform.Translate( direction * bearMoveRate * Time.deltaTime); //moving towards the player at a certain rate 

			// if the bear touches player, the player will respawn/ restart the game 
			if (Vector3.Distance (transform.position, player.transform.position) < 1f) {
				Application.LoadLevel (Application.loadedLevel);
			}
			/*
			Vector3 x = transform.position - player.transform.position;
			x.Normalize ();
			rb.AddForce (-x * bearMoveRate, ForceMode.Force);
			*/
		}
	}
}

