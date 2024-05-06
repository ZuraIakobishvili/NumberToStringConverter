using System.Text;

namespace GeorgianNumberToString;
public class NumToStringConverter
{
    private readonly BelowTwentyDictionary below20;
    private readonly TensDictionary ten;
    private readonly HundredsDictionary hundreds;
    public NumToStringConverter()
    {
        below20 = new BelowTwentyDictionary();
        ten = new TensDictionary();
        hundreds = new HundredsDictionary();
    }

    public void ConvertNumberToText()
    {
        var num = ReadUserInput();

        if (int.Parse(num) >= 0 && int.Parse(num) < 20)
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
        var stringBuilder = new StringBuilder();
        var numToInt = int.Parse(num);
        var tensCount = numToInt / 10;
        var getTens = ten.GetTens();
        var getBelow20 = below20.GetBelow20();
        var remainderFrom20 = numToInt % 20;

        if (numToInt % 20 == 0)
        {
            if (getTens.ContainsKey(tensCount))
            {
                stringBuilder.Append(getTens[tensCount]);
                stringBuilder.Replace("და", "ი");
                return stringBuilder.ToString();
            }
        }

        if (numToInt % 20 != 0)
        {
            if (getTens.ContainsKey(tensCount))
            {
                stringBuilder.Append(getTens[tensCount]);
                stringBuilder.Append(getBelow20[remainderFrom20]);
                return stringBuilder.ToString();
            }
        }

        return string.Empty;
    }


    private string GetTextForThreeDigitNumber(string num)
    {
        var stringBuilder = new StringBuilder();
        var numToInt = int.Parse(num);
        var reminderFromHundred = numToInt % 100;
        var hundredsCount = numToInt / 100;
        var getHundreds = hundreds.GetHundreds();

        if (numToInt % 100 == 0)
        {
            stringBuilder.Append(getHundreds[hundredsCount]);
            stringBuilder.Append('ი');
            return stringBuilder.ToString();
        }

        if (numToInt % 100 != 0)
        {
            stringBuilder.Append(getHundreds[hundredsCount]);

            if (reminderFromHundred < 20)
            {
                stringBuilder.Append(GetTextForSingleDigitNumber(reminderFromHundred.ToString()));
            }
            else
            {
                stringBuilder.Append(GetTextForTwoDigitNumber(reminderFromHundred.ToString()));
            }
            return stringBuilder.ToString();
        }
        return string.Empty;
    }
}

