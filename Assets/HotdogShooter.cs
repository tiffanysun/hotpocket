using UnityEngine;
using System.Collections;

public class HotdogShooter : MonoBehaviour {
	public float thrust; 
	public GameObject hotdogToThrow;

	public float bulletSpeed = 1000.0f;
	public float shotInterval = 0.5f;
	// you need to make a prefab out of a projectile and assign it to this
	// dragging it into 'bullet prefab in inspector in Unity
	// prefab == gameobj (remove rigid body because it's a game obj, because you can't instantiate a component ) 
	public GameObject bulletPrefab;

	private float shootTime = 0.0f;
	private Transform bulletSpawn;

	int hotdogs = 10;
	public void ShootDog()
	{
		if (Time.time >= shootTime)
		{  //we cast the instantiate obj to GameObj
			hotdogToThrow = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

			//it gets rigid body and adds force to it 
			hotdogToThrow.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);

			//delay in shooting so you can't fire and lose all your ammo 
			shootTime = Time.time + shotInterval;
			hotdogs--;
		}
	}

	// Use this for initialization
	void Start () {
		// You need to parent a game object called bulletSpawn to the player where you want bullets to appear
		bulletSpawn = transform.Find ("hotdogSpawn");    

		//loops through all children transforms of  the game object
		foreach (Transform child in transform) { 
			if (child.gameObject.tag == "dog")
				hotdogToThrow = child.gameObject;  
		}
	}
	
	// Update is called once per frame
	void Update () {
		//if person hits the Button add force to shoot hotdog
		if (Input.GetMouseButtonDown(0))
				if (hotdogs > 0) { 
					ShootDog(); 
				}
			}
	}

