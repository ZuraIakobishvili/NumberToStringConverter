using NumberToString.GE.Dictionaries;

namespace NumberToString.GE.Converters_GE;

public interface IConverterBelowTwenty_GE
{
    string GetTextFromNumberBelowTwenty(int num);
}
public class ConverterBelowTwenty_GE : IConverterBelowTwenty_GE
{
    private const int MaxSingleDigitNumber = 20;
    public string GetTextFromNumberBelowTwenty(int num)
    {
        if (num < MaxSingleDigitNumber)
        {
            var getBelow20 = BelowTwentyDictionary_GE.GetBelow20_GE();
           
            if (getBelow20.ContainsKey(num))
            {
                return getBelow20[num];
            }
        }
        return string.Empty;
    }
}
