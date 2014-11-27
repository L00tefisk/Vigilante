using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public int _speed;
	private float _RSP;
	private float _rotation;
	private float _cm;
	private float _rp;
	private float _maxRot;
	private Vector2 distance;
	private Vector2 mousePos;
	
	// Use this for initialization
	void Start () {
		_speed = 10;//Max speed = 100 (Same speed as mouse);
		_maxRot = 85f;
		_RSP = _speed * (5 / 3); //Rotation Speed
	}
	
	// Update is called once per frame
	void Update () {
		
		//Gets mouse position
		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,0, (transform.position - Camera.main.transform.position).z));
		
		//Calculates distance between plane and cursor
		distance = new Vector2 (mousePos.x - transform.position.x, mousePos.y - transform.position.y);
		

		_cm = (distance.y * _RSP);
		//Sets a rotation limit for the plane, the double variables prevent the plane's rotation from changing when over the limit
		if (_rp < -_maxRot)
		{
			_rp = _cm;
			_rotation = -_maxRot;
		}
		else if (_rp > _maxRot)
		{
			_rp = _cm;
			_rotation = _maxRot;
		}
		else
		{
			_rotation = _cm;
			_rp = _cm;
		}
		
		//Moves plane according to distance
		rigidbody2D.MovePosition(rigidbody2D.position + (distance * _speed) * Time.deltaTime);
		
		rigidbody2D.MoveRotation(_rotation);
	}
}

