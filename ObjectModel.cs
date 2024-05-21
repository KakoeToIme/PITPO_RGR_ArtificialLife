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

        public ObjectModel()
        {
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
            IsAlive = true;
            CanMove = false;
            Energy = 50;
            Colour = "Green";
        }
    }

    public class Herbivore : ObjectModel
    {
        private uint traveledDistance = 0;
        private uint birihChildCD = 0;

        public Herbivore()
        {
            IsAlive = true;
            CanMove = true;
            Energy = 15;
            Colour = "Blue";
        }
    }

    public class Predator : ObjectModel
    {
        private uint traveledDistance = 0;
        private uint birihChildCD = 0;

        public Predator()
        {
            IsAlive = true;
            CanMove = true;
            Energy = 20;
            Colour = "Crimson";
        }
    }
}
