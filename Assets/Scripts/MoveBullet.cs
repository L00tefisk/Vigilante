using UnityEngine;
using System.Collections;

public class MoveBullet : MonoBehaviour {
	private int damage;
  	private int speed;
  	Vector2 rotationModifier;
  	
	void Start () {
		damage = 3;
    	speed = 20;
  	}
	// Update is called once per frame
	void Update () {
		rotationModifier = new Vector2(Mathf.Cos(transform.rotation.z *100 * (Mathf.PI / 180)), 
		                               Mathf.Sin(transform.rotation.z *100 * (Mathf.PI / 180)));
		                               		   
		transform.position = (Vector2)transform.position + rotationModifier * speed * Time.deltaTime;
		//rigidbody2D.AddForce(new Vector2(speed * Time.deltaTime, 0));
		if (!renderer.isVisible) {
			Destroy(this.gameObject);
		}
		
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Enemy")
			coll.gameObject.SendMessage("Damage", damage);
		
		Destroy(this.gameObject);
	}
}