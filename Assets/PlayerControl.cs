using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	private double _speed;
	private double _RSP;
	private double _yDis;
	private double _xDis;
	private double _rotation;
	private double _cm;
	private double _rp;
	private float _maxRot = 85f;
	private double mouseX;
	private double mouseY;
	private double TGX;
	private double TGY;
	
	
	// Use this for initialization
	void Start () {
		_maxRot = (float)Mathf.Deg2Rad(_maxRot);//Converts the initial value to radians
		_speed = 20;//Max speed = 100 (Same speed as mouse);
		_RSP = _speed * (5 / 3); //Rotation Speed
	}
	
	// Update is called once per frame
	void Update () {
		mouseX = Input.mousePosition.x;
		mouseY = Input.mousePosition.y;
		_cm = (_yDis / 100 * _RSP) *  Mathf.Deg2Rad;
		
		//Sets a rotation limit for the plane, the double variables prevent the plane's rotation from changing when over the limit
		if (_rp < -_maxRot)
		{
			_rp = (float)_cm;
			_rotation = -_maxRot;
		}
		else if (_rp > _maxRot)
		{
			_rp = (float)_cm;
			_rotation = _maxRot;
		}
		else
		{
			_rotation = _rp;
			_rp = _cm;
		}
		
		//Calculates center of plane (for mouse movement)
		TGX = mouseX - (collider.bounds.size.x / 3);
		TGY = mouseY - (collider.bounds.size.x / 2);
		
		//Calculates distance between plane and cursor
		_xDis = TGX - transform.position.x;
		_yDis = TGY - transform.position.y;
		
		
		//Moves plane according to distance
		transform.position.x += (float)(_xDis / 100 * _speed);
		transform.position.y += (float)(_yDis / 100 * _speed);
		//transform.rotation = _rotation;
	}
}

