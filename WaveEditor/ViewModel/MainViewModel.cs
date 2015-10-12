using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WaveEditor.Model;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Windows;

namespace WaveEditor.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private string _selectedType { get; set; }
        public string SelectedType
        {
            get
            {
                return _selectedType;
            }
            set
            {
                _selectedType = value;
                RaisePropertyChanged(() => SelectedType);
            }
        }

        private ObservableCollection<string> _enemyTypes;
        public ObservableCollection<string> EnemyTypes
        {
            get
            {
                return _enemyTypes;
            }
        }

        private Level _level;

        public Level Level
        {
            get
            {
                return _level;
            }
            set
            {
                _level = value;
                RaisePropertyChanged(() => Level);
            }
        }
        public ObservableCollection<Level.Wave> Waves
        {
            get
            {
                return _level.Waves;
            }
            set
            {
                _level.Waves = value;
                RaisePropertyChanged(() => Waves);
            }
        }
        private Level.Wave _selectedWave { get; set; }
        public Level.Wave SelectedWave
        {
            get
            {
                return _selectedWave;
            }
            set
            {
                _selectedWave = value;
                RaisePropertyChanged();
            }
        }

        #region Commands

        public ICommand NewCommand { get; private set; }
        public ICommand RemoveCommand { get; private set; }
        public ICommand DefaultCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand LoadCommand { get; private set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            Level = new Level();
            _enemyTypes = new ObservableCollection<string>
            {
                "Seedling"
            };

            CreateCommands();

            //Load();
        }

        private void CreateCommands()
        {
            NewCommand = new RelayCommand(AddItem);
            RemoveCommand = new RelayCommand(RemoveItem, CanRemove);
            DefaultCommand = new RelayCommand(DefaultLevel);
            SaveCommand = new RelayCommand(Save);
            LoadCommand = new RelayCommand(Load);
        }
        public void AddItem()
        {
            int newTime = 5;
            if (Waves.Count > 0)
                newTime += Waves.Last().time;

            Waves.Add(
                new Level.Wave()
                {
                    amount = 4,
                    enemyType = Level.EnemyType.Seedling,
                    formation = Level.Formation.Square,
                    moveset = null,
                    time = newTime
                }
            );
            SelectedWave = Waves.Last();
        }
        public void RemoveItem()
        {
            int i = Waves.IndexOf(SelectedWave);
            Waves.Remove(SelectedWave);

            if (Waves.Count > 0)
            {
                if (i == Waves.Count)
                    SelectedWave = Waves[i - 1];
                else
                    SelectedWave = Waves[i];
            }
        }

        private bool CanRemove()
        {
            //return SelectedItem != null;
            return true;
        }

        public void DefaultLevel()
        {
            Level model = new Level();
            model.Waves = new ObservableCollection<Level.Wave>();

            PopulateView(model);
        }

        private string path = "../../Level.json";

        public void Save()
        {

            StreamWriter writer = new StreamWriter(path);
            writer.Write(_level.Save());
            writer.Close();
        }

        public void Load()
        {
            try {
                StreamReader reader = new StreamReader(path);

                Level model = Level.Load(reader.ReadToEnd());

                reader.Close();

                PopulateView(model);
            } catch (Exception e) {
                MessageBox.Show("Error: " + e.Message); 
            }
        }

        public void PopulateView(Level model)
        {
            Level = model;
            Waves = model.Waves;
        }
    }
}