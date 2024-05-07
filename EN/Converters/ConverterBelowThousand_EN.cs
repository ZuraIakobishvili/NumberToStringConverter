using NumberToString.EN.Dictionaries;
using System.Text;

namespace NumberToString.EN.Converters;

public interface IConverterBelowThousand_EN
{
    string GetTextFromNumberUnderThousand(int num);
}

public class ConverterBelowThousand_EN : IConverterBelowThousand_EN
{
    private static int MaxUnderThousandNum = 1000;
    private static int MinUnderThousandNum = 99;
    private readonly IConverterBelowTwenty_EN _converterBelow20;
    private readonly IConverterBelowHundred_EN _converterBelowHundred;
    public ConverterBelowThousand_EN()
    {
        _converterBelow20 = new ConverterBelowTwenty_EN();
        _converterBelowHundred = new ConverterBelowHundred_EN();
    }

    public string GetTextFromNumberUnderThousand(int num)
    {
        var stringBuilder = new StringBuilder();
        var hundredsCount = num / 100;
        var reminderFromNum = num % 100;
        var hundreds = HundredsDictionary_EN.GetHundreds_EN();

        if (num > MinUnderThousandNum && num < MaxUnderThousandNum)
        {
            if (reminderFromNum == 0)
            {
                stringBuilder.Append(hundreds[hundredsCount]);
                return stringBuilder.ToString();
            }

            if(reminderFromNum != 0)
            {
                stringBuilder.Append(hundreds[hundredsCount]);

                if (reminderFromNum < 20)
                {
                    stringBuilder.Append(_converterBelow20.GetTextFromNumberBelowTwenty(reminderFromNum));

                }
                else
                {
                    stringBuilder.Append(_converterBelowHundred.GetTextBelowOneHundred(reminderFromNum));
                }
                return stringBuilder.ToString();
            }
        }
        return string.Empty;
    }
}
