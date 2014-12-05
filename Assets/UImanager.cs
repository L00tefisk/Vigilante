using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UImanager : MonoBehaviour {
	private GameObject playerobj;
	private GameObject HPbar;
 	public static int Score;
 	private float _hp;
 	
	void Start () {
		HPbar = GameObject.Find("Canvas/hpbar/hpbar_fill");
		Score = 0;
	}
	
	void Update () {
		playerobj = GameObject.FindWithTag("Player");
		_hp = playerobj.GetComponent<PlayerControl>().getHP();
		HPbar.transform.localScale = new Vector3(Mathf.Clamp(_hp * 1.012f / 100, 0, 1.012f), 1);
		HPbar.GetComponent<Image>().color = new Color(1,(_hp) / 100, 1);
		GetComponentInChildren<Text>().text = "Essence: " + Score;
		
  }
}
