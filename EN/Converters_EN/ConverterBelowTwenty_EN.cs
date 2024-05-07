using NumberToString.EN.Dictionaries;
using System.Text;

namespace NumberToString.EN.Converters_EN;

public interface IConverterBelowTwenty_EN
{
    string GetTextFromNumberBelowTwenty(int num);
}

public class ConverterBelowTwenty_EN : IConverterBelowTwenty_EN
{

    public string GetTextFromNumberBelowTwenty(int num)
    {
        var getBelow20 = BelowTwentyDictionary_EN.GetBelow20_EN();
        var stringBuilder = new StringBuilder();

            if (getBelow20.ContainsKey(num))
            {
                stringBuilder.Append(getBelow20[num]);
                return stringBuilder.ToString();
            }

        return string.Empty;
    }
}
