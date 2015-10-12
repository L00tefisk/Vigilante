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


        #region Move
        public IEnumerable<Move.Motion> Motions
        {
            get
            {
                return (IEnumerable<Move.Motion>)Enum.GetValues(typeof(Move.Motion));
            }
        }
        public ObservableCollection<Move> Moveset
        {
            get
            {
                if (SelectedWave != null)
                    return SelectedWave.Moveset;
                return null;
            }
            set
            {
                SelectedWave.Moveset = value;
                RaisePropertyChanged(() => Moveset);
            }
        }
        private Move _selectedMove { get; set; }
        public Move SelectedMove
        {
            get
            {
                return _selectedMove;
            }
            set
            {
                _selectedMove = value;
                RaisePropertyChanged(() => SelectedMove);
            }
        }

        #endregion

        #region Wave
        public IEnumerable<Wave.Formation> Formations
        {
            get
            {
                return (IEnumerable<Wave.Formation>)Enum.GetValues(typeof(Wave.Formation));
            }
        }
        public IEnumerable<Wave.EnemyType> EnemyTypes
        {
            get
            {
                return (IEnumerable<Wave.EnemyType>)Enum.GetValues(typeof(Wave.EnemyType));
            }
        }
        public ObservableCollection<Wave> Waves
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
        private Wave _selectedWave { get; set; }
        public Wave SelectedWave
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
        #endregion

        #region Commands

        public ICommand NewCommand { get; private set; }
        public ICommand RemoveCommand { get; private set; }
        public ICommand AddMoveCommand { get; private set; }
        public ICommand RemoveMoveCommand { get; private set; }
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

            CreateCommands();

            //Load();
        }

        private void CreateCommands()
        {
            NewCommand = new RelayCommand(AddItem);
            RemoveCommand = new RelayCommand(RemoveItem, CanRemove);
            AddMoveCommand = new RelayCommand(AddMove);
            RemoveMoveCommand = new RelayCommand(RemoveMove);
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
                new Wave()
                {
                    amount = 4,
                    enemyType = Wave.EnemyType.Seedling,
                    formation = Wave.Formation.Square,
                    Moveset = new ObservableCollection<Move>()
                    {
                        new Move()
                        {
                            motion = Move.Motion.Sine,
                            duration = 1
                        },
                        new Move()
                        {
                            motion = Move.Motion.Circle,
                            duration = 3
                        }
                    },
                    time = newTime
                }
            );
            SelectedWave = Waves.Last();
        }
        public void RemoveItem()
        {
            int i = Waves.IndexOf(SelectedWave);
            Waves.RemoveAt(i);

            if (Waves.Count > 0)
            {
                if (i == Waves.Count)
                    SelectedWave = Waves[i - 1];
                else
                    SelectedWave = Waves[i];
            }
        }
        public void AddMove()
        {
            Moveset.Add(
                new Move()
                {
                    motion = 0,
                    duration = 1
                }
            );
            SelectedMove = Moveset.Last();
        }
        public void RemoveMove()
        {
            int i = Moveset.IndexOf(SelectedMove);
            Moveset.RemoveAt(i);

            if (Moveset.Count > 0)
            {
                if (i == Moveset.Count)
                    SelectedMove = Moveset[i - 1];
                else
                    SelectedMove = Moveset[i];
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
            model.Waves = new ObservableCollection<Wave>();

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