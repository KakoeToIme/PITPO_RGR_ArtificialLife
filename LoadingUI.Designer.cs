namespace PITPO_RGR_ArtificialLife
{
    partial class LoadingUI
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.nudPlantReg = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudPlantAmount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.bStop = new System.Windows.Forms.Button();
            this.bStart = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.nudHerbAmount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudPredAmount = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPlantReg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPlantAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHerbAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPredAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.nudPredAmount);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.nudHerbAmount);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.nudPlantReg);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.nudPlantAmount);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.bStop);
            this.splitContainer1.Panel1.Controls.Add(this.bStart);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1268, 565);
            this.splitContainer1.SplitterDistance = 227;
            this.splitContainer1.TabIndex = 0;
            // 
            // nudPlantReg
            // 
            this.nudPlantReg.Location = new System.Drawing.Point(13, 182);
            this.nudPlantReg.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudPlantReg.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPlantReg.Name = "nudPlantReg";
            this.nudPlantReg.Size = new System.Drawing.Size(200, 20);
            this.nudPlantReg.TabIndex = 5;
            this.nudPlantReg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPlantReg.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Растений восстановится за 25 циклов";
            // 
            // nudPlantAmount
            // 
            this.nudPlantAmount.Location = new System.Drawing.Point(13, 131);
            this.nudPlantAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPlantAmount.Name = "nudPlantAmount";
            this.nudPlantAmount.Size = new System.Drawing.Size(200, 20);
            this.nudPlantAmount.TabIndex = 3;
            this.nudPlantAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPlantAmount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Стартовое количество растений";
            // 
            // bStop
            // 
            this.bStop.Location = new System.Drawing.Point(13, 70);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(200, 23);
            this.bStop.TabIndex = 1;
            this.bStop.Text = "Стоп";
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(13, 21);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(200, 23);
            this.bStart.TabIndex = 0;
            this.bStart.Text = "Старт";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1033, 561);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // nudHerbAmount
            // 
            this.nudHerbAmount.Location = new System.Drawing.Point(13, 232);
            this.nudHerbAmount.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudHerbAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHerbAmount.Name = "nudHerbAmount";
            this.nudHerbAmount.Size = new System.Drawing.Size(200, 20);
            this.nudHerbAmount.TabIndex = 7;
            this.nudHerbAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudHerbAmount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Стартовое количество травоядных";
            // 
            // nudPredAmount
            // 
            this.nudPredAmount.Location = new System.Drawing.Point(13, 281);
            this.nudPredAmount.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudPredAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPredAmount.Name = "nudPredAmount";
            this.nudPredAmount.Size = new System.Drawing.Size(200, 20);
            this.nudPredAmount.TabIndex = 9;
            this.nudPredAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPredAmount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 264);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Стартовое количество хищников";
            // 
            // LoadingUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 565);
            this.Controls.Add(this.splitContainer1);
            this.Name = "LoadingUI";
            this.Text = "ArtificialLife";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudPlantReg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPlantAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHerbAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPredAmount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button bStop;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudPlantAmount;
        private System.Windows.Forms.NumericUpDown nudPlantReg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudPredAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudHerbAmount;
        private System.Windows.Forms.Label label3;
    }
}

