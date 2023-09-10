using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace kaifPuzzle
{
    [Serializable]

    class PersonItem
    {
        public string Name;
        public int Moves;
        public int Time;
    }

}
