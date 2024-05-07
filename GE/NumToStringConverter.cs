using System.Text;
using NumberToString.GE.Dictionaries;

namespace NumberToString.GE;
public class NumToStringConverter
{
    private const int MaxSingleDigitNumber = 20;
    private const int MaxTwoDigitNumber = 100;
    private const int MaxThreeDigitNumber = 1000;

    public void ConvertNumberToText()
    {
        var num = ReadUserInput();

        if (int.Parse(num) >= 0 && int.Parse(num) < MaxSingleDigitNumber)
        {
            Console.WriteLine(GetTextForSingleDigitNumber(num));
        }

        if (num.Length == 2 && int.Parse(num) > MaxSingleDigitNumber && int.Parse(num) < MaxTwoDigitNumber)
        {
            Console.WriteLine(GetTextForTwoDigitNumber(num));

        }

        if (num.Length == 3 && int.Parse(num) > MaxTwoDigitNumber && int.Parse(num) < MaxThreeDigitNumber)
        {
            Console.WriteLine(GetTextForThreeDigitNumber(num));
        }

    }

    private string ReadUserInput()
    {
        Console.WriteLine("შეიყვანეტ რიცხვი: ");
        var num = Console.ReadLine();

        if (!int.TryParse(num, out _))
        {
            throw new Exception("გთხოვთ შეიყვანოთ სწორი მონაცემები.");
        }

        return num;
    }

    private string GetTextForSingleDigitNumber(string num)
    {
        if (int.Parse(num) < 20)
        {
            var getBelow20 = BelowTwentyDictionary_GE.GetBelow20_GE();
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
        var getTens = TensDictionary.GetTens();
        var getBelow20 = BelowTwentyDictionary_GE.GetBelow20_GE();
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
        var getHundreds = HundredsDictionary.GetHundreds();

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

