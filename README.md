DecentDiceLib - A (decent) dice rolling libary for C#

DecentDiceLib is an attempt to get as fair a die roller as you can reasonably
get with pseudorandom number generators.  Die sizes up to d65535 are supported.

The RNGCryptoServiceProvider class is used for the source of randomness, and
the IsFairRoll mechanism is also implemented:
http://msdn.microsoft.com/en-us/library/system.security.cryptography.rngcryptoserviceprovider(v=vs.110).aspx

As written, requires .NET 4.5.

DecentDiceLib is a singleton:
```C#
Dice dice = Dice.Instance;
```

Interfaces:
```C#
Dice dice = Dice.Instance;
int roll;

// A single number N assumes 1dN
roll = dice.Roll(6);

// Two numbers M,N gives MdN
roll = dice.Roll(3,6);

// Dice notation strings are parsed out
// Only simple dice notation for now
// (don't do "1d6+1d4")
try
{
    roll = dice.Roll("1d6");
    roll = dice.Roll("3d20+1");
    roll = dice.Roll("2d10-1");
    roll = dice.Roll("3d6x10");
}
catch (OverflowException)
{
    ...
}
catch (FormatException)
{
    ...
}
```

TODO:
- Implement chained dice notation parsing
- Add summary dialog to the end of the test run

Testing:
DecentDiceTest is a simple test harness for the library.  It'll iterate die
sizes from 2-65535 and roll a large number of dice for each.  For each die 
size, it'll calculate the average value and compare with the expected value.
A chi squared value and associated p is calculated, indicating whether the
p value is statistically significant or not, comparing p against 0.05.

When running the test app, you'll see that there is always a proportion of dice 
that fail the p test.  If you rerun the test, different tests will fail while 
ones that failed previously will pass.  This is the price of pseudorandomness.
It's close to fair, but not perfectly so.  It's...decent.

Does it matter? Not in the least.
Is it overkill? Definitely.
Was it was fun to write? Yup!

Thanks to Miroslav Stampar and his Special Functions for C# library
(http://www.codeproject.com/Articles/11647/Special-Function-s-for-C)
