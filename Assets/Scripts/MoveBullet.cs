using UnityEngine;
using System.Collections;

public class MoveBullet : MonoBehaviour {
  	int speed;
  	Vector2 rotationModifier;
  	
	void Start () {
    	speed = 20;
  	}
	// Update is called once per frame
	void Update () {
		rotationModifier = speed * new Vector2(Mathf.Cos(transform.rotation.z *100 * (Mathf.PI / 180)), 
		                               		   Mathf.Sin(transform.rotation.z *100 * (Mathf.PI / 180)));
		                               		   
		transform.position = (Vector2)transform.position + rotationModifier * Time.deltaTime;
		//rigidbody2D.AddForce(new Vector2(speed * Time.deltaTime, 0));
	}
}