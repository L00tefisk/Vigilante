using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	int speed;
	int hp;
	int score;
	private bool isAlive;
	private Animator anim;
	// Use this for initialization
	void Start () {
		isAlive = true;
		speed = 20;
		hp = 100;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody2D.AddForce(new Vector2(-1, 0) * speed * 40 * Time.deltaTime);
		
		if (rigidbody2D.position.x < -20) {
			Nuke();
		}
	}
	void Damage (int damage) {
		hp -= damage;
		
		if (hp <= 0 && isAlive)
			Kill();
		
	}
	void Kill () {
		isAlive = false;
		rigidbody2D.gravityScale = 1;
		anim.SetTrigger("Die");
		Invoke ("Nuke", 3);
	}
	void Nuke() {
		Destroy(this.gameObject);
	}
}
