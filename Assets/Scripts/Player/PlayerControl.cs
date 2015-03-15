using UnityEngine;
using System.Collections;

public class PlayerControl : Character {
	private float _RSP;
	private float _maxRotation;
	private Vector2 distance;
	private Vector2 mousePos;
	private Vector2 spawnPoint;
	private Weapon wep;
	private bool _autoShoot;
	
	// Use this for initialization
	protected override void Start () {
		HP = 100;
		Speed = 10;//Max speed = 100 (Same speed as mouse);
		_maxRotation = 85f;
		_RSP = (Speed * (5 / 3) / 1.9f); //Rotation Speed
		spawnPoint = transform.Find("spawnPoint").position;
		
		wep = new Weapon("MG_Bullet", 400, 98);
		_autoShoot = false;
	}
	
	// Update is called once per frame
	protected override void Update () {
		
		//Gets mouse position
		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,0, (transform.position - Camera.main.transform.position).z));
		
		//Calculates distance between plane and cursor
		distance = (mousePos - (Vector2)transform.position);

		Rotation = distance.y * _RSP;
		//Moves plane according to distance
		GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + (distance * Speed) * Time.deltaTime);
		
		GetComponent<Rigidbody2D>().MoveRotation(Mathf.Clamp(Rotation, -_maxRotation, _maxRotation));
		
		if (Input.GetKeyDown(KeyCode.A))
			_autoShoot = !_autoShoot;
		    
		if (Input.GetMouseButton(0) || _autoShoot) {
			wep.Shoot((Vector2)(transform.position) + spawnPoint, Rotation);
		}
	}
	public int getHP () {
		return Mathf.FloorToInt(HP);
	}
	
	protected override void Kill () {
		//Invoke ("Nuke", 3);
	}
	
}

