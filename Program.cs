using System.Text;

namespace NumberToString;
public class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        var converter = new ConverterService();
        converter.NumConverter();
    }
}
