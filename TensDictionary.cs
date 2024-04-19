﻿namespace GeorgianNumberToString;
public class TensDictionary
{
    public Dictionary<int, string> GetTens()
    {
        return new Dictionary<int, string>
        {
            {20, "ოცი"},
            {30, "ოცდაათი"},
            {40, "ორმოცი"},
            {50, "ორმოცდაათი"},
            {60, "სამოცი"},
            {70, "სამოცდაათი"},
            {80, "ოთხმოცი"},
            {90, "ოთხმოცდაათი"},
        };
    }
}
