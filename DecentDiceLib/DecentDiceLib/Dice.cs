/******************************************************************************
* Copyright (C) 2013  L. Tremblay
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
*
* You should have received a copy of the GNU General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
******************************************************************************/
using System;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace DecentDiceLib
{
    /// <summary>
    /// A singleton class for rolling dice
    /// Randomness is provided by the Crypto RNG provider
    /// Note that this class is only valid up to d65535 (see isFairRoll)
    /// </summary>
    public class Dice : IDisposable
    {
        #region Singleton
        /// <summary>
        /// Singleton implementation for our die
        /// </summary>
        private static Dice instance = null;
        public static Dice Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Dice();
                }
                return Dice.instance;
            }
        }
        #endregion

        #region Non-Static Members
        /// <summary>
        /// Fortified with crypto randomness
        /// </summary>
        private RNGCryptoServiceProvider random;
        /// <summary>
        /// Regex to parse dice notation strings
        /// </summary>
        private Regex diceRegex;
        /// <summary>
        /// Number of bytes to store rolls in
        /// </summary>
        private int numBytes = sizeof(ushort);
        #endregion

        #region Static Members
        /// <summary>
        /// Maximum number of sides we can roll
        /// </summary>
        private static ushort maxSides = ushort.MaxValue;

        /// <summary>
        /// The number of sides we can roll
        /// </summary>
        public static int MaxSides { get { return maxSides; } }
        #endregion

        #region Constructor
        private Dice()
        {
            random = new RNGCryptoServiceProvider();
            diceRegex = new Regex(@"(\d+)?\s*?d\s*?(\d+)(?:\s*?([+-])\s*?(?:(\d+))|(?:\s*?(x)\s*?(\d+)))?");
        }
        #endregion

        #region IDisposable
        /// <summary>
        /// IDisposable-required implementation
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// IDisposable-required implementation
        /// Clean up our disposables
        /// </summary>
        /// <param name="disposing">true if we are cleaning up for GC</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                random.Dispose();
                random = null;
            }
        }
        #endregion

        #region public methods
        /// <summary>
        /// Roll one die with any number of sides
        /// </summary>
        /// <param name="sides">Number of sides for the die</param>
        /// <returns>The result of the die roll</returns>
        public int Roll(int sides)
        {
            return Roll(1, sides);
        }

        /// <summary>
        /// Take a string in dice notation, parse it and roll 'em up
        /// </summary>
        /// <param name="dice">A dice notation string (e.g. 3d6)</param>
        /// <returns>The result of the dice roll</returns>
        public int Roll(string dice)
        {
            if (dice == null)
            {
                return 0;
            }

            int number = 0;
            int sides = 0;
            int roll = 0;

            Match match = diceRegex.Match(dice);
            if (match.Success)
            {
                // Number of dice
                try
                {
                    number = Convert.ToInt32(match.Groups[1].Value);
                }
                catch
                {
                    throw new FormatException(String.Format("Unable to convert number {0} to integer in {1}", match.Groups[1], dice));
                }

                // Die size
                try
                {
                    sides = Convert.ToInt32(match.Groups[2].Value);
                    if (sides > maxSides)
                    {
                        throw new OverflowException(string.Format("Maximum number of sides is {0}", maxSides));
                    }
                }
                catch
                {
                    throw new FormatException(String.Format("Unable to convert sides {0} to integer in {1}", match.Groups[2], dice));
                }
            }
            else
            {
                throw new FormatException(String.Format("Invalid dice notation given ({0})", dice));
            }

            // Get the roll value
            roll = Roll(number, sides);

            // Parse out any "+10" or "x100" modifiers
            if (match.Groups[3].Value == "+")
            {
                // 1d100+10
                try
                {
                    roll += Convert.ToInt32(match.Groups[4].Value);
                }
                catch
                {
                    throw new FormatException(String.Format("Unable to convert {0} to integer in {1}", match.Groups[4].Value, dice));
                }
            }
            else if (match.Groups[3].Value == "-")
            {
                // 1d100-10
                try
                {
                    roll -= Convert.ToInt32(match.Groups[4].Value);
                }
                catch
                {
                    throw new FormatException(String.Format("Unable to convert {0} to integer in {1}", match.Groups[4].Value, dice));
                }
            }
            else if (match.Groups[5].Value == "x")
            {
                // 1d100x10
                try
                {
                    roll *= Convert.ToInt32(match.Groups[6].Value);
                }
                catch
                {
                    throw new FormatException(String.Format("Unable to convert {0} to integer in {1}", match.Groups[6].Value, dice));
                }
            }
            return roll;
        }

        /// <summary>
        /// Take number of dice and number of sides, and roll 'em up
        /// </summary>
        /// <param name="num">Number of dice to roll</param>
        /// <param name="sides">Number of sides on the die</param>
        /// <returns>The result of the dice roll</returns>
        public int Roll(int num, int sides)
        {
            if (sides > maxSides)
            {
                throw new OverflowException(string.Format("Maximum number of sides is {0}", maxSides));
            }
            int result = 0;
            for (int i = 0; i < num; i++)
            {
                result += rollADie(sides);
            }
            return result;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Roll a die of the given number of sides using our random seed array,
        /// making sure it is a fair roll
        /// </summary>
        /// <param name="sides">Number of sides on the die</param>
        /// <returns>The result of the die roll</returns>
        private int rollADie(int sides)
        {
            if (sides > maxSides)
            {
                throw new OverflowException(string.Format("Maximum number of sides is {0}", maxSides));
            }
            if (sides <= 0)
            {
                return 0;
            }

            byte[] randomNumber = new byte[numBytes];
            int value = 0;
            do
            {
                // Fill the array with a random value.
                random.GetBytes(randomNumber);
                value = 0;
                foreach (byte b in randomNumber)
                {
                    value = value << 8;
                    value += b;
                }
            } while (!IsFairRoll(value, sides));

            return (value % sides) + 1;
        }

        /// <summary>
        /// Verify that our die roll was fair.  The problem we face is that we get a random
        /// value that fits in the number of bytes declared see above.  If we are rolling anything 
        /// fewe than that many sides, then the topmost values are a truncated die.
        /// 
        /// For example, if we are rolling a d20 on a byte (max d255), then we can fit 12.75 d20s 
        /// in the range so [0..19, 20..30, ... 200..219, 220..239] are all "full sets" in the range, 
        /// with [240..255] as a truncated die with only 16 sides.  
        /// 
        /// Any byte value above 239, then, is the result of an unfair die, so we discard it 
        /// and try again until we get a result from a full set
        /// </summary>
        /// <param name="roll">The die roll we got</param>
        /// <param name="sides">Number of sides on the die</param>
        /// <returns>true if the roll is from a full set</returns>
        private bool IsFairRoll(int roll, int sides)
        {
            int fullSetsOfValues = maxSides / sides;
            return roll < sides * fullSetsOfValues;
        }
        #endregion
    }
}
