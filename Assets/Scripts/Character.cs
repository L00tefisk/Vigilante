using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour {
	public int _speed;
	public float _hp;
	public float _rotation;
	public bool _isAlive;

	public abstract void Start ();

	public abstract void Update ();

	public void Damage(float damage) {
		_hp -= damage;
		
		if (_hp <= 0 && _isAlive)
			Kill();
	}
	public abstract void Kill();

	public void Nuke() {
		Destroy(this.gameObject);
	}
}
