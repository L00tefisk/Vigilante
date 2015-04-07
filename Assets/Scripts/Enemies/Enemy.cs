using UnityEngine;
using System.Collections;

public class Enemy : Character {
	protected int Essence;
	protected int CollisionDamage;
	protected float Lifetime;
	protected float startY;
	protected float maxY;
	protected Animator Anim;
	
	protected override void Kill () {
		IsAlive = false;
		GetComponent<Rigidbody2D>().gravityScale = 1;
		UImanager.Score += Essence;
		Anim.SetTrigger("Die");
		Invoke ("Nuke", 3);
		
		foreach(Collider2D coll in GetComponents<Collider2D>())
			coll.enabled = false;
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			coll.gameObject.SendMessage("Damage", CollisionDamage);
			Kill();
		}
	}
}
