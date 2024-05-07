using NumberToString.EN.Converters_EN;
using NumberToString.GE.Converters_GE;
using NumberToString.Shared;

namespace NumberToString;

public interface IConverterService
{
    void NumConverter();
}
public class ConverterService : IConverterService
{
    private readonly IConverterBelowTwenty_EN _convertBelowTwenty_EN;
    private readonly IConverterBelowHundred_EN _convertBelowHundred_EN;
    private readonly IConverterBelowThousand_EN _convertBelowThousand_EN;

    private readonly IConverterBelowTwenty_GE _converterBelowTwenty_GE;
    private readonly IConverterBelowHundred_GE _converterBelowHundred_GE;
    private readonly IConverterBelowThousand_GE _converterBelowThousand_GE;

    private const int MaxNumBelowTwenty = 20;
    private const int MinNumBelowTwenty = 0;
    private const int MaxNumBelowHundred = 100;
    private const int MinNumBelowHundred = 19;
    private const int MaxNumBelowThousand = 1000;
    private const int MinNumBelowThousand = 99;

    public ConverterService()
    {
        _convertBelowHundred_EN = new ConverterBelowHundred_EN();
        _convertBelowTwenty_EN = new ConverterBelowTwenty_EN();
        _convertBelowThousand_EN = new ConverterBelowThousand_EN();

        _converterBelowTwenty_GE = new ConverterBelowTwenty_GE();
        _converterBelowHundred_GE = new ConverterBelowHundred_GE();
        _converterBelowThousand_GE = new ConverterBelowThousand_GE();
    }
    private string ConvertString_EN(int num)
    {
        if (num > MinNumBelowTwenty && num < MaxNumBelowTwenty)
        {
            return _convertBelowTwenty_EN.GetTextFromNumberBelowTwenty(num);
        }

        if (num > MinNumBelowHundred && num < MaxNumBelowHundred)
        {
            return _convertBelowHundred_EN.GetTextBelowOneHundred(num);
        }

        if (num > MinNumBelowThousand && num < MaxNumBelowThousand)
        {
            return _convertBelowThousand_EN.GetTextFromNumberUnderThousand(num);
        }

        return string.Empty;
    }

    private string ConvertString_GE(int num)
    {
        if (num > MinNumBelowTwenty && num < MaxNumBelowTwenty)
        {
            return _converterBelowTwenty_GE.GetTextFromNumberBelowTwenty(num);
        }

        if (num > MinNumBelowHundred && num < MaxNumBelowHundred)
        {
            return _converterBelowHundred_GE.GetTextFromNumberBelowHundred(num);
        }

        if(num > MinNumBelowThousand && num < MaxNumBelowThousand)
        {
            return _converterBelowThousand_GE.GetTextForThreeDigitNumber(num);
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
                    var num_EN = int.Parse(UserHelper.ReadUserInput_EN());
                    Console.WriteLine(ConvertString_EN(num_EN));
                    break;

                case "2":
                    var num_GE = int.Parse(UserHelper.ReadUserInput_GE());
                    Console.WriteLine(ConvertString_GE(num_GE));
                    break;
            }
        }
    }
}
