using UnityEngine;
using System.Collections;

public class MoveBullet : MonoBehaviour {
	private int damage = 15;
  	public int speed = 20;
  	private float rotation;
  	Vector2 velocityModifier;
  	
	void Start () {
  	}
	// Update is called once per frame
	void Update () {           		   
		transform.position = (Vector2)transform.position + speed * Utils.getVelocityModifier(transform.localEulerAngles.z) * Time.deltaTime;
		//rigidbody2D.AddForce(new Vector2(speed * Time.deltaTime, 0));
		if (!renderer.isVisible) {
			Destroy(this.gameObject);
		}
		
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Enemy") {
			coll.gameObject.SendMessage("Damage", damage);
			Utils.spawnObject("hitParticles", transform.position, transform.rotation.z-180);
			Destroy(this.gameObject);
		}
	}
}