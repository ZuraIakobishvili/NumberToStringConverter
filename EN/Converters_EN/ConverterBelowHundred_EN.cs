using NumberToString.EN.Dictionaries;
using System.Text;

namespace NumberToString.EN.Converters_EN;
public interface IConverterBelowHundred_EN
{
    string GetTextBelowOneHundred(int num);
}

public class ConverterBelowHundred_EN : IConverterBelowHundred_EN
{
    public string GetTextBelowOneHundred(int num)
    {
        var stringBuilder = new StringBuilder();
        var getTens = TensDictionary_EN.GetTens_EN();
        var tensCount = num / 10;
        var reminderFromNum = num % 10;
        var getBelowTwenty = BelowTwentyDictionary_EN.GetBelow20_EN();
        
            if (num % 10 == 0)
            {
                if (getTens.ContainsKey(tensCount))
                {
                    stringBuilder.Append(getTens[tensCount]);
                    return stringBuilder.ToString();
                }
            }

            if (num % 10 != 0)
            {
                stringBuilder.Append(getTens[tensCount]);
                stringBuilder.Append(getBelowTwenty[reminderFromNum]);
                return stringBuilder.ToString();
            }
        
        return string.Empty;
    }
}
