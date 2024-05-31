using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PITPO_RGR_ArtificialLife
{
    public class ObjectModel
    {
        public bool IsAlive { get; set; }
        public uint Energy { get; set; }
        public string Colour { get; protected set; }
        public bool HadMoved { get; set; }
        public uint BirihChildCD { get; set; }

        public ObjectModel()
        {
            BirihChildCD = 0;
            HadMoved = true;
            IsAlive = false;
            Energy = 0;
            Colour = "Transparent";
        }
    }

    public class Plant : ObjectModel
    {
        public Plant()
        {
            BirihChildCD = 0;
            HadMoved = true;
            IsAlive = true;
            Energy = 50;
            Colour = "Green";
        }
    }

    public class Herbivore : ObjectModel
    {
        public Herbivore()
        {
            BirihChildCD = 0;
            HadMoved = true;
            IsAlive = true;
            Energy = 100;
            Colour = "Blue";
        }
    }

    public class Predator : ObjectModel
    {
        public Predator()
        {
            BirihChildCD = 0;
            HadMoved = true;
            IsAlive = true;
            Energy = 125;
            Colour = "Crimson";
        }
    }
}
