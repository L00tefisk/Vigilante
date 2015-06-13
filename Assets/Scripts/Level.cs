using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

public class Level
{
	//Everything has to be public for XML Serialization to work
	public string map  { get; private set; }
	public List<Wave> Waves { get; private set; }
	//May the gods have mercy
	
	public enum Formation
	{
		Line,
		Square,
		Circle
	}
	/*
	public enum Motion
	{
		Line,
		Circle,
		Sine,
		Wait
	}*/

	public struct Move
	{
		[XmlText]
		public string motion;
		
		[XmlAttribute]
		public int duration;
		
		public Move (string motion, int duration) {
			this.motion = motion;
			this.duration = duration;
		}
	}
	
	public struct Wave
	{
		public int time;
		public string enemytype;
		public int amount;
		public Formation formation;
		public List<Move> moveset;
	}
	
	public Level()
	{
		Waves = new List<Wave>();
	}
	
	public void addToWaveList(Wave wave)
	{
		this.Waves.Add(wave);
	}
 	
	public void addToWaveList(int time, string enemytype, int amount, Formation formation)
	{
		Wave wave = new Wave();
		wave.time = time;
		wave.enemytype = enemytype;
		wave.amount = amount;
		wave.formation = formation;
		this.Waves.Add(wave);
	}

	public List<Wave> getWaveList()
	{
		return this.Waves;
	}

	public void Print()
	{
		Debug.Log(map);
		foreach (Wave wave in this.Waves)
		{
			Debug.Log("Wave " + (Waves.IndexOf(wave) + 1) + 
				"\n\tTime: " + wave.time + 
				"\n\tEnemy: " + wave.enemytype +
				"\n\tAmount: " + wave.amount +
			    "\n\tFormation: " + wave.formation.ToString()
			);
		}
	}
	
	
	/*
	[XmlEnum("Line")]Line,
	[XmlEnum("Circle")]Circle,
	[XmlEnum("Sine")]Sine,
	[XmlEnum("Wait")]Wait
	*/
}
