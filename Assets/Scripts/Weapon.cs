using UnityEngine;
using System.Collections;

public class Weapon 
{
	private string name;
	private float fireRate;
	private int accuracy;
	private float fire_reshoot_track = 0f;
	//private Bullet bulletType;
	
	private bool isShooting = true;
	private float delay = 0;
	
	public Weapon (string name, float fireRate, int accuracy) 
	{
		this.name = name;
		this.fireRate = 60 / fireRate;
		this.accuracy = accuracy;
		//this.bulletType = bulletType;
	}
	
	public void Shoot(Vector2 position, float rotation) 
	{	
		if (fire_reshoot_track < Time.time)
		{
			float random = (100  - accuracy) * 0.90f;
			Debug.Log("Shooting " + name);
			Utils.spawnObject(name, position, rotation + Random.Range(-random, random));
			fire_reshoot_track = Time.time + fireRate;
		}
		/*while (isShooting) {
      		float random = (100  - accuracy) * 0.90f;
			if (delay > 1000) {
				Debug.Log("Shooting " + name);
				//Utils.spawnObject(name, position, rotation + Random.Range(-random, random));
				delay = 0;
			}
			delay += Time.deltaTime * 1000;
		}*/
	}
}

