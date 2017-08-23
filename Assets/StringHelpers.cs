using System.Linq;

public static class StringHelpers
{
    public static bool HasVowel(this string queryString)
    {
        return queryString.ToLower().Any((x) => x == 'a' || x == 'e' || x == 'i' || x == 'o' || x == 'u');
    }
}

