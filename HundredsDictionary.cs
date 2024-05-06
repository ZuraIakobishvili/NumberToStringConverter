namespace GeorgianNumberToString;
public class HundredsDictionary
{
    public Dictionary<int, string> GetHundreds()
    {
        return new Dictionary<int, string>
        {
            {1, "ას"},
            {2, "ორას"},
            {3, "სამას"},
            {4, "ოთხას"},
            {5, "ხუთას"},
            {6, "ექვსას"},
            {7, "შვიდას"},
            {8, "რვაას"},
            {9, "ცხრაას"},
        };
    }
}
