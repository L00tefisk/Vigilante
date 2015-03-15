using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	private string name;
	private int damage;
	private int speed;
	private float rotation;
	private Vector2 velocityModifier;
	
	public Bullet (int damage, int speed) {
		this.damage = damage;
		this.speed = speed;
	}
	// Update is called once per frame
	void Update () {
		rotation = transform.localEulerAngles.z  * (Mathf.PI / 180);
		velocityModifier = new Vector2(Mathf.Cos(rotation), Mathf.Sin(rotation));                    		   
		transform.position = (Vector2)transform.position + speed * velocityModifier * Time.deltaTime;
		//rigidbody2D.AddForce(new Vector2(speed * Time.deltaTime, 0));
		if (!GetComponent<Renderer>().isVisible) {
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