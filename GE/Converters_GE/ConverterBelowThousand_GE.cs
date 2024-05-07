using NumberToString.EN.Converters_EN;
using NumberToString.GE.Dictionaries;
using System.Text;

namespace NumberToString.GE.Converters_GE;

public interface IConverterBelowThousand_GE
{
    string GetTextForThreeDigitNumber(int num);
}
public class ConverterBelowThousand_GE : IConverterBelowThousand_GE
{
    private const int MaxTwoDigitNumber = 100;
    private const int MaxThreeDigitNumber = 1000;
    private readonly IConverterBelowTwenty_GE converterBelowTwenty_GE;
    private readonly IConverterBelowHundred_GE converterBelowHundred_GE;

    public ConverterBelowThousand_GE()
    {
        converterBelowHundred_GE = new ConverterBelowHundred_GE();
        converterBelowTwenty_GE = new ConverterBelowTwenty_GE();
    }

    public string GetTextForThreeDigitNumber(int num)
    {
        var stringBuilder = new StringBuilder();
        var reminderFromHundred = num % 100;
        var hundredsCount = num / 100;
        var getHundreds = HundredsDictionary_GE.GetHundreds();

        if (num % 100 == 0)
        {
            stringBuilder.Append(getHundreds[hundredsCount]);
            stringBuilder.Append('ი');
            return stringBuilder.ToString();
        }

        if (num % 100 != 0)
        {
            stringBuilder.Append(getHundreds[hundredsCount]);

            if (reminderFromHundred < 20)
            {
                stringBuilder.Append(converterBelowTwenty_GE.GetTextFromNumberBelowTwenty(reminderFromHundred));
            }
            else
            {
                stringBuilder.Append(converterBelowHundred_GE.GetTextFromNumberBelowHundred(reminderFromHundred));
            }
            return stringBuilder.ToString();
        }
        return string.Empty;
    }
}
