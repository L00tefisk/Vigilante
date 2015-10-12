using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveEditor.Model
{
    public class Move
    {
        public enum Motion
        {
            Line,
            Circle,
            Sine,
            Wait
        }
        public Motion motion { get; set; }
        public int duration { get; set; }

        public Move()
        {
            motion = 0;
            duration = 0;
        }
    }
}
