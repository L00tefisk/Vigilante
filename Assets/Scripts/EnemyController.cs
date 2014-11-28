using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	int speed;
	int hp;
	// Use this for initialization
	void Start () {
		speed = 10;
		hp = 100;
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody2D.AddForce(new Vector2(-1, 0) * speed * 10 * Time.deltaTime);
		
		if (hp <= 0) {
			Kill();
		}
	}
	
	void Damage (int damage) {
		hp -= damage;
	}
	void Kill () {
		Destroy(this.gameObject);
	}
}
