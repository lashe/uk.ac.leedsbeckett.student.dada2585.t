using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.ac.leedsbeckett.student.dada2585.t
{
    /// <summary>
    /// class responsible for storing, updating and providing variables that are used across any and allclasses
    /// </summary>
    internal class StateManager
    {
        private static StateManager instance;
        public int X { get; set; }
        public int Y { get; set; }
        public bool F { get; set; }
        public Color C { get; set; }
        private StateManager() { }
        public static StateManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StateManager();
                }
                return instance;
            }
        }
    }
}
