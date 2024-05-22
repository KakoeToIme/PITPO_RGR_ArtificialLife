using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PITPO_RGR_ArtificialLife
{
    public class GameEngine
    {
        public uint CurrentGeneration { get; private set; }
        private ObjectModel[,] objMod;
        private readonly int rows;
        private readonly int cols;
        private readonly int plantReg;

        public GameEngine(int rows, int cols, int plantAmount, int plantReg, int herbivoreAmount)
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

            CreatingPlant(plantAmount);

            CreatingHerbivore(herbivoreAmount);
        }

        public void NextGeneration()
        {
            var newField = new ObjectModel[cols, rows];
            newField = objMod;

            CheakPlantEnergy(newField);

            CheakHerbivoreEnergy(newField);

            PlantRegeneration(plantReg, newField);

            MoveHerbivore(newField);

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
        private void CreatingPlant(int plantAmount)
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
                CreatingPlant(plantRegeneration);
            }

            return objModel;
        }

        //Методы для работы с травоядными
        private void CreatingHerbivore(int herbivoreAmount)
        {
            Random random = new Random();

            int cycle = herbivoreAmount;

            for (int dr = 0; dr < cycle; dr++)
            {
                int x = random.Next(cols);
                int y = random.Next(rows);

                if (objMod[x, y].IsAlive)
                {
                    cycle++;
                    continue;
                }

                objMod[x, y] = new Herbivore();
            }
        }

        private ObjectModel[,] MoveHerbivore(ObjectModel[,] objModel)
        {
            Random random = new Random();
            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    if (objModel[x, y] != null && objModel[x, y].IsAlive && objModel[x, y].Colour == "Blue")
                    {
                        var coordOfPlant = CheakNearbyPlant(x, y);

                        if (coordOfPlant != (-1, -1))
                        {
                            int targetX = coordOfPlant.Item1;
                            int targetY = coordOfPlant.Item2;
                            MoveTowards(objModel, x, y, targetX, targetY);
                        }
                        else
                        {
                            int newX, newY;
                            int attempts = 0;

                            do
                            {
                                newX = random.Next(Math.Max(0, x - 1), Math.Min(cols, x + 2));
                                newY = random.Next(Math.Max(0, y - 1), Math.Min(rows, y + 2));
                                attempts++;
                            } while (attempts < 10 && (newX == x && newY == y || objModel[newX, newY].IsAlive));

                            if (attempts < 10)
                            {
                                objModel[newX, newY] = objModel[x, y];
                                objModel[x, y] = new ObjectModel();
                            }
                        }
                    }
                }
            }

            return objModel;
        }

        private void MoveTowards(ObjectModel[,] objModel, int x, int y, int targetX, int targetY)
        {
            int sgnX = Math.Sign(targetX - x);
            int sgnY = Math.Sign(targetY - y);

            int newX = x + sgnX;
            int newY = y + sgnY;

            if (IsWithinBounds(newX, newY))
            {
                // Съедание растений
                if (objModel[newX, newY].IsAlive && objModel[newX, newY].Colour == "Green")
                {
                    objModel[x, y].Energy += objModel[newX, newY].Energy;
                    objModel[newX, newY] = objModel[x, y];
                    objModel[x, y] = new ObjectModel();
                }
                else if (!objModel[newX, newY].IsAlive)
                {
                    objModel[newX, newY] = objModel[x, y];
                    objModel[x, y] = new ObjectModel();
                }
            }
        }


        private (int, int) CheakNearbyPlant(int x, int y)
        {
            int radius = 4;

            for (int i = Math.Max(0, x - radius); i <= Math.Min(cols - 1, x + radius); i++)
            {
                for (int j = Math.Max(0, y - radius); j <= Math.Min(rows - 1, y + radius); j++)
                {
                    if (objMod[i, j] != null && objMod[i, j].IsAlive && objMod[i, j].Colour == "Green")
                    {
                        return (i, j);
                    }
                }
            }

            return (-1, -1);
        }

        private ObjectModel[,] CheakHerbivoreEnergy(ObjectModel[,] objModel)
        {
            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    if (objModel[x, y] != null && objModel[x, y].IsAlive && objModel[x, y].Colour == "Blue")
                    {
                        objModel[x, y].Energy--;
                        if (objModel[x, y].Energy < 1) objModel[x, y] = new ObjectModel();
                    }
                }
            }

            return objModel;
        }

        private bool IsWithinBounds(int x, int y)
        {
            return x >= 0 && x < cols && y >= 0 && y < rows;
        }
    }
}
