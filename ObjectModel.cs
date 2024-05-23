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
        public bool CanMove { get; protected set; }
        public uint Energy { get; set; }
        public string Colour { get; protected set; }
        public bool HadMoved { get; set; }
        private uint age = 0;
        private uint traveledDistance = 0;
        private uint birihChildCD = 0;

        public ObjectModel()
        {
            HadMoved = true;
            IsAlive = false;
            CanMove = false;
            Energy = 0;
            Colour = "Transparent";
        }
    }

    public class Plant : ObjectModel
    {
        public Plant()
        {
            HadMoved = true;
            IsAlive = true;
            CanMove = false;
            Energy = 50;
            Colour = "Green";
        }
    }

    public class Herbivore : ObjectModel
    {
        public Herbivore()
        {
            HadMoved = true;
            IsAlive = true;
            CanMove = true;
            Energy = 100;
            Colour = "Blue";
        }
    }

    public class Predator : ObjectModel
    {
        public Predator()
        {
            HadMoved = true;
            IsAlive = true;
            CanMove = true;
            Energy = 75;
            Colour = "Crimson";
        }
    }
}
