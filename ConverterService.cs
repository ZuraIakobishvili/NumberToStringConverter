using NumberToString.EN.Converters;
using NumberToString.Shared;

namespace NumberToString;

public interface IConverterService
{
    void NumConverter();
}
public class ConverterService : IConverterService
{
    private readonly IConverterBelowTwenty_EN _convertTextUnderTwenty_EN;
    private readonly IConverterBelowHundred_EN _convertTextUnderHundred_EN;
    private readonly IConverterBelowThousand_EN _convertTextUnderThousand_EN;
    public ConverterService()
    {
        _convertTextUnderHundred_EN = new ConverterBelowHundred_EN();
        _convertTextUnderTwenty_EN = new ConverterBelowTwenty_EN();
        _convertTextUnderThousand_EN = new ConverterBelowThousand_EN();
    }
    private string ConvertString_EN(int num)
    {
        if (num > 0 && num < 20)
        {
            return _convertTextUnderTwenty_EN.GetTextFromNumberBelowTwenty(num);
        }

        if (num >= 20 && num < 100)
        {
            return _convertTextUnderHundred_EN.GetTextBelowOneHundred(num);
        }

        if (num >= 100 && num < 1000)
        {
            return _convertTextUnderThousand_EN.GetTextFromNumberUnderThousand(num);
        }

        return string.Empty;
    }

    private string ConvertString_GE(int num)
    {
        if (num > 0 && num < 20)
        {
            return _convertTextUnderTwenty_EN.GetTextFromNumberBelowTwenty(num);
        }

        if (num >= 20 && num < 100)
        {
            return _convertTextUnderHundred_EN.GetTextBelowOneHundred(num);
        }

        return string.Empty;
    }

    public void NumConverter()
    {
        Console.WriteLine("Choose language: \n 1) EN \n 2) GE");

        var lang = Console.ReadLine();

        while (true)
        {
            switch (lang)
            {
                case "1":
                    var num = int.Parse(UserHelper.ReadUserInput_EN());
                    Console.WriteLine(ConvertString_EN(num));
                    break;

                case "2":
                    var num1 = int.Parse(UserHelper.ReadUserInput_GE());
                    Console.WriteLine(ConvertString_GE(num1));
                    break;
            }

        }
    }
}
