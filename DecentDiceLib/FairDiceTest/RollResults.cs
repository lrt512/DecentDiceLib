using System;
using System.Diagnostics;

namespace DecentDiceTest
{
    /// <summary>
    /// A class to hold results in
    /// Also caclulates Chi Squared and p value for the results
    /// </summary>
    class RollResults
    {
        #region Attributes
        /// <summary>
        /// Minimum number rolled during the test
        /// (hopefully 1)
        /// </summary>
        public int Min
        {
            get { return min; }
        }

        /// <summary>
        /// Highest number rolled during the test
        /// (should be equal to sides!)
        /// </summary>
        public int Max
        {
            get { return max; }
        }

        /// <summary>
        /// The sum of all rolls in the test
        /// </summary>
        public double Sum
        {
            get { return sum; }
        }

        /// <summary>
        /// Number of rolls thrown for the test
        /// </summary>
        public int NumRolls
        {
            get { return Math.Max(1000, sides * 10); }
        }

        /// <summary>
        /// Die size for this test
        /// </summary>
        public int Sides
        {
            get { return sides; }
        }

        /// <summary>
        /// The Chi Squared value (X^2) for this test
        /// </summary>
        public double ChiSquared
        {
            get
            {
                if (chiSquared < 0.0D)
                {
                    CalculateChiSquared();
                }
                return chiSquared;
            }
        }
        
        /// <summary>
        /// The p value for this test
        /// </summary>
        public double PValue
        {
            get
            {
                if (pValue < 0.0D)
                {
                    GetPValue();
                }
                return pValue;
            }
        }
        #endregion

        #region Private Data Members
        // Die size
        private int sides;
        // keep track of values rolled
        private int[] rolls = null;
        private Stopwatch timer = new Stopwatch();
        
        // private values for attributes
        private int min = int.MaxValue;
        private int max = 0;
        private double sum = 0.0F;
        private double chiSquared = -1.0D;
        private double pValue = -1.0D;
        #endregion

        #region Constructor
        public RollResults(int sides)
        {
            this.sides = sides;
            
            // Initialize the roll tracking array
            rolls = new int[sides];
            foreach (int roll in rolls)
            {
                rolls[roll] = 0;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Increment the count for a roll 
        /// </summary>
        /// <param name="num">The number rolled</param>
        public void AddRoll(int roll)
        {
            rolls[roll - 1]++;
            if (roll > max)
            {
                max = roll;
            }
            if (roll < min)
            {
                min = roll;
            }
            sum += roll;
        }

        /// <summary>
        /// Start the stopwatch
        /// </summary>
        public void Start()
        {
            timer.Start();
        }

        /// <summary>
        /// Stop the timer
        /// </summary>
        public void Stop()
        {
            timer.Stop();
        }

        /// <summary>
        /// Get the timer's elapsed time in milliseconds
        /// </summary>
        public long TimerMilliseconds()
        {
            return timer.ElapsedMilliseconds;
        }
        #endregion

        #region Stats
        /// <summary>
        /// Calculate the expected average value for the die size
        /// </summary>
        /// <returns>Expected average value of the die</returns>
        public float ExpectedAverageValue()
        {
            float average = 0.0F;
            float probability = 1.0F / sides;
            for (int i = 0; i < sides; i += 1)
            {
                average += (i + 1) * probability;
            }
            return average;
        }

        /// <summary>
        /// Get the average value of the rolls made
        /// </summary>
        /// <returns>The average value of the rolls in the test</returns>
        public double AverageValue()
        {
            return sum / NumRolls;
        }

        /// <summary>
        /// Calculate Chi Squared
        /// </summary>
        public void CalculateChiSquared()
        {
            double expected = 1.0F / sides * NumRolls;

            chiSquared = 0.0F;
            foreach (int count in rolls)
            {
                chiSquared += Math.Pow(count - expected, 2) / expected;
            }
        }

        /// <summary>
        /// Calculate the p value, calculating Chi Squared first if needed
        /// </summary>
        /// <returns>The p value of the test</returns>
        public double GetPValue()
        {
            if (chiSquared < 0.0D)
            {
                CalculateChiSquared();
            }
            if (pValue < 0.0D)
            {
                pValue = SpecialFunction.chisqc(sides - 1, chiSquared);
            }
            return pValue;

        }
        #endregion
    }
}
