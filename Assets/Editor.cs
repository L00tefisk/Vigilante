using UnityEngine;
using System.Collections.Generic;

public class Editor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Level level = new Level();
		Level.Wave wave = new Level.Wave();
		wave.amount = 4;
		wave.enemytype = "Seedling";
		wave.formation = Level.Formation.Line;
		wave.time = 5;
		
		wave.moveset = new List<Level.Move>();
		Level.Move set = new Level.Move("Line", 1);
		wave.moveset.Add(new Level.Move("Circle", 3));
		wave.moveset.Add(new Level.Move("Wait", 1)); 
		wave.moveset.Add(new Level.Move("Sine", 2));
		
		
		level.addToWaveList(wave);
	
		XMLParser parser = new XMLParser("");  
		parser.Serialize(level, "newlevel");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}