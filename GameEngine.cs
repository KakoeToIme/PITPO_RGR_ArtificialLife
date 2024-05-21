using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PITPO_RGR_ArtificialLife
{
    public class GameEngine
    {
        public uint CurrentGeneration { get; private set; }
        private ObjectModel[,] objMod;
        private readonly int rows;
        private readonly int cols;
        private readonly int plantReg;

        public GameEngine(int rows, int cols, int plantAmount, int plantReg)
        {
            this.rows = rows;
            this.cols = cols;
            this.plantReg = plantReg;

            objMod = new ObjectModel[cols, rows];

            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    objMod[x, y] = new ObjectModel();
                }
            }

            CreatingPlant(plantAmount, objMod);
        }

        public void NextGeneration()
        {
            var newField = new ObjectModel[cols, rows];
            newField = objMod;

            CheakPlantEnergy(newField);

            PlantRegeneration(plantReg, newField);

            objMod = newField;
            CurrentGeneration++;
        }

        public ObjectModel[,] GetCurrentGeneration()
        {
            var result = new ObjectModel[cols, rows];

            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    result[x, y] = objMod[x, y];
                }
            }

            return result;
        }

        //Методы для работы с растениями
        private ObjectModel[,] CreatingPlant(int plantAmount, ObjectModel[,] objModel)
        {
            Random random = new Random();

            int cycle = plantAmount;

            for (int dr = 0; dr < cycle; dr++)
            {
                int x = random.Next(cols);
                int y = random.Next(rows);

                if (objMod[x, y].IsAlive)
                {
                    cycle++;
                    continue;
                }

                objMod[x, y] = new Plant();
            }

            return objModel;
        }

        private ObjectModel[,] CheakPlantEnergy(ObjectModel[,] objModel)
        {
            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    if (objModel[x, y] != null && objModel[x, y].IsAlive && objModel[x, y].Colour == "Green")
                    {
                        objModel[x, y].Energy--;
                        if (objModel[x, y].Energy < 1) objModel[x, y] = new ObjectModel();
                    }
                }
            }

            return objModel;
        }

        private ObjectModel[,] PlantRegeneration(int plantRegeneration, ObjectModel[,] objModel)
        {
            if (CurrentGeneration != 0 && CurrentGeneration % 25 == 0)
            {
                CreatingPlant(plantRegeneration, objModel);
            }

            return objModel;
        }
    }
}
