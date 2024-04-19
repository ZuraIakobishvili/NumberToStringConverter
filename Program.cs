using System.Text;

namespace GeorgianNumberToString;
public class Program
{
   static void Main(string[] args)
    {
        var converter = new NumToStringConverter();
        Console.OutputEncoding = Encoding.UTF8;
        while (true)
        {
            converter.ConvertNumberToText();
        }
    }
}
