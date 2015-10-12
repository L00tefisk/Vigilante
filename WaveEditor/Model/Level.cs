using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System;
using System.Windows;

public class Level
{
    public string map { get; private set; }
    public ObservableCollection<Wave> Waves { get; set; }

    public enum Formation
    {
        Line,
        Square,
        Circle
    }

    public enum Motion
    {
        Line,
        Circle,
        Sine,
        Wait
    }
    public enum EnemyType
    {
        Seedling
    }
    public struct Move
    {
        public Motion motion { get; set; }
        public int duration { get; set; }

        public Move(Motion motion, int duration)
        {
            this.motion = motion;
            this.duration = duration;
        }
    }

    //May the gods have mercy
    public struct Wave
    {
        public int time { get; set; }
        public EnemyType enemyType { get; set; }
        public int amount { get; set; }
        public Formation formation { get; set; }
        public List<Move> moveset { get; set; }
    }

    public Level()
    {
        Waves = new ObservableCollection<Wave>();
    }

    public void addToWaveList(Wave wave)
    {
        this.Waves.Add(wave);
    }

    public void addToWaveList(int time, EnemyType enemyType, int amount, Formation formation)
    {
        Wave wave = new Wave();
        wave.time = time;
        wave.enemyType = enemyType;
        wave.amount = amount;
        wave.formation = formation;
        this.Waves.Add(wave);
    }

    public ObservableCollection<Wave> getWaveList()
    {
        return this.Waves;
    }

    public string Save()
    {
        return JsonConvert.SerializeObject(this, _config);
    }
    public Level Load(string value)
    {
        try
        {
            return JsonConvert.DeserializeObject<Level>(value, _config);
        }
        catch (Exception e)
        {
            MessageBox.Show("ERROR: " + e.Message);
            return null;
        }
    }
    private JsonSerializerSettings _config = new JsonSerializerSettings
    {
        Formatting = Newtonsoft.Json.Formatting.Indented,
        NullValueHandling = NullValueHandling.Ignore
    };
}
