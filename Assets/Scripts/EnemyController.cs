using UnityEngine;
using System.Collections;

public class EnemyController : Character {
	private Animator anim;
	Vector2 velmod;
	// Use this for initialization
	public override void Start () {
		_isAlive = true;
		_speed = 20;
		_hp = 50;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	public override void Update () {
		velmod = Utils.getVelocityModifier(transform.localEulerAngles.z-180);
		rigidbody2D.AddForce(_speed * velmod * 40 * Time.deltaTime);

		if (rigidbody2D.position.x < -20) {
			Nuke();
		}
	}
	public override void Kill () {
		_isAlive = false;
		rigidbody2D.gravityScale = 1;
		anim.SetTrigger("Die");
		Invoke ("Nuke", 3);
		GetComponent<PolygonCollider2D>().enabled = false;
	}
}
