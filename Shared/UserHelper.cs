namespace NumberToString.Shared;

public class UserHelper
{
    public static string ReadUserInput_EN()
    {
        Console.WriteLine("Enter number: ");
        var num = Console.ReadLine();

        if (!int.TryParse(num, out _))
        {
            throw new Exception("Invalid input. Please enter a valid number.");
        }

        return num;
    }

    public static string ReadUserInput_GE()
    {
        Console.WriteLine("შეიყვანეთ რიცხვი: ");
        var num = Console.ReadLine();

        if (!int.TryParse(num, out _))
        {
            throw new Exception("მონაცემები არასწორია.");
        }

        return num;
    }

}
