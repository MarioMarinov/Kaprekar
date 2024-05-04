/*
 * Kaprekar's Constant demo
 * Not taking into account cycles for numbers 
 * having more than 4 digits
 */


Console.WriteLine("Kaprekar's Constant");
Console.WriteLine();
long digits;
do
    Console.Write("Digits in the integer number (3-9): ");
while (!long.TryParse(Console.ReadLine(), out digits));

Console.WriteLine();

var min = (long)Math.Pow(10, digits - 1);
var max = (long)Math.Pow(10, digits)-1;
var rnd = new Random();
var number = rnd.NextInt64(min, max);
Console.WriteLine($"Interval:[{min},{max}]");
Console.WriteLine($"Initial number: {number}");

var oldNumber = number;
long newNumber = 0;
var cycle = 0;
while (true)
{
    newNumber = Recalculate(++cycle, oldNumber);
    if (oldNumber == newNumber) break;
    oldNumber = newNumber;
}

Console.WriteLine("Done");
Console.WriteLine($"{oldNumber}");

static long Recalculate(long cycle, long value)
{
    var numberChars = (value.ToString()).ToCharArray();
    var sortedSeqMin = numberChars.OrderBy(x => x);
    var sortedSeqMax = sortedSeqMin.Reverse();
    var min = long.Parse(string.Join(string.Empty, sortedSeqMin));
    var max = long.Parse(string.Join(string.Empty, sortedSeqMax));
    var res = max - min;
    Console.WriteLine($"{cycle}: {max}-{min}={res}");
    return res;
}