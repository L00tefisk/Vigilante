﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace WaveEditor.Model
{
    public class Level
    {

        public ObservableCollection<string> EnemyTypes { get; set; }

        public ObservableCollection<Enemy> Enemies { get; set; }

        public Level()
        {
            Enemies = new ObservableCollection<Enemy>();

            EnemyTypes = new ObservableCollection<string>() {};
        }

        private JsonSerializerSettings _config = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            NullValueHandling = NullValueHandling.Ignore
        };

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
    }
}
