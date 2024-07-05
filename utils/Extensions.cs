internal static class Extensions
{
    public static bool InvariantContains(this string s1, string s2) =>
        s1?.IndexOf(s2, StringComparison.InvariantCultureIgnoreCase) != -1;
}
