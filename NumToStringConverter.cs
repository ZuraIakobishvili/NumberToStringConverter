using System.Text;

namespace GeorgianNumberToString;
public class NumToStringConverter
{
    private readonly BelowTwentyDictionary below20;
    private readonly TensDictionary ten;
    private readonly StringBuilder stringBuilder;
    private readonly HundredsDictionary hundreds;
    public NumToStringConverter()
    {
        below20 = new BelowTwentyDictionary();
        ten = new TensDictionary();
        hundreds = new HundredsDictionary();
        stringBuilder = new StringBuilder();
    }

    public void ConvertNumberToText()
    {
        stringBuilder.Clear();
        var num = ReadUserInput();

        if (int.Parse(num) > 0 && int.Parse(num) < 20)
        {
            Console.WriteLine(GetTextForSingleDigitNumber(num)); 
        }

        if (num.Length == 2 && int.Parse(num) > 19 && int.Parse(num) < 100)
        {
            Console.WriteLine(GetTextForTwoDigitNumber(num));
           
        }

        if (num.Length == 3 && int.Parse(num) > 99 && int.Parse(num) < 999)
        {
            Console.WriteLine(GetTextForThreeDigitNumber(num));
        }

    }

    private string ReadUserInput()
    {
        Console.WriteLine("Enter number: ");
        var num = Console.ReadLine();

        if (!int.TryParse(num, out _))
        {
            throw new Exception("Invalid input. Please enter a valid number.");
        }

        return num;
    }

    private string GetTextForSingleDigitNumber(string num)
    {
        if (int.Parse(num) < 20)
        {
            var getBelow20 = below20.GetBelow20();
            var key = int.Parse(num);
            if (getBelow20.ContainsKey(key))
            {
                return getBelow20[key];
            }
        }
        return string.Empty;
    }

    private string GetTextForTwoDigitNumber(string num)
    {
        var numToInt = int.Parse(num);

        if (ten.GetTens().ContainsKey(numToInt))
        {
            return ten.GetTens()[numToInt];
        }

        var firstDigit = int.Parse(num.Substring(0, 1));
        if (firstDigit % 2 != 0)
        {
            var firstNum = numToInt - 10 - (numToInt % 10);
            var lastNum = 10 + (numToInt % 10);

            return ten.GetTens()[firstNum].Replace("ი", "და") + below20.GetBelow20()[lastNum];
        }

        if (firstDigit % 2 == 0)
        {
            var firstNum = numToInt - (numToInt % 10);
            var lastNum = numToInt % 10;

            return ten.GetTens()[firstNum].Replace("ი", "და") + below20.GetBelow20()[lastNum];
        }

        return string.Empty;
    }

    private string GetTextForThreeDigitNumber(string num)
    {
        int numToInt = int.Parse(num);
        var hundredsCount = numToInt / 100;

        if (numToInt % 100 == 0)
        {
            return hundreds.GetHundreds()[hundredsCount];
        }

        if (numToInt % 100 != 0 && hundredsCount > 0)
        {

            stringBuilder.Append(hundreds.GetHundreds()[hundredsCount]);
            stringBuilder.Remove(stringBuilder.Length - 1, 1);

            var lastTwoDigits = num.Substring(1, 2);
            if (lastTwoDigits[0] == '0')
            {
                lastTwoDigits = lastTwoDigits.Substring(1);
            }

            var lastTwoDigitsInInt = int.Parse(lastTwoDigits);

            if (lastTwoDigitsInInt < 20)
            {
                stringBuilder.Append(GetTextForSingleDigitNumber(lastTwoDigits));
                return stringBuilder.ToString();
            }

            if (lastTwoDigitsInInt > 19 && lastTwoDigitsInInt < 100)
            {
                stringBuilder.Append(GetTextForTwoDigitNumber(lastTwoDigits));
                return stringBuilder.ToString();
            }
        }
        return stringBuilder.ToString();
    }
}

