using UnityEngine;
using System.Collections.Generic;

public class Utils : MonoBehaviour {
	private static GameObject player = GameObject.FindGameObjectWithTag("Player");
	
	public static GameObject getPlayerObject() {
		return player;
	}
	
	public static void spawnObject(string objName, Vector3 position, float rotation) {
		GameObject instance = (GameObject)Instantiate(Resources.Load("Prefabs/"+objName));
		instance.transform.position = new Vector3(position.x, position.y, 0);
		instance.transform.Rotate(new Vector3(0, 0, rotation));
	}
	
	public static void spawnEnemy<T>(T obj, string objName, Vector3 position, List<Level.Move> moveset) where T : Enemy {
		obj = (T)Instantiate(Resources.Load("Prefabs/"+objName));
		obj.SetMoveset(moveset);
		
		//instance = (T)instance;
		obj.transform.position = new Vector3(position.x, position.y, 0);
	}

	//To make objects move according to their rotation
	public static Vector2 getVelocityModifier (float localEulerAnglesAxis) { //for instance transform.localEulerAngles.z
		float rotation = localEulerAnglesAxis  * (Mathf.PI / 180);
		return new Vector2(Mathf.Cos(rotation), Mathf.Sin(rotation)); 
	}
}