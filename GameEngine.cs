using System;

namespace PITPO_RGR_ArtificialLife
{
    public class GameEngine
    {
        public uint CurrentGeneration { get; private set; }
        private ObjectModel[,] objMod;
        private readonly int rows;
        private readonly int cols;
        private readonly int plantReg;

        public GameEngine(int rows, int cols, int plantAmount, int plantReg, int herbivoreAmount, int predatorAmount)
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

            StartObjectSpawn(plantAmount, herbivoreAmount, predatorAmount);
        }

        public void NextGeneration()
        {
            var newField = new ObjectModel[cols, rows];

            newField = objMod;

            CheakObjectEnergy(newField);

            PlantRegeneration(plantReg, newField);

            MoveHerbivore(newField);

            MovePredator(newField);

            ReproductionOfHerbivore(newField);

            ReproductionOfPredator(newField);

            ClearMoveList(newField);

            DecreaseBirthCD(newField);

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

        private ObjectModel[,] PlantRegeneration(int plantRegeneration, ObjectModel[,] objModel)
        {
            if (CurrentGeneration != 0 && CurrentGeneration % 25 == 0)
            {
                CreatingPlant(plantRegeneration);
            }

            return objModel;
        }

        //Методы для работы с травоядными
        private ObjectModel[,] MoveHerbivore(ObjectModel[,] objModel)
        {
            Random random = new Random();
            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    if (objModel[x, y] != null && objModel[x, y].IsAlive && objModel[x, y].HadMoved == false && objModel[x, y].Colour == "Blue")
                    {
                        var coordOfPlant = CheakNearbyPlant(x, y);

                        if (coordOfPlant != (-1, -1))
                        {
                            int targetX = coordOfPlant.Item1;
                            int targetY = coordOfPlant.Item2;
                            MoveTowardsHerbivore(objModel, x, y, targetX, targetY);
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
                                objModel[newX, newY].HadMoved = true;
                                objModel[x, y] = new ObjectModel();
                            }
                        }
                    }
                }
            }

            return objModel;
        }

        private void MoveTowardsHerbivore(ObjectModel[,] objModel, int x, int y, int targetX, int targetY)
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
                    objModel[newX, newY].HadMoved = true;
                    objModel[x, y] = new ObjectModel();
                }
                else if (!objModel[newX, newY].IsAlive)
                {
                    objModel[newX, newY] = objModel[x, y];
                    objModel[newX, newY].HadMoved = true;
                    objModel[x, y] = new ObjectModel();
                }
            }
        }


        private (int, int) CheakNearbyPlant(int x, int y)
        {
            int radius = 8;

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

        private ObjectModel[,] ReproductionOfHerbivore(ObjectModel[,] objModel)
        {
            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    if (objModel[x, y] != null && objModel[x, y].IsAlive && objModel[x, y].Colour == "Blue")
                    {
                        HerbivoreChildBirth(objModel, x, y);
                    }
                }
            }

            return objModel;
        }

        private void HerbivoreChildBirth(ObjectModel[,] objModel, int x, int y)
        {
            if (objModel[x, y].BirihChildCD > 0)
            {
                return;
            }

            Random random = new Random();

            for (int newX = x - 1; newX <= x + 1; newX++)
            {
                for (int newY = y - 1; newY <= y + 1; newY++)
                {
                    if (IsWithinBounds(newX, newY) && (newX != x || newY != y))
                    {
                        if (objModel[newX, newY] != null && objModel[newX, newY].Colour == "Blue" && objModel[newX, newY].BirihChildCD == 0)
                        {
                            int attempts = 0;
                            int coordXChild;
                            int coordYChild;

                            while (true)
                            {
                                coordXChild = random.Next(newX - 2, newX + 2);
                                coordYChild = random.Next(newY - 2, newY + 2);
                                attempts++;

                                if (IsWithinBounds(coordXChild, coordYChild) && !objModel[coordXChild, coordYChild].IsAlive)
                                {
                                    break;
                                }
                                if (attempts > 25)
                                {
                                    coordXChild = -1;
                                    coordYChild = -1;
                                    break;
                                }
                            }

                            if (coordXChild != -1 && coordYChild != -1)
                            {
                                objModel[coordXChild, coordYChild] = new Herbivore();
                                objModel[coordXChild, coordYChild].BirihChildCD = 20;
                                objModel[newX, newY].BirihChildCD = 20;
                                objModel[x, y].BirihChildCD = 20;
                                return;
                            }
                        }
                    }
                }
            }
        }

        //Методы для работы с хищниками

        private (int, int) CheakNearbyHerbivore(int x, int y)
        {
            int radius = 8;

            for (int i = Math.Max(0, x - radius); i <= Math.Min(cols - 1, x + radius); i++)
            {
                for (int j = Math.Max(0, y - radius); j <= Math.Min(rows - 1, y + radius); j++)
                {
                    if (objMod[i, j] != null && objMod[i, j].IsAlive && objMod[i, j].Colour == "Blue")
                    {
                        return (i, j);
                    }
                }
            }

            return (-1, -1);
        }

        private ObjectModel[,] MovePredator(ObjectModel[,] objModel)
        {
            Random random = new Random();

            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    if (objModel[x, y] != null && objModel[x, y].IsAlive && objModel[x, y].HadMoved == false && objModel[x, y].Colour == "Crimson")
                    {
                        var coordOfHerbivore = CheakNearbyHerbivore(x, y);

                        if (coordOfHerbivore != (-1, -1))
                        {
                            int targetX = coordOfHerbivore.Item1;
                            int targetY = coordOfHerbivore.Item2;
                            MoveTowardsPredator(objModel, x, y, targetX, targetY);
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
                                objModel[newX, newY].HadMoved = true;
                                objModel[x, y] = new ObjectModel();
                            }
                        }
                    }
                }
            }

            return objModel;
        }

        private void MoveTowardsPredator(ObjectModel[,] objModel, int x, int y, int targetX, int targetY)
        {
            int sgnX = Math.Sign(targetX - x);
            int sgnY = Math.Sign(targetY - y);

            int newX = x + sgnX;
            int newY = y + sgnY;

            if (IsWithinBounds(newX, newY))
            {
                // Съедание растений
                if (objModel[newX, newY].IsAlive && objModel[newX, newY].Colour == "Blue")
                {
                    objModel[x, y].Energy += objModel[newX, newY].Energy;
                    objModel[newX, newY] = objModel[x, y];
                    objModel[newX, newY].HadMoved = true;
                    objModel[x, y] = new ObjectModel();
                }
                else if (!objModel[newX, newY].IsAlive)
                {
                    objModel[newX, newY] = objModel[x, y];
                    objModel[newX, newY].HadMoved = true;
                    objModel[x, y] = new ObjectModel();
                }
            }
        }
        private ObjectModel[,] ReproductionOfPredator(ObjectModel[,] objModel)
        {
            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    if (objModel[x, y] != null && objModel[x, y].IsAlive && objModel[x, y].Colour == "Crimson")
                    {
                        PredatorChildBirth(objModel, x, y);
                    }
                }
            }

            return objModel;
        }


        private void PredatorChildBirth(ObjectModel[,] objModel, int x, int y)
        {
            if (objModel[x, y].BirihChildCD > 0)
            {
                return;
            }

            Random random = new Random();

            for (int newX = x - 1; newX <= x + 1; newX++)
            {
                for (int newY = y - 1; newY <= y + 1; newY++)
                {
                    if (IsWithinBounds(newX, newY) && (newX != x || newY != y))
                    {
                        if (objModel[newX, newY] != null && objModel[newX, newY].Colour == "Crimson" && objModel[newX, newY].BirihChildCD == 0)
                        {
                            int attempts = 0;
                            int coordXChild;
                            int coordYChild;

                            while (true)
                            {
                                coordXChild = random.Next(newX - 2, newX + 2);
                                coordYChild = random.Next(newY - 2, newY + 2);
                                attempts++;

                                if (IsWithinBounds(coordXChild, coordYChild) && !objModel[coordXChild, coordYChild].IsAlive)
                                {
                                    break;
                                }
                                if (attempts > 25)
                                {
                                    coordXChild = -1;
                                    coordYChild = -1;
                                    break;
                                }
                            }

                            if (coordXChild != -1 && coordYChild != -1)
                            {
                                objModel[coordXChild, coordYChild] = new Predator();
                                objModel[coordXChild, coordYChild].BirihChildCD = 20;
                                objModel[newX, newY].BirihChildCD = 20;
                                objModel[x, y].BirihChildCD = 20;
                                return;
                            }
                        }
                    }
                }
            }
        }

        //Методы для работы со всеми обьектами (общие методы)

        private void StartObjectSpawn(int plantAmount, int herbivoreAmount, int predatorAmount)
        {
            Random random = new Random();

            int mode = 0;

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

                if (mode == 0) objMod[x, y] = new Plant();

                if (mode == 1) objMod[x, y] = new Herbivore();

                if (mode == 2) objMod[x, y] = new Predator();

                if (dr == cycle - 1 && mode < 2)
                {
                    dr = 0;
                    if (mode == 0) cycle = herbivoreAmount;
                    if (mode == 1) cycle = predatorAmount;
                    mode++;
                }
            }
        }

        private ObjectModel[,] CheakObjectEnergy(ObjectModel[,] objModel)
        {
            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    if (objModel[x, y] != null && objModel[x, y].IsAlive)
                    {
                        objModel[x, y].Energy--;
                        if (objModel[x, y].Energy < 1) objModel[x, y] = new ObjectModel();
                    }
                }
            }

            return objModel;
        }

        private void ClearMoveList(ObjectModel[,] objModel)
        {
            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    if (objModel[x, y].IsAlive && objModel[x, y].HadMoved == true)
                    {
                        objModel[x, y].HadMoved = false;
                    }
                }
            }
        }

        private void DecreaseBirthCD(ObjectModel[,] objModel)
        {
            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    if (objModel[x, y] != null && (objModel[x, y].Colour == "Blue" || objModel[x, y].Colour == "Crimson") && objModel[x, y].BirihChildCD != 0)
                    {
                        objModel[x, y].BirihChildCD--;
                    }
                }
            }
        }

        public bool CheakSystemAlive()
        {
            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    if (objMod[x, y].IsAlive && (objMod[x, y].Colour == "Blue" || objMod[x, y].Colour == "Crimson"))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool IsWithinBounds(int x, int y)
        {
            return x >= 0 && x < cols && y >= 0 && y < rows;
        }
    }
}