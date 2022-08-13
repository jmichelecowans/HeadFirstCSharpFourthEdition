namespace StringExtensionMethodsExample.AmazingExtensions
{
    public static class ExtendAHuman
    {
        public static bool IsDistressCall(this string s) => s.Contains("Help!");
    }
}
