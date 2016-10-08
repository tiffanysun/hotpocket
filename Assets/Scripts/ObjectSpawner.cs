using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour {

    public GameObject enemyCube;

    private float cooldownTime = 3f;
    private float coolDown = 3f;

    public float numWaves = 1;

    
    // Update is called once per frame
    void Update()
    {
        cooldownTime -= Time.deltaTime;
        if (cooldownTime <= 0)
        {
            cooldownTime = coolDown;
            cubeSpawnEvent();
        }
    }

    private void cubeSpawnEvent()
    {        
        int length = GameManager.instance.cubeNum;
        if (length % 3 == 0) numWaves++;
        for (int i = 0; i < numWaves; i++)
        {
            float rngSpeed = Random.Range(1, 10);
            SpawnCube(rngSpeed);
        }
        GameManager.instance.cubeNum++;
    }


    public void SpawnCube(float rngSpeed)
    {
        float newX = Random.Range(-1f, 1f);
        float newY = Random.Range(.3f, 1.5f);
        GameObject cube = Instantiate(enemyCube, new Vector3(newX, newY, transform.position.z), Quaternion.identity) as GameObject;
        cube.GetComponent<StarMove>().moveSpeed = rngSpeed;
    }
}
