using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System;
using System.Windows;
using WaveEditor.Model;

public class Level
{
    public string map { get; private set; }
    public ObservableCollection<Wave> Waves { get; set; }    

    public Level()
    {
        Waves = new ObservableCollection<Wave>();
    }

    public void addToWaveList(Wave wave)
    {
        this.Waves.Add(wave);
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
