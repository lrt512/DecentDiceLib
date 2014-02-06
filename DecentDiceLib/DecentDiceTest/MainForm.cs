using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using DecentDiceLib;
using System.Threading;
using System.Diagnostics;

namespace DecentDiceTest
{
    /// <summary>
    /// Application for testing the DecentDiceLib
    /// </summary>
    public partial class MainForm : Form
    {
        // For cancelling async tasks
        private CancellationTokenSource cts;

        #region Constructor
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Private Methods
        private void MainForm_Load(object sender, EventArgs e)
        {
            SetControls(false);
        }

        /// <summary>
        /// Stop the test
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stopButton_Click(object sender, EventArgs e)
        {
            if (cts != null)
            {
                stopButton.Enabled = false;
                cts.Cancel();
            }
        }

        private void SetControls(bool testRunning)
        {
            startButton.Enabled = !testRunning;
            stopButton.Enabled = testRunning;
            testSides.Enabled = !testRunning;
        }

        /// <summary>
        /// Run the test asynchronously in a thread so we don't lose all of
        /// the UI responsiveness
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void startButton_Click(object sender, EventArgs e)
        {
            SetControls(true);

            // Bag of dice
            Dice dice = Dice.Instance;

            ResultsListView.Items.Clear();
            cts = new CancellationTokenSource();
            Stopwatch elapsed = new Stopwatch();
            float failed = 0.0F;

            elapsed.Start();
            
            // Iterate all die sizes from 2 to DecentDiceLib maximum
            int testTo = Convert.ToInt32(testSides.Value);

            for (int sides = 2; sides <= testTo; sides += 1)
            {
                currentDie.Text = string.Format("d{0}", sides);

                RollResults results = new RollResults(sides);
                try
                {
                    // Spawn an async task thread to roll the dice and calculate
                    Task task = RollDice(sides, cts.Token, results);
                    await task;
                    task.Dispose();
                }
                catch (OperationCanceledException)
                {
                    // User cancelled the run
                    SetControls(false);
                    currentDie.Text = string.Empty;
                    elapsedTime.Text = string.Empty;
                    return;
                }

                // Process the results into a row in the ListView
                string[] row = {
                 sides.ToString(), 
                 results.NumRolls.ToString(),
                 results.TimerMilliseconds().ToString(),
                 (results.Min == 1 && results.Max == sides) ? "Y" : "N",
                 string.Format("{0:F2}", results.ExpectedAverageValue()),
                 string.Format("{0:F2}", results.AverageValue()),
                 string.Format("{0:F2}", results.ChiSquared),
                 string.Format("{0:F3}", results.PValue)
                };
                
                bool pFailed = results.PValue < 0.05F;
                if (pFailed)
                {
                    failed += 1;
                }
                var listViewRow = new ListViewItem(row);

                listViewRow.ForeColor = pFailed ? Color.Red: Color.Green;
                ResultsListView.Items.Add(listViewRow);
                ResultsListView.Update();
                elapsedTime.Text = elapsed.Elapsed.ToString(@"hh\:mm\:ss\.fff");
                failedLabel.Text = string.Format("{0:F0}% failed", failed / (sides - 1) * 100);
            }
            elapsed.Stop();
            SetControls(false);

        }

        /// <summary>
        /// Async task to roll the dice (so the UI doesn't hang)
        /// </summary>
        /// <param name="sides"></param>
        /// <returns></returns>
        private async Task RollDice(int sides, CancellationToken ct, RollResults results)
        {
            int rolls = 0;
            
            // Bag of dice
            Dice dice = Dice.Instance;

            // Time the dicelib for fun
            results.Start();
            while (rolls < results.NumRolls)
            {
                rolls += 1;
                results.AddRoll(dice.Roll(sides));
            }
            results.Stop();
            // Let the user's request to cancel get through
            await Task.Delay(10, ct);
        }
        #endregion
    }
}