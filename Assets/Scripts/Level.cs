using UnityEngine;
using System.Collections.Generic;

public class Level
{
	//Everything has to be public for XML Serialization to work
	public string map  { get; private set; }
	public List<Wave> Waves { get; private set; }
	
	public enum Pattern
	{
		Line,
		Square,
		Circle
	}
	//May the gods have mercy
	public struct Wave
	{
		public int time;
		public string enemytype;
		public int amount;
		public Pattern pattern;
	}
	
	public Level()
	{
		Waves = new List<Wave>();
	}
	
	public void addToWaveList(Wave wave)
	{
		this.Waves.Add(wave);
	}
 	
	public void addToWaveList(int time, string enemytype, int amount, Pattern pattern)
	{
		Wave wave = new Wave();
		wave.time = time;
		wave.enemytype = enemytype;
		wave.amount = amount;
		wave.pattern = pattern;
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
				"\n\tFormation: " + wave.pattern.ToString()
			);
		}
	}
}
