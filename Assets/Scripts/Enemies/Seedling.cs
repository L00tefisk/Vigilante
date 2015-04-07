using UnityEngine;
using System.Collections;

public class Seedling : Enemy {
	Vector2 velmod;
	// Use this for initialization
	protected override void Start () {
		startY = transform.position.y;
		if (Mathf.Abs(startY) > 0) 
			maxY = 3 / Mathf.Abs(startY); //Makes the enemy move less if its spawns close to boundaries of the screen
		rigidbody2D = GetComponent<Rigidbody2D>();
		damageSound = (AudioClip)Resources.Load("Sounds/impact-knova");
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
			rigidbody2D.MovePosition(new Vector2 (rigidbody2D.position.x - (0.01f * Speed), startY + Mathf.Sin(Lifetime * 1.5f) * maxY));
		
		if (rigidbody2D.position.x < -20) {
			Nuke();
		}
	}
}
