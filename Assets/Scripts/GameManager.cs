using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public int life = 10;
    public int cubeNum = 0;
    public static GameManager instance;

    public bool fireOnce = false;

    // Use this for initialization
    void Start () {
        instance = this;
    }
	
	// Update is called once per frame
	void Update () {
        if(life <= 0)
        {
            //end game
            if(!fireOnce)
            {
                SceneManager.LoadScene(0);
                fireOnce = true;
            }

        }
	}
}
