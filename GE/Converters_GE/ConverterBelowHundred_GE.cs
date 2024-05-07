using NumberToString.GE.Dictionaries;
using System.Text;

namespace NumberToString.GE.Converters_GE;

public interface IConverterBelowHundred_GE
{
    string GetTextFromNumberBelowHundred(int num);
}

public class ConverterBelowHundred_GE : IConverterBelowHundred_GE
{
    private const int MaxSingleDigitNumber = 20;
    private const int MaxTwoDigitNumber = 100;

    public string GetTextFromNumberBelowHundred(int num)
    {
        var stringBuilder = new StringBuilder();
        var tensCount = num / 10;
        var getTens = TensDictionary_GE.GetTens();
        var getBelow20 = BelowTwentyDictionary_GE.GetBelow20_GE();
        var remainderFrom20 = num % 20;

        if (num > MaxSingleDigitNumber && num < MaxTwoDigitNumber)
        {

            if (num % 20 == 0)
            {
                if (getTens.ContainsKey(tensCount))
                {
                    stringBuilder.Append(getTens[tensCount]);
                    stringBuilder.Replace("და", "ი");
                    return stringBuilder.ToString();
                }
            }

            if (num % 20 != 0)
            {
                if (getTens.ContainsKey(tensCount))
                {
                    stringBuilder.Append(getTens[tensCount]);
                    stringBuilder.Append(getBelow20[remainderFrom20]);
                    return stringBuilder.ToString();
                }
            }
        }

        return string.Empty;
    }
}
