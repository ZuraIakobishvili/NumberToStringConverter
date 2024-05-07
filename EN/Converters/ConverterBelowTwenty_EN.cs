using NumberToString.EN.Dictionaries;
using System.Text;

namespace NumberToString.EN.Converters;

public interface IConverterBelowTwenty_EN
{
    string GetTextFromNumberBelowTwenty(int num);
}

public class ConverterBelowTwenty_EN : IConverterBelowTwenty_EN
{
    private const int MaxUnderTwentyNumber = 20;

    public string GetTextFromNumberBelowTwenty(int num)
    {
        var getBelow20 = BelowTwentyDictionary_EN.GetBelow20_EN();
        var stringBuilder = new StringBuilder();

        if (num > 0 && num < MaxUnderTwentyNumber)
        {
            if (getBelow20.ContainsKey(num))
            {
                stringBuilder.Append(getBelow20[num]);
                return stringBuilder.ToString();
            }
        }

        return String.Empty;
    }
}
