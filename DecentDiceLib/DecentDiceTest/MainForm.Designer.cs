namespace DecentDiceTest
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.ResultsListView = new System.Windows.Forms.ListView();
            this.sides = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rolls = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.testTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rangeOk = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.eAverage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.aAverage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chiSquare = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.currentDie = new System.Windows.Forms.Label();
            this.currentDieLabel = new System.Windows.Forms.Label();
            this.elapsedTimeLabel = new System.Windows.Forms.Label();
            this.elapsedTime = new System.Windows.Forms.Label();
            this.testSidesLabel = new System.Windows.Forms.Label();
            this.testSides = new System.Windows.Forms.NumericUpDown();
            this.failedLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.testSides)).BeginInit();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(501, 579);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start Test";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(420, 579);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 2;
            this.stopButton.Text = "Stop Test";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // ResultsListView
            // 
            this.ResultsListView.CausesValidation = false;
            this.ResultsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.sides,
            this.rolls,
            this.testTime,
            this.rangeOk,
            this.eAverage,
            this.aAverage,
            this.chiSquare,
            this.pValue});
            this.ResultsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultsListView.GridLines = true;
            this.ResultsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ResultsListView.Location = new System.Drawing.Point(0, 0);
            this.ResultsListView.MultiSelect = false;
            this.ResultsListView.Name = "ResultsListView";
            this.ResultsListView.Size = new System.Drawing.Size(588, 573);
            this.ResultsListView.TabIndex = 0;
            this.ResultsListView.UseCompatibleStateImageBehavior = false;
            this.ResultsListView.View = System.Windows.Forms.View.Details;
            // 
            // sides
            // 
            this.sides.Text = "Sides";
            this.sides.Width = 50;
            // 
            // rolls
            // 
            this.rolls.Text = "Rolls";
            this.rolls.Width = 80;
            // 
            // testTime
            // 
            this.testTime.Text = "Time (ms)";
            // 
            // rangeOk
            // 
            this.rangeOk.Text = "Range OK";
            this.rangeOk.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.rangeOk.Width = 65;
            // 
            // eAverage
            // 
            this.eAverage.Text = "Expected Average";
            this.eAverage.Width = 100;
            // 
            // aAverage
            // 
            this.aAverage.Text = "Actual Average";
            this.aAverage.Width = 85;
            // 
            // chiSquare
            // 
            this.chiSquare.Text = "Chi Squared";
            this.chiSquare.Width = 75;
            // 
            // pValue
            // 
            this.pValue.Text = "p";
            this.pValue.Width = 45;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ResultsListView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(588, 573);
            this.panel1.TabIndex = 3;
            // 
            // currentDie
            // 
            this.currentDie.AutoSize = true;
            this.currentDie.Location = new System.Drawing.Point(53, 584);
            this.currentDie.Name = "currentDie";
            this.currentDie.Size = new System.Drawing.Size(0, 13);
            this.currentDie.TabIndex = 1;
            // 
            // currentDieLabel
            // 
            this.currentDieLabel.AutoSize = true;
            this.currentDieLabel.Location = new System.Drawing.Point(12, 584);
            this.currentDieLabel.Name = "currentDieLabel";
            this.currentDieLabel.Size = new System.Drawing.Size(44, 13);
            this.currentDieLabel.TabIndex = 2;
            this.currentDieLabel.Text = "Current:";
            this.currentDieLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // elapsedTimeLabel
            // 
            this.elapsedTimeLabel.AutoSize = true;
            this.elapsedTimeLabel.Location = new System.Drawing.Point(116, 584);
            this.elapsedTimeLabel.Name = "elapsedTimeLabel";
            this.elapsedTimeLabel.Size = new System.Drawing.Size(48, 13);
            this.elapsedTimeLabel.TabIndex = 4;
            this.elapsedTimeLabel.Text = "Elapsed:";
            this.elapsedTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // elapsedTime
            // 
            this.elapsedTime.AutoSize = true;
            this.elapsedTime.Location = new System.Drawing.Point(165, 584);
            this.elapsedTime.Name = "elapsedTime";
            this.elapsedTime.Size = new System.Drawing.Size(0, 13);
            this.elapsedTime.TabIndex = 5;
            // 
            // testSidesLabel
            // 
            this.testSidesLabel.AutoSize = true;
            this.testSidesLabel.Location = new System.Drawing.Point(305, 584);
            this.testSidesLabel.Name = "testSidesLabel";
            this.testSidesLabel.Size = new System.Drawing.Size(43, 13);
            this.testSidesLabel.TabIndex = 6;
            this.testSidesLabel.Text = "Test to:";
            this.testSidesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // testSides
            // 
            this.testSides.Location = new System.Drawing.Point(354, 582);
            this.testSides.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.testSides.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.testSides.Name = "testSides";
            this.testSides.Size = new System.Drawing.Size(58, 20);
            this.testSides.TabIndex = 1;
            this.testSides.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // failedLabel
            // 
            this.failedLabel.AutoSize = true;
            this.failedLabel.Location = new System.Drawing.Point(238, 584);
            this.failedLabel.Name = "failedLabel";
            this.failedLabel.Size = new System.Drawing.Size(49, 13);
            this.failedLabel.TabIndex = 7;
            this.failedLabel.Text = "0% failed";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 608);
            this.Controls.Add(this.failedLabel);
            this.Controls.Add(this.testSides);
            this.Controls.Add(this.testSidesLabel);
            this.Controls.Add(this.elapsedTime);
            this.Controls.Add(this.elapsedTimeLabel);
            this.Controls.Add(this.currentDie);
            this.Controls.Add(this.currentDieLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Name = "MainForm";
            this.Text = "Fair Dice Tester";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.testSides)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.ListView ResultsListView;
        private System.Windows.Forms.ColumnHeader sides;
        private System.Windows.Forms.ColumnHeader rangeOk;
        private System.Windows.Forms.ColumnHeader eAverage;
        private System.Windows.Forms.ColumnHeader aAverage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label currentDie;
        private System.Windows.Forms.Label currentDieLabel;
        private System.Windows.Forms.Label elapsedTimeLabel;
        private System.Windows.Forms.Label elapsedTime;
        private System.Windows.Forms.ColumnHeader testTime;
        private System.Windows.Forms.ColumnHeader rolls;
        private System.Windows.Forms.ColumnHeader chiSquare;
        private System.Windows.Forms.ColumnHeader pValue;
        private System.Windows.Forms.Label testSidesLabel;
        private System.Windows.Forms.NumericUpDown testSides;
        private System.Windows.Forms.Label failedLabel;

    }
}

