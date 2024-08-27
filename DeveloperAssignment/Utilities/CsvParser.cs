namespace DeveloperAssignment.Utilities
{
    public static class CsvParser
    {
        public static string RemoveQuote(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            if (input.StartsWith("\"") && input.EndsWith("\""))
                return input.Substring(1, input.Length - 2);

            if (input.StartsWith("\""))
                return input.Substring(1);

            if (input.EndsWith("\""))
                return input.Substring(0, input.Length - 1);

            return input;
        }
    }
}
