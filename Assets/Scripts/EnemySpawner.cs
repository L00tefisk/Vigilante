using UnityEngine;
using System;
using System.Reflection;
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
		
		Level level1 = parser.Deserialize<Level>("newlevel");
		levelList.Add(level1);
		//ImportLevels();
		
		StartCoroutine(processLevel());
		
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	private IEnumerator processLevel() {
		int startTime = (int)Time.time;
		while(true) 
		{
			Level currentLevel = levelList[0];
			
			if (once == 1) {
				currentLevel.Print();
				once = 0;
			}
			
			time = (int)Time.time - startTime;
			
			if (waveIndex < currentLevel.Waves.Count && time >= currentLevel.Waves[waveIndex].time) 
			{
				Level.Wave wave = currentLevel.Waves[waveIndex];
				//Type t = Type.GetType(wave.enemytype);
				
				Type typeArgument = Type.GetType("Type From DB as String", true, true);
				Type template = typeof(MyClass<>);
				Type genericType = template.MakeGenericType(typeArgument);
				object instance = Activator.CreateInstance(genericType);
				
				Type t = typeof(Seedling);
				
				Utils.spawnEnemy<Seedling>(t, wave.enemytype, new Vector3(transform.position.x + (i * 2), 0, 0), wave.moveset);
				/*
				switch (wave.formation) 
				{
					case Level.Formation.Line:
						for (int i = 0; i < wave.amount; i++) {
							Utils.spawnEnemy<Seedling>(t, wave.enemytype, new Vector3(transform.position.x + (i * 2), 0, 0), wave.moveset);
							yield return new WaitForSeconds(0.2f);
						}
						break;
					case Level.Formation.Circle:
						for (int i = 0; i < wave.amount; i++) {
							float x = 2 * Mathf.Sin(2 * Mathf.PI/wave.amount * i) + transform.position.x;
							float y = 2 * Mathf.Cos(2 * Mathf.PI/wave.amount * i);
							Utils.spawnEnemy<Seedling>(t, wave.enemytype, new Vector3(x, y, 0), wave.moveset);
						}
						break;
					case Level.Formation.Square:
						Utils.spawnEnemy(t, wave.enemytype, new Vector3(transform.position.x - 1, -1, 0), wave.moveset);
						Utils.spawnEnemy(t, wave.enemytype, new Vector3(transform.position.x - 1, +1, 0), wave.moveset);
						Utils.spawnEnemy(t, wave.enemytype, new Vector3(transform.position.x + 1, -1, 0), wave.moveset);
						Utils.spawnEnemy(t, wave.enemytype, new Vector3(transform.position.x + 1, +1, 0), wave.moveset);
						break;
					default:
						Utils.spawnEnemy(t, wave.enemytype, new Vector3(transform.position.x, UnityEngine.Random.Range(-7, 7), 0), wave.moveset);
						break;
				}*/
				waveIndex++;
			}
			yield return null;
		}
	}
}
