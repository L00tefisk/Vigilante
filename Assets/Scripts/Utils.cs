using UnityEngine;
using System;
using System.Collections;

public class Utils : MonoBehaviour {
	
	public static void spawnObject(String objName, Vector3 position, float rotation) {
		GameObject instance = (GameObject)Instantiate(Resources.Load(objName));
		instance.transform.position = new Vector3(position.x, position.y, 0);
		instance.transform.Rotate(new Vector3(0, 0, rotation));
	}
}
