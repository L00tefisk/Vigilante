using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


public class XMLParser : MonoBehaviour
{	
	private string projectPath;
	
	void Start()
	{ 
		string projectPath = Application.dataPath + "/Levels/";
		
		if (projectPath != "") {
			Debug.Log("Running in "+projectPath);
			Level level = Deserialize("test");
			Serialize(level, "test2");
			Debug.Log("Success!");
		}
		//ImportLevels();
	}
	
	public void TypeSerialize(System.Object obj, string filename) 
	{
		Type t = obj.GetType();
		string filePath = projectPath + filename + ".xml";
		XmlSerializer serializer = new XmlSerializer(t);
		
		TextWriter writer = new StreamWriter(filePath);
		
		Debug.Log("Serializing " + filePath);
		serializer.Serialize(writer, obj);
		writer.Close();
  }
  
  
  public Level Deserialize(string filename) //Returns a deserialized object.
	{ 
		string filePath = projectPath + filename + ".xml";
		XmlSerializer serializer = new XmlSerializer(typeof(Level));
		
		// A FileStream is needed to read the XML document.
		FileStream fileStream = new FileStream(filePath, FileMode.Open);
		Debug.Log("Deserializing " + filePath);
		
		XmlReader reader = XmlReader.Create(fileStream);
		
		// Declare an object variable of the type to be deserialized.
		Level i;
		
		// Use the Deserialize method to restore the object's state.
		i = (Level)serializer.Deserialize(reader);
		fileStream.Close();
		return i;
  }
  public void Serialize(Level level, string filename) 
  {
		string filePath = projectPath + filename + ".xml";
    	XmlSerializer serializer = new XmlSerializer(typeof(Level));
    	
		TextWriter writer = new StreamWriter(filePath);
		
		Debug.Log("Serializing " + filePath);
		serializer.Serialize(writer, level);
		writer.Close();
  }
  
	
	public void ImportLevels()
	{
		XmlDocument xmlDoc = new XmlDocument();
		TextAsset text = Resources.Load<TextAsset>("Levels/levels");
		xmlDoc.LoadXml(text.text);
		
		List<Level> levelsList = new List<Level>();
		
		foreach (XmlNode levelNode in xmlDoc.GetElementsByTagName("level"))//XMLNodeList
		{
			XmlNodeList levelNodeContent = levelNode.ChildNodes;
			Level level = new Level();
			foreach (XmlNode item in levelNodeContent) // levels itens nodes.
			{
				if  (item.Name == "map") 
				{
					level.map = item.InnerText;
					Debug.Log("level = " + item.InnerText);
				}
				
				if  (item.Name == "wave") 
				{
					Level.Wave wave = new Level.Wave();
					foreach (XmlNode waveChild in item.ChildNodes) 
					{
						switch (waveChild.Name) 
						{
						case "time":
							int.TryParse(waveChild.InnerText, out wave.time);
							break;
						case "enemytype":
							wave.enemytype = waveChild.InnerText;
							break;
						case "amount":
							int.TryParse(waveChild.InnerText, out wave.amount);
							break;
						case "pattern":
							wave.pattern = (Level.Pattern)Enum.Parse(typeof(Level.Pattern), waveChild.InnerText);
							break;
						}
					}
					level.addToWaveList(wave);
				}
			}
			levelsList.Add(level);
			XmlSerializer ser = new XmlSerializer(typeof(Level));
			TextWriter writer = new StreamWriter("E:/Dokumenter/Development/Unity/Vigilante/Assets/Resources/Levels/test.xml");
			ser.Serialize(writer, level);
			writer.Close();
			level.Print();
		}
	}
}