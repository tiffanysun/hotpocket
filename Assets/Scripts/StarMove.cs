using UnityEngine;
using System.Collections;

public class StarMove : MonoBehaviour {

    private Rigidbody rb;
    public float moveSpeed = 10f;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = -Vector3.forward * moveSpeed;
    }


    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Hand"))
        {
            Destroy(this.gameObject, 5f);
        }
        
    }


}
