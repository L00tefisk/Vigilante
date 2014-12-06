using UnityEngine;
using System.Collections;

public class PlayerControl : Character {
	private float _RSP;
	private float _cm;
	private float _rp;
	private float _maxRot;
	private Vector2 distance;
	private Vector2 mousePos;
	private Vector2 spawnPoint;
	private Weapon wep;
	private bool _autoShoot;
	
	// Use this for initialization
	protected override void Start () {
		HP = 100;
		Speed = 10;//Max speed = 100 (Same speed as mouse);
		_maxRot = 85f;
		_RSP = (Speed * (5 / 3) / 1.1f); //Rotation Speed
		spawnPoint = transform.Find("spawnPoint").position;
		
		wep = new Weapon("MG_Bullet", 300, 98);
		_autoShoot = false;
	}
	
	// Update is called once per frame
	protected override void Update () {
		
		//Gets mouse position
		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,0, (transform.position - Camera.main.transform.position).z));
		
		//Calculates distance between plane and cursor
		distance = (mousePos - (Vector2)transform.position);

		_cm = (distance.y * _RSP);
		//Sets a rotation limit for the plane, the double variables prevent the plane's rotation from changing when over the limit
		if (_rp < -_maxRot)
		{
			_rp = _cm;
			Rotation = -_maxRot;
		}
		else if (_rp > _maxRot)
		{
			_rp = _cm;
			Rotation = _maxRot;
		}
		else
		{
			Rotation = _cm;
			_rp = _cm;
		}
		//Moves plane according to distance
		rigidbody2D.MovePosition(rigidbody2D.position + (distance * Speed) * Time.deltaTime);
		rigidbody2D.MoveRotation(Mathf.Clamp(Rotation, -_maxRot, _maxRot));
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

