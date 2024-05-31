using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PITPO_RGR_ArtificialLife
{
    public partial class LoadingUI : Form
    {
        private Graphics graphics;
        private GameEngine gameEngine;
        private readonly int resolution = 9;

        public LoadingUI()
        {
            InitializeComponent();
        }

        private void StartGame()
        {
            if (timer1.Enabled) return;

            nudPlantAmount.Enabled = false;
            nudPlantReg.Enabled = false;
            nudHerbAmount.Enabled = false;
            nudPredAmount.Enabled = false;

            gameEngine = new GameEngine
             (
                 rows: pictureBox1.Height / resolution,
                 cols: pictureBox1.Width / resolution,
                 plantAmount: (int) nudPlantAmount.Value,
                 plantReg: (int) nudPlantReg.Value,
                 herbivoreAmount: (int) nudHerbAmount.Value,
                 predatorAmount: (int) nudPredAmount.Value 
             );

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);
            timer1.Start();
        }

        private void DrawNextGeneration()
        {
            graphics.Clear(Color.Black);

            var objMod = gameEngine.GetCurrentGeneration();

            for (int x = 0; x < objMod.GetLength(0); x++)
            {
                for (int y = 0; y < objMod.GetLength(1); y++)
                {
                    if (objMod[x, y] != null && objMod[x, y].IsAlive == true)
                    {
                        if (objMod[x, y].Colour == "Green")
                            graphics.FillRectangle(Brushes.Green, x * resolution, y * resolution, resolution, resolution);
                        if (objMod[x, y].Colour == "Blue")
                            graphics.FillRectangle(Brushes.Blue, x * resolution, y * resolution, resolution, resolution);
                        if (objMod[x, y].Colour == "Crimson")
                            graphics.FillRectangle(Brushes.Crimson, x * resolution, y * resolution, resolution, resolution);
                    }
                }
            }

            pictureBox1.Refresh();
            Text = $"Generation {gameEngine.CurrentGeneration}";

            if (gameEngine.CheakSystemAlive() == true)
            {
                StopGame();
            }

            gameEngine.NextGeneration();
        }

        private void StopGame()
        {
            if (!timer1.Enabled) return;

            nudPlantAmount.Enabled = true;
            nudPlantReg.Enabled = true;
            nudHerbAmount.Enabled = true;
            nudPredAmount.Enabled = true;

            timer1.Stop();
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            StopGame();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DrawNextGeneration(); 
        }
    }
}
