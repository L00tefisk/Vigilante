using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveEditor.Model
{
    public class Wave
    {

        public int time { get; set; }
        public EnemyType enemyType { get; set; }
        public int amount { get; set; }
        public Formation formation { get; set; }
        public ObservableCollection<Move> Moveset { get; set; }

        public enum Formation
        {
            Line,
            Square,
            Circle
        }

        
        public enum EnemyType
        {
            Seedling
        }

        public Wave()
        {
            time = 0;
            enemyType = 0;
            amount = 0;
            formation = 0;
            Moveset = new ObservableCollection<Move>();
        }
    }
}
