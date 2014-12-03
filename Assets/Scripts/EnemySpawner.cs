using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
  	int time;
  	int spawnDelay;
	// Use this for initialization
	void Start () {
	    spawnDelay = 1000;
		time = spawnDelay;
	}
	
	// Update is called once per frame
	void Update () {
        time += (int)(Time.deltaTime * 1000);
      	if (time >= spawnDelay) {
      		time = 0;
			Utils.spawnObject("Enemy", new Vector3(transform.position.x, Random.Range(-5, 5), 0), Random.Range(-20, 20));
      	}
	}
}
