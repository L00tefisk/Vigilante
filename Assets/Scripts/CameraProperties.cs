using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class CameraProperties : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.showCursor = false;
		GetComponent<Camera>().transparencySortMode = TransparencySortMode.Orthographic;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
