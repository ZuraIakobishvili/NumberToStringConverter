namespace GeorgianNumberToString;
public class HundredsDictionary
{
    public Dictionary<int, string> GetHundreds()
    {
        return new Dictionary<int, string>
        {
            {1, "ასი"},
            {2, "ორასი"},
            {3, "სამასი"},
            {4, "ოთხასი"},
            {5, "ხუთასი"},
            {6, "ექვსასი"},
            {7, "შვიდასი"},
            {8, "რვაასი"},
            {9, "ცხრაასი"},
        };
    }
}
