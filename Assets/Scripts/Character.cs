﻿using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour {
	protected int Speed;
	protected float HP;
	protected float Rotation;
	protected bool IsAlive = true;

	protected virtual void Start () {}

	protected virtual void Update () {}

	protected void Damage(float damage) {
		HP -= damage;
		
		if (HP <= 0 && IsAlive)
			Kill();
	}
	protected abstract void Kill();

	protected void Nuke() {
		Destroy(this.gameObject);
	}
}