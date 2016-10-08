using UnityEngine;
using System.Collections;

public class WallBehaviour : MonoBehaviour {


    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("EnemyStar"))
        {
            Destroy(col.gameObject);
            GameManager.instance.life -= 1;
        }
    }
}
