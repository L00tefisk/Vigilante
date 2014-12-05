using UnityEngine;
using System.Collections;

public class Seedling : Enemy {
	Vector2 velmod;
	// Use this for initialization
	protected override void Start () {
		Lifetime = 0;
		CollisionDamage = 10;
		Essence = 10;
		Speed = 10;
		HP = 30;
		Anim = GetComponent<Animator>();
	}
	
	
	// Update is called once per frame
	protected override void Update () {
		Lifetime += Time.deltaTime;
		//velmod = Utils.getVelocityModifier(transform.localEulerAngles.z-180);
		//rigidbody2D.AddForce(_speed * velmod * 40 * Time.deltaTime);
		if (IsAlive)
			rigidbody2D.MovePosition(new Vector2 (rigidbody2D.position.x - (0.01f * Speed), rigidbody2D.position.y + (Mathf.Sin(Lifetime) / 30)));
			
		if (rigidbody2D.position.x < -20) {
			Nuke();
		}
	}
}
