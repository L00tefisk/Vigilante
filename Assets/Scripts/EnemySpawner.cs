using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class EnemySpawner : MonoBehaviour {
	private double time;
	private int waveIndex;
	private int once = 1;
	
	private string assetPath;
	private string projectPath;
	private List<Level> levelList = new List<Level>();
  	
	// Use this for initialization
	void Start () {
		waveIndex = 0;
		time = 0;
		
		XMLParser parser = new XMLParser("/Resources/Levels/");
		
		Level level1 = parser.Deserialize<Level>("test");
		levelList.Add(level1);
		//ImportLevels();
	}
	
	// Update is called once per frame
	void Update () {
		
		Level currentLevel = levelList[0];
		
		if (once == 1) {
			currentLevel.Print();
			once = 0;
		}
		
		time += (Time.deltaTime);
        
		if (waveIndex < currentLevel.Waves.Count && time >= currentLevel.Waves[waveIndex].time) 
		{
			Level.Wave wave = currentLevel.Waves[waveIndex];
			
			switch (wave.pattern) 
			{
				case Level.Pattern.Line:
					for (int i = 0; i < wave.amount; i++)
						Utils.spawnObject(wave.enemytype, new Vector3(transform.position.x + (i * 2), 0, 0), 0);
					break;
				case Level.Pattern.Circle:
					break;
				case Level.Pattern.Square:
					Utils.spawnObject(wave.enemytype, new Vector3(transform.position.x - 1, -1, 0), 0);
					Utils.spawnObject(wave.enemytype, new Vector3(transform.position.x - 1, +1, 0), 0);
					Utils.spawnObject(wave.enemytype, new Vector3(transform.position.x + 1, -1, 0), 0);
					Utils.spawnObject(wave.enemytype, new Vector3(transform.position.x + 1, +1, 0), 0);
					break;
				default:
					Utils.spawnObject(wave.enemytype, new Vector3(transform.position.x, Random.Range(-7, 7), 0), 0);
					break;
			}
			waveIndex++;
      	}
	}
}
